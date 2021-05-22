namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;

    public sealed class Rope : PoolObject, IEquatable<Rope>
    {
        public Rope(int handle) : base(handle)
        {
        }

        public void ActivatePhysics()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.ACTIVATE_PHYSICS, arguments);
        }

        public void AttachEntities(Entity entityOne, Entity entityTwo, float length)
        {
            this.AttachEntities(entityOne, Vector3.Zero, entityTwo, Vector3.Zero, length);
        }

        public void AttachEntities(Entity entityOne, Vector3 positionOne, Entity entityTwo, Vector3 positionTwo, float length)
        {
            InputArgument[] arguments = new InputArgument[14];
            arguments[0] = base.Handle;
            arguments[1] = entityOne.Handle;
            arguments[2] = entityTwo.Handle;
            arguments[3] = positionOne.X;
            arguments[4] = positionOne.Y;
            arguments[5] = positionOne.Z;
            arguments[6] = positionTwo.X;
            arguments[7] = positionTwo.Y;
            arguments[8] = positionTwo.Z;
            arguments[9] = length;
            arguments[10] = 0;
            arguments[11] = 0;
            arguments[12] = 0;
            arguments[13] = 0;
            Function.Call(Hash.ATTACH_ENTITIES_TO_ROPE, arguments);
        }

        public void AttachEntity(Entity entity)
        {
            this.AttachEntity(entity, Vector3.Zero);
        }

        public void AttachEntity(Entity entity, Vector3 position)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, entity.Handle, position.X, position.Y, position.Z, 0 };
            Function.Call(Hash.ATTACH_ROPE_TO_ENTITY, arguments);
        }

        public override unsafe void Delete()
        {
            int handle = base.Handle;
            InputArgument[] arguments = new InputArgument[] { (IntPtr) &handle };
            Function.Call(Hash.DELETE_ROPE, arguments);
            base.Handle = handle;
        }

        public void DetachEntity(Entity entity)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, entity.Handle };
            Function.Call(Hash.DETACH_ROPE_FROM_ENTITY, arguments);
        }

        public bool Equals(Rope rope) => 
            (rope != null) && (base.Handle == rope.Handle);

        public override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == base.GetType()) && this.Equals((Rope) obj));

        public override unsafe bool Exists()
        {
            int handle = base.Handle;
            InputArgument[] arguments = new InputArgument[] { (IntPtr) &handle };
            return Function.Call<bool>(Hash.DOES_ROPE_EXIST, arguments);
        }

        public static bool Exists(Rope rope) => 
            (rope != null) && rope.Exists();

        public sealed override int GetHashCode() => 
            base.Handle;

        public Vector3 GetVertexCoord(int vertex)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, vertex };
            return Function.Call<Vector3>(Hash.GET_ROPE_VERTEX_COORD, arguments);
        }

        public static bool operator ==(Rope left, Rope right) => 
            (left == null) ? ReferenceEquals(right, null) : left.Equals(right);

        public static bool operator !=(Rope left, Rope right) => 
            !(left == right);

        public void PinVertex(int vertex, Vector3 position)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, vertex, position.X, position.Y, position.Z };
            Function.Call(Hash.PIN_ROPE_VERTEX, arguments);
        }

        public void ResetLength(bool reset)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, reset };
            Function.Call(Hash.ROPE_RESET_LENGTH, arguments);
        }

        public void UnpinVertex(int vertex)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, vertex };
            Function.Call(Hash.UNPIN_ROPE_VERTEX, arguments);
        }

        public float Length
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash._GET_ROPE_LENGTH, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.ROPE_FORCE_LENGTH, arguments);
            }
        }

        public int VertexCount
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_ROPE_VERTEX_COUNT, arguments);
            }
        }
    }
}

