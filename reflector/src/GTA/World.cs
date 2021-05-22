namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class World
    {
        internal static readonly string[] _weatherNames;

        static World()
        {
            string[] textArray1 = new string[14];
            textArray1[0] = "EXTRASUNNY";
            textArray1[1] = "CLEAR";
            textArray1[2] = "CLOUDS";
            textArray1[3] = "SMOG";
            textArray1[4] = "FOGGY";
            textArray1[5] = "OVERCAST";
            textArray1[6] = "RAIN";
            textArray1[7] = "THUNDER";
            textArray1[8] = "CLEARING";
            textArray1[9] = "NEUTRAL";
            textArray1[10] = "SNOW";
            textArray1[11] = "BLIZZARD";
            textArray1[12] = "SNOWLIGHT";
            textArray1[13] = "XMAS";
            _weatherNames = textArray1;
        }

        public static void AddExplosion(Vector3 position, ExplosionType type, float radius, float cameraShake, Ped owner = null, bool aubidble = true, bool invisible = false)
        {
            if (!Entity.Exists(owner))
            {
                InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, type, radius, aubidble, invisible, cameraShake };
                Function.Call(Hash.ADD_EXPLOSION, arguments);
            }
            else
            {
                InputArgument[] arguments = new InputArgument[9];
                arguments[0] = owner.Handle;
                arguments[1] = position.X;
                arguments[2] = position.Y;
                arguments[3] = position.Z;
                arguments[4] = type;
                arguments[5] = radius;
                arguments[6] = aubidble;
                arguments[7] = invisible;
                arguments[8] = cameraShake;
                Function.Call(Hash.ADD_OWNED_EXPLOSION, arguments);
            }
        }

        public static unsafe RelationshipGroup AddRelationshipGroup(string name)
        {
            int num;
            InputArgument[] arguments = new InputArgument[] { name, (IntPtr) &num };
            Function.Call(Hash.ADD_RELATIONSHIP_GROUP, arguments);
            return new RelationshipGroup(num);
        }

        public static Rope AddRope(RopeType type, Vector3 position, Vector3 rotation, float length, float minLength, bool breakable)
        {
            Function.Call(Hash.ROPE_LOAD_TEXTURES, Array.Empty<InputArgument>());
            InputArgument[] arguments = new InputArgument[0x11];
            arguments[0] = position.X;
            arguments[1] = position.Y;
            arguments[2] = position.Z;
            arguments[3] = rotation.X;
            arguments[4] = rotation.Y;
            arguments[5] = rotation.Z;
            arguments[6] = length;
            arguments[7] = type;
            arguments[8] = length;
            arguments[9] = minLength;
            arguments[10] = 0.5f;
            arguments[11] = false;
            arguments[12] = false;
            arguments[13] = true;
            arguments[14] = 1f;
            arguments[15] = breakable;
            arguments[0x10] = 0;
            return new Rope(Function.Call<int>(Hash.ADD_ROPE, arguments));
        }

        public static float CalculateTravelDistance(Vector3 origin, Vector3 destination)
        {
            InputArgument[] arguments = new InputArgument[] { origin.X, origin.Y, origin.Z, destination.X, destination.Y, destination.Z };
            return Function.Call<float>(Hash.CALCULATE_TRAVEL_DISTANCE_BETWEEN_POINTS, arguments);
        }

        public static Prop CreateAmbientPickup(PickupType type, Vector3 position, Model model, int value)
        {
            if (!model.Request(0x3e8))
            {
                return null;
            }
            InputArgument[] arguments = new InputArgument[9];
            arguments[0] = type;
            arguments[1] = position.X;
            arguments[2] = position.Y;
            arguments[3] = position.Z;
            arguments[4] = 0;
            arguments[5] = value;
            arguments[6] = model.Hash;
            arguments[7] = false;
            arguments[8] = true;
            int handle = Function.Call<int>(Hash.CREATE_AMBIENT_PICKUP, arguments);
            return ((handle != 0) ? new Prop(handle) : null);
        }

        public static Blip CreateBlip(Vector3 position)
        {
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z };
            return new Blip(Function.Call<int>(Hash.ADD_BLIP_FOR_COORD, arguments));
        }

        public static Blip CreateBlip(Vector3 position, float radius)
        {
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, radius };
            return new Blip(Function.Call<int>(Hash.ADD_BLIP_FOR_RADIUS, arguments));
        }

        public static Camera CreateCamera(Vector3 position, Vector3 rotation, float fov)
        {
            InputArgument[] arguments = new InputArgument[10];
            arguments[0] = "DEFAULT_SCRIPTED_CAMERA";
            arguments[1] = position.X;
            arguments[2] = position.Y;
            arguments[3] = position.Z;
            arguments[4] = rotation.X;
            arguments[5] = rotation.Y;
            arguments[6] = rotation.Z;
            arguments[7] = fov;
            arguments[8] = 1;
            arguments[9] = 2;
            return new Camera(Function.Call<int>(Hash.CREATE_CAM_WITH_PARAMS, arguments));
        }

        public static Checkpoint CreateCheckpoint(CheckpointCustomIcon icon, Vector3 position, Vector3 pointTo, float radius, Color color)
        {
            InputArgument[] arguments = new InputArgument[13];
            arguments[0] = 0x2a;
            arguments[1] = position.X;
            arguments[2] = position.Y;
            arguments[3] = position.Z;
            arguments[4] = pointTo.X;
            arguments[5] = pointTo.Y;
            arguments[6] = pointTo.Z;
            arguments[7] = radius;
            arguments[8] = color.R;
            arguments[9] = color.G;
            arguments[10] = color.B;
            arguments[11] = color.A;
            arguments[12] = (InputArgument) icon;
            int handle = Function.Call<int>(Hash.CREATE_CHECKPOINT, arguments);
            return ((handle != 0) ? new Checkpoint(handle) : null);
        }

        public static Checkpoint CreateCheckpoint(CheckpointIcon icon, Vector3 position, Vector3 pointTo, float radius, Color color)
        {
            InputArgument[] arguments = new InputArgument[13];
            arguments[0] = icon;
            arguments[1] = position.X;
            arguments[2] = position.Y;
            arguments[3] = position.Z;
            arguments[4] = pointTo.X;
            arguments[5] = pointTo.Y;
            arguments[6] = pointTo.Z;
            arguments[7] = radius;
            arguments[8] = color.R;
            arguments[9] = color.G;
            arguments[10] = color.B;
            arguments[11] = color.A;
            arguments[12] = 0;
            int handle = Function.Call<int>(Hash.CREATE_CHECKPOINT, arguments);
            return ((handle != 0) ? new Checkpoint(handle) : null);
        }

        public static Ped CreatePed(Model model, Vector3 position, float heading = 0f)
        {
            if (!model.IsPed || !model.Request(0x3e8))
            {
                return null;
            }
            InputArgument[] arguments = new InputArgument[] { 0x1a, model.Hash, position.X, position.Y, position.Z, heading, false, false };
            return new Ped(Function.Call<int>(Hash.CREATE_PED, arguments));
        }

        public static Pickup CreatePickup(PickupType type, Vector3 position, Model model, int value)
        {
            if (!model.Request(0x3e8))
            {
                return null;
            }
            InputArgument[] arguments = new InputArgument[] { type, position.X, position.Y, position.Z, 0, value, true, model.Hash };
            int handle = Function.Call<int>(Hash.CREATE_PICKUP, arguments);
            return ((handle != 0) ? new Pickup(handle) : null);
        }

        public static Pickup CreatePickup(PickupType type, Vector3 position, Vector3 rotation, Model model, int value)
        {
            if (!model.Request(0x3e8))
            {
                return null;
            }
            InputArgument[] arguments = new InputArgument[12];
            arguments[0] = type;
            arguments[1] = position.X;
            arguments[2] = position.Y;
            arguments[3] = position.Z;
            arguments[4] = rotation.X;
            arguments[5] = rotation.Y;
            arguments[6] = rotation.Z;
            arguments[7] = 0;
            arguments[8] = value;
            arguments[9] = 2;
            arguments[10] = true;
            arguments[11] = model.Hash;
            int handle = Function.Call<int>(Hash.CREATE_PICKUP_ROTATE, arguments);
            return ((handle != 0) ? new Pickup(handle) : null);
        }

        public static Prop CreateProp(Model model, Vector3 position, bool dynamic, bool placeOnGround)
        {
            if (!model.Request(0x3e8))
            {
                return null;
            }
            if (placeOnGround)
            {
                position.Z = GetGroundHeight(position);
            }
            InputArgument[] arguments = new InputArgument[] { model.Hash, position.X, position.Y, position.Z, 1, 1, dynamic };
            return new Prop(Function.Call<int>(Hash.CREATE_OBJECT, arguments));
        }

        public static Prop CreateProp(Model model, Vector3 position, Vector3 rotation, bool dynamic, bool placeOnGround)
        {
            Prop prop = CreateProp(model, position, dynamic, placeOnGround);
            if (prop != null)
            {
                prop.Rotation = rotation;
            }
            return prop;
        }

        public static Prop CreatePropNoOffset(Model model, Vector3 position, bool dynamic)
        {
            if (!model.Request(0x3e8))
            {
                return null;
            }
            InputArgument[] arguments = new InputArgument[] { model.Hash, position.X, position.Y, position.Z, 1, 1, dynamic };
            return new Prop(Function.Call<int>(Hash.CREATE_OBJECT_NO_OFFSET, arguments));
        }

        public static Prop CreatePropNoOffset(Model model, Vector3 position, Vector3 rotation, bool dynamic)
        {
            Prop prop = CreatePropNoOffset(model, position, dynamic);
            if (prop != null)
            {
                prop.Rotation = rotation;
            }
            return prop;
        }

        public static Ped CreateRandomPed(Vector3 position)
        {
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z };
            return new Ped(Function.Call<int>(Hash.CREATE_RANDOM_PED, arguments));
        }

        public static unsafe Vehicle CreateRandomVehicle(Vector3 position, float heading = 0f)
        {
            int num;
            int num2;
            InputArgument[] arguments = new InputArgument[] { 1, (IntPtr) &num, (IntPtr) &num2 };
            Function.Call(Hash.GET_RANDOM_VEHICLE_MODEL_IN_MEMORY, arguments);
            Model model = num;
            if (!model.IsVehicle || !model.IsLoaded)
            {
                return null;
            }
            InputArgument[] argumentArray2 = new InputArgument[] { model.Hash, position.X, position.Y, position.Z, heading, false, false };
            return new Vehicle(Function.Call<int>(Hash.CREATE_VEHICLE, argumentArray2));
        }

        public static Vehicle CreateVehicle(Model model, Vector3 position, float heading = 0f)
        {
            if (!model.IsVehicle || !model.Request(0x3e8))
            {
                return null;
            }
            InputArgument[] arguments = new InputArgument[] { model.Hash, position.X, position.Y, position.Z, heading, false, false };
            return new Vehicle(Function.Call<int>(Hash.CREATE_VEHICLE, arguments));
        }

        public static void DestroyAllCameras()
        {
            InputArgument[] arguments = new InputArgument[] { 0 };
            Function.Call(Hash.DESTROY_ALL_CAMS, arguments);
        }

        public static void DrawLightWithRange(Vector3 position, Color color, float range, float intensity)
        {
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, color.R, color.G, color.B, range, intensity };
            Function.Call(Hash.DRAW_LIGHT_WITH_RANGE, arguments);
        }

        public static void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            InputArgument[] arguments = new InputArgument[10];
            arguments[0] = start.X;
            arguments[1] = start.Y;
            arguments[2] = start.Z;
            arguments[3] = end.X;
            arguments[4] = end.Y;
            arguments[5] = end.Z;
            arguments[6] = color.R;
            arguments[7] = color.G;
            arguments[8] = color.B;
            arguments[9] = color.A;
            Function.Call(Hash.DRAW_LINE, arguments);
        }

        public static void DrawMarker(MarkerType type, Vector3 pos, Vector3 dir, Vector3 rot, Vector3 scale, Color color, bool bobUpAndDown = false, bool faceCamera = false, bool rotateY = false, string textueDict = null, string textureName = null, bool drawOnEntity = false)
        {
            if (!string.IsNullOrEmpty(textueDict) && !string.IsNullOrEmpty(textureName))
            {
                InputArgument[] arguments = new InputArgument[0x18];
                arguments[0] = type;
                arguments[1] = pos.X;
                arguments[2] = pos.Y;
                arguments[3] = pos.Z;
                arguments[4] = dir.X;
                arguments[5] = dir.Y;
                arguments[6] = dir.Z;
                arguments[7] = rot.X;
                arguments[8] = rot.Y;
                arguments[9] = rot.Z;
                arguments[10] = scale.X;
                arguments[11] = scale.Y;
                arguments[12] = scale.Z;
                arguments[13] = color.R;
                arguments[14] = color.G;
                arguments[15] = color.B;
                arguments[0x10] = color.A;
                arguments[0x11] = bobUpAndDown;
                arguments[0x12] = faceCamera;
                arguments[0x13] = 2;
                arguments[20] = rotateY;
                arguments[0x15] = textueDict;
                arguments[0x16] = textureName;
                arguments[0x17] = drawOnEntity;
                Function.Call(Hash.DRAW_MARKER, arguments);
            }
            else
            {
                InputArgument[] arguments = new InputArgument[0x18];
                arguments[0] = type;
                arguments[1] = pos.X;
                arguments[2] = pos.Y;
                arguments[3] = pos.Z;
                arguments[4] = dir.X;
                arguments[5] = dir.Y;
                arguments[6] = dir.Z;
                arguments[7] = rot.X;
                arguments[8] = rot.Y;
                arguments[9] = rot.Z;
                arguments[10] = scale.X;
                arguments[11] = scale.Y;
                arguments[12] = scale.Z;
                arguments[13] = color.R;
                arguments[14] = color.G;
                arguments[15] = color.B;
                arguments[0x10] = color.A;
                arguments[0x11] = bobUpAndDown;
                arguments[0x12] = faceCamera;
                arguments[0x13] = 2;
                arguments[20] = rotateY;
                arguments[0x15] = 0;
                arguments[0x16] = 0;
                arguments[0x17] = drawOnEntity;
                Function.Call(Hash.DRAW_MARKER, arguments);
            }
        }

        public static void DrawPoly(Vector3 vertexA, Vector3 vertexB, Vector3 vertexC, Color color)
        {
            InputArgument[] arguments = new InputArgument[13];
            arguments[0] = vertexA.X;
            arguments[1] = vertexA.Y;
            arguments[2] = vertexA.Z;
            arguments[3] = vertexB.X;
            arguments[4] = vertexB.Y;
            arguments[5] = vertexB.Z;
            arguments[6] = vertexC.X;
            arguments[7] = vertexC.Y;
            arguments[8] = vertexC.Z;
            arguments[9] = color.R;
            arguments[10] = color.G;
            arguments[11] = color.B;
            arguments[12] = color.A;
            Function.Call(Hash.DRAW_POLY, arguments);
        }

        public static void DrawSpotLight(Vector3 pos, Vector3 dir, Color color, float distance, float brightness, float roundness, float radius, float fadeout)
        {
            InputArgument[] arguments = new InputArgument[14];
            arguments[0] = pos.X;
            arguments[1] = pos.Y;
            arguments[2] = pos.Z;
            arguments[3] = dir.X;
            arguments[4] = dir.Y;
            arguments[5] = dir.Z;
            arguments[6] = color.R;
            arguments[7] = color.G;
            arguments[8] = color.B;
            arguments[9] = distance;
            arguments[10] = brightness;
            arguments[11] = roundness;
            arguments[12] = radius;
            arguments[13] = fadeout;
            Function.Call(Hash.DRAW_SPOT_LIGHT, arguments);
        }

        public static void DrawSpotLightWithShadow(Vector3 pos, Vector3 dir, Color color, float distance, float brightness, float roundness, float radius, float fadeout)
        {
            InputArgument[] arguments = new InputArgument[14];
            arguments[0] = pos.X;
            arguments[1] = pos.Y;
            arguments[2] = pos.Z;
            arguments[3] = dir.X;
            arguments[4] = dir.Y;
            arguments[5] = dir.Z;
            arguments[6] = color.R;
            arguments[7] = color.G;
            arguments[8] = color.B;
            arguments[9] = distance;
            arguments[10] = brightness;
            arguments[11] = roundness;
            arguments[12] = radius;
            arguments[13] = fadeout;
            Function.Call(Hash._DRAW_SPOT_LIGHT_WITH_SHADOW, arguments);
        }

        public static Blip[] GetAllBlips(params BlipSprite[] blipTypes)
        {
            List<Blip> list = new List<Blip>();
            if (blipTypes.Length == 0)
            {
                blipTypes = Enum.GetValues(typeof(BlipSprite)).Cast<BlipSprite>().ToArray<BlipSprite>();
            }
            BlipSprite[] spriteArray = blipTypes;
            int index = 0;
            while (index < spriteArray.Length)
            {
                BlipSprite sprite = spriteArray[index];
                InputArgument[] arguments = new InputArgument[] { sprite };
                int handle = Function.Call<int>(Hash.GET_FIRST_BLIP_INFO_ID, arguments);
                while (true)
                {
                    InputArgument[] argumentArray3 = new InputArgument[] { handle };
                    if (!Function.Call<bool>(Hash.DOES_BLIP_EXIST, argumentArray3))
                    {
                        index++;
                        break;
                    }
                    list.Add(new Blip(handle));
                    InputArgument[] argumentArray2 = new InputArgument[] { sprite };
                    handle = Function.Call<int>(Hash.GET_NEXT_BLIP_INFO_ID, argumentArray2);
                }
            }
            return list.ToArray();
        }

        public static Checkpoint[] GetAllCheckpoints()
        {
            Converter<int, Checkpoint> converter = <>c.<>9__37_0;
            if (<>c.<>9__37_0 == null)
            {
                Converter<int, Checkpoint> local1 = <>c.<>9__37_0;
                converter = <>c.<>9__37_0 = element => new Checkpoint(element);
            }
            return Array.ConvertAll<int, Checkpoint>(MemoryAccess.GetCheckpointHandles(), converter);
        }

        public static Entity[] GetAllEntities() => 
            Array.ConvertAll<int, Entity>(MemoryAccess.GetEntityHandles(), new Converter<int, Entity>(Entity.FromHandle));

        public static Ped[] GetAllPeds(params Model[] models)
        {
            Converter<int, Ped> converter = <>c.<>9__39_0;
            if (<>c.<>9__39_0 == null)
            {
                Converter<int, Ped> local1 = <>c.<>9__39_0;
                converter = <>c.<>9__39_0 = handle => new Ped(handle);
            }
            return Array.ConvertAll<int, Ped>(MemoryAccess.GetPedHandles(ModelListToHashList(models)), converter);
        }

        public static Prop[] GetAllPickupObjects()
        {
            Converter<int, Prop> converter = <>c.<>9__54_0;
            if (<>c.<>9__54_0 == null)
            {
                Converter<int, Prop> local1 = <>c.<>9__54_0;
                converter = <>c.<>9__54_0 = handle => new Prop(handle);
            }
            return Array.ConvertAll<int, Prop>(MemoryAccess.GetPickupObjectHandles(), converter);
        }

        public static Prop[] GetAllProps(params Model[] models)
        {
            Converter<int, Prop> converter = <>c.<>9__49_0;
            if (<>c.<>9__49_0 == null)
            {
                Converter<int, Prop> local1 = <>c.<>9__49_0;
                converter = <>c.<>9__49_0 = handle => new Prop(handle);
            }
            return Array.ConvertAll<int, Prop>(MemoryAccess.GetPropHandles(ModelListToHashList(models)), converter);
        }

        public static Vehicle[] GetAllVehicles(params Model[] models)
        {
            Converter<int, Vehicle> converter = <>c.<>9__45_0;
            if (<>c.<>9__45_0 == null)
            {
                Converter<int, Vehicle> local1 = <>c.<>9__45_0;
                converter = <>c.<>9__45_0 = handle => new Vehicle(handle);
            }
            return Array.ConvertAll<int, Vehicle>(MemoryAccess.GetVehicleHandles(ModelListToHashList(models)), converter);
        }

        public static T GetClosest<T>(Vector2 position, params T[] spatials) where T: ISpatial
        {
            ISpatial spatial = null;
            float num3 = 3E+38f;
            Vector3 vector = new Vector3(position.X, position.Y, 0f);
            foreach (T local in spatials)
            {
                float num2 = vector.DistanceToSquared2D(local.Position);
                if (num2 <= num3)
                {
                    spatial = local;
                    num3 = num2;
                }
            }
            return (T) spatial;
        }

        public static T GetClosest<T>(Vector3 position, params T[] spatials) where T: ISpatial
        {
            ISpatial spatial = null;
            float num3 = 3E+38f;
            foreach (T local in spatials)
            {
                float num2 = position.DistanceToSquared(local.Position);
                if (num2 <= num3)
                {
                    spatial = local;
                    num3 = num2;
                }
            }
            return (T) spatial;
        }

        public static Ped GetClosestPed(Vector3 position, float radius, params Model[] models)
        {
            Converter<int, Ped> converter = <>c.<>9__42_0;
            if (<>c.<>9__42_0 == null)
            {
                Converter<int, Ped> local1 = <>c.<>9__42_0;
                converter = <>c.<>9__42_0 = handle => new Ped(handle);
            }
            Ped[] spatials = Array.ConvertAll<int, Ped>(MemoryAccess.GetPedHandles(position, radius, ModelListToHashList(models)), converter);
            return GetClosest<Ped>(position, spatials);
        }

        public static Prop GetClosestPickupObject(Vector3 position, float radius)
        {
            Converter<int, Prop> converter = <>c.<>9__56_0;
            if (<>c.<>9__56_0 == null)
            {
                Converter<int, Prop> local1 = <>c.<>9__56_0;
                converter = <>c.<>9__56_0 = handle => new Prop(handle);
            }
            Prop[] spatials = Array.ConvertAll<int, Prop>(MemoryAccess.GetPickupObjectHandles(position, radius), converter);
            return GetClosest<Prop>(position, spatials);
        }

        public static Prop GetClosestProp(Vector3 position, float radius, params Model[] models)
        {
            Converter<int, Prop> converter = <>c.<>9__51_0;
            if (<>c.<>9__51_0 == null)
            {
                Converter<int, Prop> local1 = <>c.<>9__51_0;
                converter = <>c.<>9__51_0 = handle => new Prop(handle);
            }
            Prop[] spatials = Array.ConvertAll<int, Prop>(MemoryAccess.GetPropHandles(position, radius, ModelListToHashList(models)), converter);
            return GetClosest<Prop>(position, spatials);
        }

        public static Vehicle GetClosestVehicle(Vector3 position, float radius, params Model[] models)
        {
            Converter<int, Vehicle> converter = <>c.<>9__48_0;
            if (<>c.<>9__48_0 == null)
            {
                Converter<int, Vehicle> local1 = <>c.<>9__48_0;
                converter = <>c.<>9__48_0 = handle => new Vehicle(handle);
            }
            Vehicle[] spatials = Array.ConvertAll<int, Vehicle>(MemoryAccess.GetVehicleHandles(position, radius, ModelListToHashList(models)), converter);
            return GetClosest<Vehicle>(position, spatials);
        }

        public static RaycastResult GetCrosshairCoordinates() => 
            Raycast(GameplayCamera.Position, GameplayCamera.GetOffsetPosition(new Vector3(0f, 1000f, 0f)), IntersectOptions.Everything, null);

        public static RaycastResult GetCrosshairCoordinates(Entity ignoreEntity) => 
            Raycast(GameplayCamera.Position, GameplayCamera.GetOffsetPosition(new Vector3(0f, 1000f, 0f)), IntersectOptions.Everything, ignoreEntity);

        public static float GetDistance(Vector3 origin, Vector3 destination)
        {
            InputArgument[] arguments = new InputArgument[] { origin.X, origin.Y, origin.Z, destination.X, destination.Y, destination.Z, 1 };
            return Function.Call<float>(Hash.GET_DISTANCE_BETWEEN_COORDS, arguments);
        }

        public static float GetGroundHeight(Vector2 position) => 
            GetGroundHeight(new Vector3(position.X, position.Y, 1000f));

        public static unsafe float GetGroundHeight(Vector3 position)
        {
            float num;
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, (IntPtr) &num, false };
            Function.Call(Hash.GET_GROUND_Z_FOR_3D_COORD, arguments);
            return num;
        }

        public static Entity[] GetNearbyEntities(Vector3 position, float radius) => 
            Array.ConvertAll<int, Entity>(MemoryAccess.GetEntityHandles(position, radius), new Converter<int, Entity>(Entity.FromHandle));

        public static Ped[] GetNearbyPeds(Vector3 position, float radius, params Model[] models)
        {
            Converter<int, Ped> converter = <>c.<>9__40_0;
            if (<>c.<>9__40_0 == null)
            {
                Converter<int, Ped> local1 = <>c.<>9__40_0;
                converter = <>c.<>9__40_0 = handle => new Ped(handle);
            }
            return Array.ConvertAll<int, Ped>(MemoryAccess.GetPedHandles(position, radius, ModelListToHashList(models)), converter);
        }

        public static Ped[] GetNearbyPeds(Ped ped, float radius, params Model[] models)
        {
            List<Ped> list = new List<Ped>();
            foreach (int num2 in MemoryAccess.GetPedHandles(ped.Position, radius, ModelListToHashList(models)))
            {
                if (num2 != ped.Handle)
                {
                    list.Add(new Ped(num2));
                }
            }
            return list.ToArray();
        }

        public static Prop[] GetNearbyPickupObjects(Vector3 position, float radius)
        {
            Converter<int, Prop> converter = <>c.<>9__55_0;
            if (<>c.<>9__55_0 == null)
            {
                Converter<int, Prop> local1 = <>c.<>9__55_0;
                converter = <>c.<>9__55_0 = handle => new Prop(handle);
            }
            return Array.ConvertAll<int, Prop>(MemoryAccess.GetPickupObjectHandles(position, radius), converter);
        }

        public static Prop[] GetNearbyProps(Vector3 position, float radius, params Model[] models)
        {
            Converter<int, Prop> converter = <>c.<>9__50_0;
            if (<>c.<>9__50_0 == null)
            {
                Converter<int, Prop> local1 = <>c.<>9__50_0;
                converter = <>c.<>9__50_0 = handle => new Prop(handle);
            }
            return Array.ConvertAll<int, Prop>(MemoryAccess.GetPropHandles(position, radius, ModelListToHashList(models)), converter);
        }

        public static Vehicle[] GetNearbyVehicles(Vector3 position, float radius, params Model[] models)
        {
            Converter<int, Vehicle> converter = <>c.<>9__46_0;
            if (<>c.<>9__46_0 == null)
            {
                Converter<int, Vehicle> local1 = <>c.<>9__46_0;
                converter = <>c.<>9__46_0 = handle => new Vehicle(handle);
            }
            return Array.ConvertAll<int, Vehicle>(MemoryAccess.GetVehicleHandles(position, radius, ModelListToHashList(models)), converter);
        }

        public static Vehicle[] GetNearbyVehicles(Ped ped, float radius, params Model[] models)
        {
            List<Vehicle> list = new List<Vehicle>();
            Vehicle currentVehicle = ped.CurrentVehicle;
            int num3 = Vehicle.Exists(currentVehicle) ? currentVehicle.Handle : 0;
            foreach (int num2 in MemoryAccess.GetVehicleHandles(ped.Position, radius, ModelListToHashList(models)))
            {
                if (num2 != num3)
                {
                    list.Add(new Vehicle(num2));
                }
            }
            return list.ToArray();
        }

        public static Vector3 GetNextPositionOnSidewalk(Vector2 position) => 
            GetNextPositionOnSidewalk(new Vector3(position.X, position.Y, 0f));

        public static unsafe Vector3 GetNextPositionOnSidewalk(Vector3 position)
        {
            NativeVector3 vector;
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, true, (IntPtr) &vector, 0 };
            if (Function.Call<bool>(Hash.GET_SAFE_COORD_FOR_PED, arguments))
            {
                return (Vector3) vector;
            }
            InputArgument[] argumentArray2 = new InputArgument[] { position.X, position.Y, position.Z, false, (IntPtr) &vector, 0 };
            return (!Function.Call<bool>(Hash.GET_SAFE_COORD_FOR_PED, argumentArray2) ? Vector3.Zero : ((Vector3) vector));
        }

        public static Vector3 GetNextPositionOnStreet(Vector2 position, bool unoccupied = false) => 
            GetNextPositionOnStreet(new Vector3(position.X, position.Y, 0f), unoccupied);

        public static unsafe Vector3 GetNextPositionOnStreet(Vector3 position, bool unoccupied = false)
        {
            NativeVector3 vector;
            if (!unoccupied)
            {
                InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, 1, (IntPtr) &vector, 1, 0x40400000, 0 };
                if (Function.Call<bool>(Hash.GET_NTH_CLOSEST_VEHICLE_NODE, arguments))
                {
                    return (Vector3) vector;
                }
            }
            else
            {
                for (int i = 1; i < 40; i++)
                {
                    InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, i, (IntPtr) &vector, 1, 0x40400000, 0 };
                    Function.Call(Hash.GET_NTH_CLOSEST_VEHICLE_NODE, arguments);
                    position = (Vector3) vector;
                    InputArgument[] argumentArray2 = new InputArgument[] { position.X, position.Y, position.Z, 5f, 5f, 5f, 0 };
                    if (!Function.Call<bool>(Hash.IS_POINT_OBSCURED_BY_A_MISSION_ENTITY, argumentArray2))
                    {
                        return position;
                    }
                }
            }
            return Vector3.Zero;
        }

        public static unsafe Vector3 GetSafeCoordForPed(Vector3 position, bool sidewalk = true, int flags = 0)
        {
            NativeVector3 vector;
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, sidewalk, (IntPtr) &vector, flags };
            return (!Function.Call<bool>(Hash.GET_SAFE_COORD_FOR_PED, arguments) ? Vector3.Zero : ((Vector3) vector));
        }

        public static string GetStreetName(Vector2 position) => 
            GetStreetName(new Vector3(position.X, position.Y, 0f));

        public static unsafe string GetStreetName(Vector3 position)
        {
            int num;
            int num2;
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, (IntPtr) &num, (IntPtr) &num2 };
            Function.Call(Hash.GET_STREET_NAME_AT_COORD, arguments);
            InputArgument[] argumentArray2 = new InputArgument[] { num };
            return Function.Call<string>(Hash.GET_STREET_NAME_FROM_HASH_KEY, argumentArray2);
        }

        public static Blip GetWaypointBlip()
        {
            if (!Game.IsWaypointActive)
            {
                return null;
            }
            int num2 = Function.Call<int>(Hash._GET_BLIP_INFO_ID_ITERATOR, Array.Empty<InputArgument>());
            InputArgument[] arguments = new InputArgument[] { num2 };
            int handle = Function.Call<int>(Hash.GET_FIRST_BLIP_INFO_ID, arguments);
            while (true)
            {
                InputArgument[] argumentArray4 = new InputArgument[] { handle };
                if (!Function.Call<bool>(Hash.DOES_BLIP_EXIST, argumentArray4))
                {
                    return null;
                }
                InputArgument[] argumentArray2 = new InputArgument[] { handle };
                if (Function.Call<int>(Hash.GET_BLIP_INFO_ID_TYPE, argumentArray2) == 4)
                {
                    return new Blip(handle);
                }
                InputArgument[] argumentArray3 = new InputArgument[] { num2 };
                handle = Function.Call<int>(Hash.GET_NEXT_BLIP_INFO_ID, argumentArray3);
            }
        }

        public static string GetZoneDisplayName(Vector2 position) => 
            GetZoneDisplayName(new Vector3(position.X, position.Y, 0f));

        public static string GetZoneDisplayName(Vector3 position)
        {
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z };
            return Function.Call<string>(Hash.GET_NAME_OF_ZONE, arguments);
        }

        public static string GetZoneLocalizedName(Vector2 position) => 
            GetZoneLocalizedName(new Vector3(position.X, position.Y, 0f));

        public static string GetZoneLocalizedName(Vector3 position) => 
            Game.GetGXTEntry(GetZoneDisplayName(position));

        private static int[] ModelListToHashList(Model[] models)
        {
            Converter<Model, int> converter = <>c.<>9__38_0;
            if (<>c.<>9__38_0 == null)
            {
                Converter<Model, int> local1 = <>c.<>9__38_0;
                converter = <>c.<>9__38_0 = model => model.Hash;
            }
            return Array.ConvertAll<Model, int>(models, converter);
        }

        public static void PauseClock(bool value)
        {
            InputArgument[] arguments = new InputArgument[] { value };
            Function.Call(Hash.PAUSE_CLOCK, arguments);
        }

        public static RaycastResult Raycast(Vector3 source, Vector3 target, IntersectOptions options, Entity ignoreEntity = null)
        {
            InputArgument[] argumentArray1 = new InputArgument[9];
            argumentArray1[0] = source.X;
            argumentArray1[1] = source.Y;
            argumentArray1[2] = source.Z;
            argumentArray1[3] = target.X;
            argumentArray1[4] = target.Y;
            argumentArray1[5] = target.Z;
            argumentArray1[6] = options;
            argumentArray1[7] = (ignoreEntity == null) ? 0 : ignoreEntity.Handle;
            InputArgument[] arguments = argumentArray1;
            arguments[8] = 7;
            return new RaycastResult(Function.Call<int>(Hash._START_SHAPE_TEST_RAY, arguments));
        }

        public static RaycastResult Raycast(Vector3 source, Vector3 direction, float maxDistance, IntersectOptions options, Entity ignoreEntity = null)
        {
            Vector3 vector = source + (direction * maxDistance);
            InputArgument[] argumentArray1 = new InputArgument[9];
            argumentArray1[0] = source.X;
            argumentArray1[1] = source.Y;
            argumentArray1[2] = source.Z;
            argumentArray1[3] = vector.X;
            argumentArray1[4] = vector.Y;
            argumentArray1[5] = vector.Z;
            argumentArray1[6] = options;
            argumentArray1[7] = (ignoreEntity == null) ? 0 : ignoreEntity.Handle;
            InputArgument[] arguments = argumentArray1;
            arguments[8] = 7;
            return new RaycastResult(Function.Call<int>(Hash._START_SHAPE_TEST_RAY, arguments));
        }

        public static RaycastResult RaycastCapsule(Vector3 source, Vector3 target, float radius, IntersectOptions options, Entity ignoreEntity = null)
        {
            InputArgument[] argumentArray1 = new InputArgument[10];
            argumentArray1[0] = source.X;
            argumentArray1[1] = source.Y;
            argumentArray1[2] = source.Z;
            argumentArray1[3] = target.X;
            argumentArray1[4] = target.Y;
            argumentArray1[5] = target.Z;
            argumentArray1[6] = radius;
            argumentArray1[7] = options;
            argumentArray1[8] = (ignoreEntity == null) ? 0 : ignoreEntity.Handle;
            InputArgument[] arguments = argumentArray1;
            arguments[9] = 7;
            return new RaycastResult(Function.Call<int>(Hash.START_SHAPE_TEST_CAPSULE, arguments));
        }

        public static RaycastResult RaycastCapsule(Vector3 source, Vector3 direction, float maxDistance, float radius, IntersectOptions options, Entity ignoreEntity = null)
        {
            Vector3 vector = source + (direction * maxDistance);
            InputArgument[] argumentArray1 = new InputArgument[10];
            argumentArray1[0] = source.X;
            argumentArray1[1] = source.Y;
            argumentArray1[2] = source.Z;
            argumentArray1[3] = vector.X;
            argumentArray1[4] = vector.Y;
            argumentArray1[5] = vector.Z;
            argumentArray1[6] = radius;
            argumentArray1[7] = options;
            argumentArray1[8] = (ignoreEntity == null) ? 0 : ignoreEntity.Handle;
            InputArgument[] arguments = argumentArray1;
            arguments[9] = 7;
            return new RaycastResult(Function.Call<int>(Hash.START_SHAPE_TEST_CAPSULE, arguments));
        }

        public static void RemoveAllParticleEffectsInRange(Vector3 pos, float range)
        {
            InputArgument[] arguments = new InputArgument[] { pos.X, pos.Y, pos.Z, range };
            Function.Call(Hash.REMOVE_PARTICLE_FX_IN_RANGE, arguments);
        }

        public static void RemoveWaypoint()
        {
            Function.Call(Hash.SET_WAYPOINT_OFF, Array.Empty<InputArgument>());
        }

        public static void ShootBullet(Vector3 sourcePosition, Vector3 targetPosition, Ped owner, WeaponAsset weaponAsset, int damage, float speed = -1f)
        {
            InputArgument[] argumentArray1 = new InputArgument[13];
            argumentArray1[0] = sourcePosition.X;
            argumentArray1[1] = sourcePosition.Y;
            argumentArray1[2] = sourcePosition.Z;
            argumentArray1[3] = targetPosition.X;
            argumentArray1[4] = targetPosition.Y;
            argumentArray1[5] = targetPosition.Z;
            argumentArray1[6] = damage;
            argumentArray1[7] = 1;
            argumentArray1[8] = weaponAsset.Hash;
            argumentArray1[9] = (owner == null) ? 0 : owner.Handle;
            InputArgument[] arguments = argumentArray1;
            arguments[10] = 1;
            arguments[11] = 0;
            arguments[12] = speed;
            Function.Call(Hash.SHOOT_SINGLE_BULLET_BETWEEN_COORDS, arguments);
        }

        public static void TransitionToWeather(GTA.Weather weather, float duration)
        {
            if (Enum.IsDefined(typeof(GTA.Weather), weather) && (weather != GTA.Weather.Unknown))
            {
                InputArgument[] arguments = new InputArgument[] { _weatherNames[(int) weather], duration };
                Function.Call(Hash._SET_WEATHER_TYPE_OVER_TIME, arguments);
            }
        }

        public static DateTime CurrentDate
        {
            get => 
                new DateTime(Function.Call<int>(Hash.GET_CLOCK_YEAR, Array.Empty<InputArgument>()), Function.Call<int>(Hash.GET_CLOCK_MONTH, Array.Empty<InputArgument>()), Function.Call<int>(Hash.GET_CLOCK_DAY_OF_MONTH, Array.Empty<InputArgument>()), Function.Call<int>(Hash.GET_CLOCK_HOURS, Array.Empty<InputArgument>()), Function.Call<int>(Hash.GET_CLOCK_MINUTES, Array.Empty<InputArgument>()), Function.Call<int>(Hash.GET_CLOCK_SECONDS, Array.Empty<InputArgument>()), new GTACalender());
            set
            {
                InputArgument[] arguments = new InputArgument[] { value.Year, value.Month, value.Day };
                Function.Call(Hash.SET_CLOCK_DATE, arguments);
                InputArgument[] argumentArray2 = new InputArgument[] { value.Hour, value.Minute, value.Second };
                Function.Call(Hash.SET_CLOCK_TIME, argumentArray2);
            }
        }

        public static TimeSpan CurrentTimeOfDay
        {
            get => 
                new TimeSpan(Function.Call<int>(Hash.GET_CLOCK_HOURS, Array.Empty<InputArgument>()), Function.Call<int>(Hash.GET_CLOCK_MINUTES, Array.Empty<InputArgument>()), Function.Call<int>(Hash.GET_CLOCK_SECONDS, Array.Empty<InputArgument>()));
            set
            {
                InputArgument[] arguments = new InputArgument[] { value.Hours, value.Minutes, value.Seconds };
                Function.Call(Hash.SET_CLOCK_TIME, arguments);
            }
        }

        public static bool Blackout
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash._SET_BLACKOUT, arguments);
            }
        }

        public static GTA.Weather Weather
        {
            get
            {
                for (int i = 0; i < _weatherNames.Length; i++)
                {
                    if (Function.Call<int>(Hash.GET_PREV_WEATHER_TYPE_HASH_NAME, Array.Empty<InputArgument>()) == Game.GenerateHash(_weatherNames[i]))
                    {
                        return (GTA.Weather) i;
                    }
                }
                return GTA.Weather.Unknown;
            }
            set
            {
                if (Enum.IsDefined(typeof(GTA.Weather), value) && (value != GTA.Weather.Unknown))
                {
                    InputArgument[] arguments = new InputArgument[] { _weatherNames[(int) value] };
                    Function.Call(Hash.SET_WEATHER_TYPE_NOW, arguments);
                }
            }
        }

        public static GTA.Weather NextWeather
        {
            get
            {
                for (int i = 0; i < _weatherNames.Length; i++)
                {
                    InputArgument[] arguments = new InputArgument[] { _weatherNames[i] };
                    if (Function.Call<bool>(Hash.IS_NEXT_WEATHER_TYPE, arguments))
                    {
                        return (GTA.Weather) i;
                    }
                }
                return GTA.Weather.Unknown;
            }
            set
            {
                if (Enum.IsDefined(typeof(GTA.Weather), value) && (value != GTA.Weather.Unknown))
                {
                    int num;
                    float num2;
                    int num3;
                    InputArgument[] arguments = new InputArgument[] { (IntPtr) &num, (IntPtr) &num3, (IntPtr) &num2 };
                    Function.Call(Hash._GET_WEATHER_TYPE_TRANSITION, arguments);
                    InputArgument[] argumentArray2 = new InputArgument[] { num, Game.GenerateHash(_weatherNames[(int) value]), 0f };
                    Function.Call(Hash._SET_WEATHER_TYPE_TRANSITION, argumentArray2);
                }
            }
        }

        public static float WeatherTransition
        {
            get
            {
                float num;
                int num2;
                int num3;
                InputArgument[] arguments = new InputArgument[] { (IntPtr) &num3, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash._GET_WEATHER_TYPE_TRANSITION, arguments);
                return num;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { 0, 0, value };
                Function.Call(Hash._SET_WEATHER_TYPE_TRANSITION, arguments);
            }
        }

        public static float GravityLevel
        {
            get => 
                MemoryAccess.ReadWorldGravity();
            set
            {
                MemoryAccess.WriteWorldGravity(value);
                InputArgument[] arguments = new InputArgument[] { 0 };
                Function.Call(Hash.SET_GRAVITY_LEVEL, arguments);
                MemoryAccess.WriteWorldGravity(9.8f);
            }
        }

        public static Camera RenderingCamera
        {
            get => 
                new Camera(Function.Call<int>(Hash.GET_RENDERING_CAM, Array.Empty<InputArgument>()));
            set
            {
                if (value == null)
                {
                    InputArgument[] arguments = new InputArgument[] { false, 0, 0xbb8, 1, 0 };
                    Function.Call(Hash.RENDER_SCRIPT_CAMS, arguments);
                }
                else
                {
                    value.IsActive = true;
                    InputArgument[] arguments = new InputArgument[] { true, 0, 0xbb8, 1, 0 };
                    Function.Call(Hash.RENDER_SCRIPT_CAMS, arguments);
                }
            }
        }

        public static Vector3 WaypointPosition
        {
            get
            {
                Blip waypointBlip = GetWaypointBlip();
                if (waypointBlip == null)
                {
                    return Vector3.Zero;
                }
                Vector3 position = waypointBlip.Position;
                float num = 0f;
                InputArgument[] arguments = new InputArgument[] { position.X, position.Y, 1000f, (IntPtr) &num };
                if (Function.Call<bool>(Hash.GET_GROUND_Z_FOR_3D_COORD, arguments))
                {
                    position.Z = num;
                }
                return position;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { value.X, value.Y };
                Function.Call(Hash.SET_NEW_WAYPOINT, arguments);
            }
        }

        public static int VehicleCount =>
            MemoryAccess.GetNumberOfVehicles();

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly World.<>c <>9 = new World.<>c();
            public static Converter<int, Checkpoint> <>9__37_0;
            public static Converter<Model, int> <>9__38_0;
            public static Converter<int, Ped> <>9__39_0;
            public static Converter<int, Ped> <>9__40_0;
            public static Converter<int, Ped> <>9__42_0;
            public static Converter<int, Vehicle> <>9__45_0;
            public static Converter<int, Vehicle> <>9__46_0;
            public static Converter<int, Vehicle> <>9__48_0;
            public static Converter<int, Prop> <>9__49_0;
            public static Converter<int, Prop> <>9__50_0;
            public static Converter<int, Prop> <>9__51_0;
            public static Converter<int, Prop> <>9__54_0;
            public static Converter<int, Prop> <>9__55_0;
            public static Converter<int, Prop> <>9__56_0;

            internal Checkpoint <GetAllCheckpoints>b__37_0(int element) => 
                new Checkpoint(element);

            internal Ped <GetAllPeds>b__39_0(int handle) => 
                new Ped(handle);

            internal Prop <GetAllPickupObjects>b__54_0(int handle) => 
                new Prop(handle);

            internal Prop <GetAllProps>b__49_0(int handle) => 
                new Prop(handle);

            internal Vehicle <GetAllVehicles>b__45_0(int handle) => 
                new Vehicle(handle);

            internal Ped <GetClosestPed>b__42_0(int handle) => 
                new Ped(handle);

            internal Prop <GetClosestPickupObject>b__56_0(int handle) => 
                new Prop(handle);

            internal Prop <GetClosestProp>b__51_0(int handle) => 
                new Prop(handle);

            internal Vehicle <GetClosestVehicle>b__48_0(int handle) => 
                new Vehicle(handle);

            internal Ped <GetNearbyPeds>b__40_0(int handle) => 
                new Ped(handle);

            internal Prop <GetNearbyPickupObjects>b__55_0(int handle) => 
                new Prop(handle);

            internal Prop <GetNearbyProps>b__50_0(int handle) => 
                new Prop(handle);

            internal Vehicle <GetNearbyVehicles>b__46_0(int handle) => 
                new Vehicle(handle);

            internal int <ModelListToHashList>b__38_0(Model model) => 
                model.Hash;
        }
    }
}

