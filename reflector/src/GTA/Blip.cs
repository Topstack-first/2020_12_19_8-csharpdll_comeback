namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;

    public sealed class Blip : PoolObject, IEquatable<Blip>
    {
        public Blip(int handle) : base(handle)
        {
        }

        public override unsafe void Delete()
        {
            int handle = base.Handle;
            InputArgument[] arguments = new InputArgument[] { (IntPtr) &handle };
            Function.Call(Hash.REMOVE_BLIP, arguments);
            base.Handle = handle;
        }

        public bool Equals(Blip blip) => 
            (blip != null) && (base.Handle == blip.Handle);

        public override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == base.GetType()) && this.Equals((Blip) obj));

        public override bool Exists()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash.DOES_BLIP_EXIST, arguments);
        }

        public static bool Exists(Blip blip) => 
            (blip != null) && blip.Exists();

        public sealed override int GetHashCode() => 
            base.Handle.GetHashCode();

        public static bool operator ==(Blip left, Blip right) => 
            (left == null) ? ReferenceEquals(right, null) : left.Equals(right);

        public static bool operator !=(Blip left, Blip right) => 
            !(left == right);

        public void RemoveNumberLabel()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.HIDE_NUMBER_ON_BLIP, arguments);
        }

        public Vector3 Position
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<Vector3>(Hash.GET_BLIP_INFO_ID_COORD, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value.X, value.Y, value.Z };
                Function.Call(Hash.SET_BLIP_COORDS, arguments);
            }
        }

        public int Rotation
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_ROTATION, arguments);
            }
        }

        public float Scale
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_SCALE, arguments);
            }
        }

        public int Type
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_BLIP_INFO_ID_TYPE, arguments);
            }
        }

        public int Alpha
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_BLIP_ALPHA, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_ALPHA, arguments);
            }
        }

        public int Priority
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_PRIORITY, arguments);
            }
        }

        public int NumberLabel
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SHOW_NUMBER_ON_BLIP, arguments);
            }
        }

        public BlipColor Color
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_BLIP_COLOUR, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_COLOUR, arguments);
            }
        }

        public BlipSprite Sprite
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_BLIP_SPRITE, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_SPRITE, arguments);
            }
        }

        public string Name
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { MemoryAccess.StringPtr };
                Function.Call(Hash.BEGIN_TEXT_COMMAND_SET_BLIP_NAME, arguments);
                InputArgument[] argumentArray2 = new InputArgument[] { value };
                Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray2);
                InputArgument[] argumentArray3 = new InputArgument[] { base.Handle };
                Function.Call(Hash.END_TEXT_COMMAND_SET_BLIP_NAME, argumentArray3);
            }
        }

        public GTA.Entity Entity
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<GTA.Entity>(Hash.GET_BLIP_INFO_ID_ENTITY_INDEX, arguments);
            }
        }

        public bool ShowRoute
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_ROUTE, arguments);
            }
        }

        public bool IsFriendly
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_AS_FRIENDLY, arguments);
            }
        }

        public bool IsFlashing
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_BLIP_FLASHING, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_FLASHES, arguments);
            }
        }

        public bool IsOnMinimap
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_BLIP_ON_MINIMAP, arguments);
            }
        }

        public bool IsShortRange
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_BLIP_SHORT_RANGE, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLIP_AS_SHORT_RANGE, arguments);
            }
        }
    }
}

