// Decompiled with JetBrains decompiler
// Type: GTA.World
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace GTA
{
  public static class World
  {
    internal static readonly string[] _weatherNames = new string[14]
    {
      "EXTRASUNNY",
      "CLEAR",
      "CLOUDS",
      "SMOG",
      "FOGGY",
      "OVERCAST",
      "RAIN",
      "THUNDER",
      "CLEARING",
      "NEUTRAL",
      "SNOW",
      "BLIZZARD",
      "SNOWLIGHT",
      "XMAS"
    };

    public static DateTime CurrentDate
    {
      get
      {
        int year = Function.Call<int>(Hash.GET_CLOCK_YEAR, (InputArgument[]) Array.Empty<InputArgument>());
        int num1 = Function.Call<int>(Hash.GET_CLOCK_MONTH, (InputArgument[]) Array.Empty<InputArgument>());
        int num2 = Function.Call<int>(Hash.GET_CLOCK_DAY_OF_MONTH, (InputArgument[]) Array.Empty<InputArgument>());
        int num3 = Function.Call<int>(Hash.GET_CLOCK_HOURS, (InputArgument[]) Array.Empty<InputArgument>());
        int num4 = Function.Call<int>(Hash.GET_CLOCK_MINUTES, (InputArgument[]) Array.Empty<InputArgument>());
        int num5 = Function.Call<int>(Hash.GET_CLOCK_SECONDS, (InputArgument[]) Array.Empty<InputArgument>());
        int month = num1;
        int day = num2;
        int hour = num3;
        int minute = num4;
        int second = num5;
        GTACalender gtaCalender = new GTACalender();
        return new DateTime(year, month, day, hour, minute, second, (Calendar) gtaCalender);
      }
      set
      {
        Function.Call(Hash.SET_CLOCK_DATE, (InputArgument) value.Year, (InputArgument) value.Month, (InputArgument) value.Day);
        Function.Call(Hash.SET_CLOCK_TIME, (InputArgument) value.Hour, (InputArgument) value.Minute, (InputArgument) value.Second);
      }
    }

    public static TimeSpan CurrentTimeOfDay
    {
      get
      {
        int hours = Function.Call<int>(Hash.GET_CLOCK_HOURS, (InputArgument[]) Array.Empty<InputArgument>());
        int num1 = Function.Call<int>(Hash.GET_CLOCK_MINUTES, (InputArgument[]) Array.Empty<InputArgument>());
        int num2 = Function.Call<int>(Hash.GET_CLOCK_SECONDS, (InputArgument[]) Array.Empty<InputArgument>());
        int minutes = num1;
        int seconds = num2;
        return new TimeSpan(hours, minutes, seconds);
      }
      set => Function.Call(Hash.SET_CLOCK_TIME, (InputArgument) value.Hours, (InputArgument) value.Minutes, (InputArgument) value.Seconds);
    }

    public static void PauseClock(bool value) => Function.Call(Hash.PAUSE_CLOCK, (InputArgument) value);

    public static bool Blackout
    {
      set => Function.Call(Hash._SET_BLACKOUT, (InputArgument) value);
    }

    public static Weather Weather
    {
      get
      {
        for (int index = 0; index < World._weatherNames.Length; ++index)
        {
          if (Function.Call<int>(Hash.GET_PREV_WEATHER_TYPE_HASH_NAME, (InputArgument[]) Array.Empty<InputArgument>()) == Game.GenerateHash(World._weatherNames[index]))
            return (Weather) index;
        }
        return Weather.Unknown;
      }
      set
      {
        if (!Enum.IsDefined(typeof (Weather), (object) value) || value == Weather.Unknown)
          return;
        Function.Call(Hash.SET_WEATHER_TYPE_NOW, (InputArgument) World._weatherNames[(int) value]);
      }
    }

    public static unsafe Weather NextWeather
    {
      get
      {
        for (int index = 0; index < World._weatherNames.Length; ++index)
        {
          if (Function.Call<bool>(Hash.IS_NEXT_WEATHER_TYPE, (InputArgument) World._weatherNames[index]))
            return (Weather) index;
        }
        return Weather.Unknown;
      }
      set
      {
        if (!Enum.IsDefined(typeof (Weather), (object) value) || value == Weather.Unknown)
          return;
        int num1;
        int num2;
        float num3;
        Function.Call(Hash._GET_WEATHER_TYPE_TRANSITION, (InputArgument) (void*) &num1, (InputArgument) (void*) &num2, (InputArgument) (void*) &num3);
        Function.Call(Hash._SET_WEATHER_TYPE_TRANSITION, (InputArgument) num1, (InputArgument) Game.GenerateHash(World._weatherNames[(int) value]), (InputArgument) 0.0f);
      }
    }

    public static unsafe float WeatherTransition
    {
      get
      {
        int num1;
        int num2;
        float num3;
        Function.Call(Hash._GET_WEATHER_TYPE_TRANSITION, (InputArgument) (void*) &num1, (InputArgument) (void*) &num2, (InputArgument) (void*) &num3);
        return num3;
      }
      set => Function.Call(Hash._SET_WEATHER_TYPE_TRANSITION, (InputArgument) 0, (InputArgument) 0, (InputArgument) value);
    }

    public static void TransitionToWeather(Weather weather, float duration)
    {
      if (!Enum.IsDefined(typeof (Weather), (object) weather) || weather == Weather.Unknown)
        return;
      Function.Call(Hash._SET_WEATHER_TYPE_OVER_TIME, (InputArgument) World._weatherNames[(int) weather], (InputArgument) duration);
    }

    public static float GravityLevel
    {
      get => MemoryAccess.ReadWorldGravity();
      set
      {
        MemoryAccess.WriteWorldGravity(value);
        Function.Call(Hash.SET_GRAVITY_LEVEL, (InputArgument) 0);
        MemoryAccess.WriteWorldGravity(9.8f);
      }
    }

    public static Camera RenderingCamera
    {
      get => new Camera(Function.Call<int>(Hash.GET_RENDERING_CAM, (InputArgument[]) Array.Empty<InputArgument>()));
      set
      {
        if (value == (Camera) null)
        {
          Function.Call(Hash.RENDER_SCRIPT_CAMS, (InputArgument) false, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        }
        else
        {
          value.IsActive = true;
          Function.Call(Hash.RENDER_SCRIPT_CAMS, (InputArgument) true, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        }
      }
    }

    public static void DestroyAllCameras() => Function.Call(Hash.DESTROY_ALL_CAMS, (InputArgument) 0);

    public static unsafe Vector3 WaypointPosition
    {
      get
      {
        Blip waypointBlip = World.GetWaypointBlip();
        if (waypointBlip == (Blip) null)
          return Vector3.Zero;
        Vector3 position = waypointBlip.Position;
        float num = 0.0f;
        if (Function.Call<bool>(Hash.GET_GROUND_Z_FOR_3D_COORD, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) 1000f, (InputArgument) (void*) &num))
          position.Z = num;
        return position;
      }
      set => Function.Call(Hash.SET_NEW_WAYPOINT, (InputArgument) value.X, (InputArgument) value.Y);
    }

    public static Blip GetWaypointBlip()
    {
      if (!Game.IsWaypointActive)
        return (Blip) null;
      int num = Function.Call<int>(Hash._GET_BLIP_INFO_ID_ITERATOR, (InputArgument[]) Array.Empty<InputArgument>());
      int handle = Function.Call<int>(Hash.GET_FIRST_BLIP_INFO_ID, (InputArgument) num);
      while (true)
      {
        if (Function.Call<bool>(Hash.DOES_BLIP_EXIST, (InputArgument) handle))
        {
          if (Function.Call<int>(Hash.GET_BLIP_INFO_ID_TYPE, (InputArgument) handle) != 4)
            handle = Function.Call<int>(Hash.GET_NEXT_BLIP_INFO_ID, (InputArgument) num);
          else
            break;
        }
        else
          goto label_7;
      }
      return new Blip(handle);
label_7:
      return (Blip) null;
    }

    public static void RemoveWaypoint() => Function.Call(Hash.SET_WAYPOINT_OFF, (InputArgument[]) Array.Empty<InputArgument>());

    public static float GetDistance(Vector3 origin, Vector3 destination) => Function.Call<float>(Hash.GET_DISTANCE_BETWEEN_COORDS, (InputArgument) origin.X, (InputArgument) origin.Y, (InputArgument) origin.Z, (InputArgument) destination.X, (InputArgument) destination.Y, (InputArgument) destination.Z, (InputArgument) 1);

    public static float CalculateTravelDistance(Vector3 origin, Vector3 destination) => Function.Call<float>(Hash.CALCULATE_TRAVEL_DISTANCE_BETWEEN_POINTS, (InputArgument) origin.X, (InputArgument) origin.Y, (InputArgument) origin.Z, (InputArgument) destination.X, (InputArgument) destination.Y, (InputArgument) destination.Z);

    public static unsafe float GetGroundHeight(Vector3 position)
    {
      float num;
      Function.Call(Hash.GET_GROUND_Z_FOR_3D_COORD, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) (void*) &num, (InputArgument) false);
      return num;
    }

    public static float GetGroundHeight(Vector2 position) => World.GetGroundHeight(new Vector3(position.X, position.Y, 1000f));

    public static Blip[] GetAllBlips(params BlipSprite[] blipTypes)
    {
      List<Blip> blipList = new List<Blip>();
      if (blipTypes.Length == 0)
        blipTypes = Enum.GetValues(typeof (BlipSprite)).Cast<BlipSprite>().ToArray<BlipSprite>();
      foreach (BlipSprite blipType in blipTypes)
      {
        int handle = Function.Call<int>(Hash.GET_FIRST_BLIP_INFO_ID, (InputArgument) (Enum) blipType);
        while (true)
        {
          if (Function.Call<bool>(Hash.DOES_BLIP_EXIST, (InputArgument) handle))
          {
            blipList.Add(new Blip(handle));
            handle = Function.Call<int>(Hash.GET_NEXT_BLIP_INFO_ID, (InputArgument) (Enum) blipType);
          }
          else
            break;
        }
      }
      return blipList.ToArray();
    }

    public static Checkpoint[] GetAllCheckpoints() => Array.ConvertAll<int, Checkpoint>(MemoryAccess.GetCheckpointHandles(), (Converter<int, Checkpoint>) (element => new Checkpoint(element)));

    private static int[] ModelListToHashList(Model[] models) => Array.ConvertAll<Model, int>(models, (Converter<Model, int>) (model => model.Hash));

    public static Ped[] GetAllPeds(params Model[] models) => Array.ConvertAll<int, Ped>(MemoryAccess.GetPedHandles(World.ModelListToHashList(models)), (Converter<int, Ped>) (handle => new Ped(handle)));

    public static Ped[] GetNearbyPeds(Vector3 position, float radius, params Model[] models) => Array.ConvertAll<int, Ped>(MemoryAccess.GetPedHandles(position, radius, World.ModelListToHashList(models)), (Converter<int, Ped>) (handle => new Ped(handle)));

    public static Ped[] GetNearbyPeds(Ped ped, float radius, params Model[] models)
    {
      int[] pedHandles = MemoryAccess.GetPedHandles(ped.Position, radius, World.ModelListToHashList(models));
      List<Ped> pedList = new List<Ped>();
      foreach (int handle in pedHandles)
      {
        if (handle != ped.Handle)
          pedList.Add(new Ped(handle));
      }
      return pedList.ToArray();
    }

    public static Ped GetClosestPed(Vector3 position, float radius, params Model[] models)
    {
      Ped[] pedArray = Array.ConvertAll<int, Ped>(MemoryAccess.GetPedHandles(position, radius, World.ModelListToHashList(models)), (Converter<int, Ped>) (handle => new Ped(handle)));
      return World.GetClosest<Ped>(position, pedArray);
    }

    public static int VehicleCount => MemoryAccess.GetNumberOfVehicles();

    public static Vehicle[] GetAllVehicles(params Model[] models) => Array.ConvertAll<int, Vehicle>(MemoryAccess.GetVehicleHandles(World.ModelListToHashList(models)), (Converter<int, Vehicle>) (handle => new Vehicle(handle)));

    public static Vehicle[] GetNearbyVehicles(
      Vector3 position,
      float radius,
      params Model[] models)
    {
      return Array.ConvertAll<int, Vehicle>(MemoryAccess.GetVehicleHandles(position, radius, World.ModelListToHashList(models)), (Converter<int, Vehicle>) (handle => new Vehicle(handle)));
    }

    public static Vehicle[] GetNearbyVehicles(Ped ped, float radius, params Model[] models)
    {
      int[] vehicleHandles = MemoryAccess.GetVehicleHandles(ped.Position, radius, World.ModelListToHashList(models));
      List<Vehicle> vehicleList = new List<Vehicle>();
      Vehicle currentVehicle = ped.CurrentVehicle;
      int num = Vehicle.Exists(currentVehicle) ? currentVehicle.Handle : 0;
      foreach (int handle in vehicleHandles)
      {
        if (handle != num)
          vehicleList.Add(new Vehicle(handle));
      }
      return vehicleList.ToArray();
    }

    public static Vehicle GetClosestVehicle(
      Vector3 position,
      float radius,
      params Model[] models)
    {
      Vehicle[] vehicleArray = Array.ConvertAll<int, Vehicle>(MemoryAccess.GetVehicleHandles(position, radius, World.ModelListToHashList(models)), (Converter<int, Vehicle>) (handle => new Vehicle(handle)));
      return World.GetClosest<Vehicle>(position, vehicleArray);
    }

    public static Prop[] GetAllProps(params Model[] models) => Array.ConvertAll<int, Prop>(MemoryAccess.GetPropHandles(World.ModelListToHashList(models)), (Converter<int, Prop>) (handle => new Prop(handle)));

    public static Prop[] GetNearbyProps(Vector3 position, float radius, params Model[] models) => Array.ConvertAll<int, Prop>(MemoryAccess.GetPropHandles(position, radius, World.ModelListToHashList(models)), (Converter<int, Prop>) (handle => new Prop(handle)));

    public static Prop GetClosestProp(Vector3 position, float radius, params Model[] models)
    {
      Prop[] propArray = Array.ConvertAll<int, Prop>(MemoryAccess.GetPropHandles(position, radius, World.ModelListToHashList(models)), (Converter<int, Prop>) (handle => new Prop(handle)));
      return World.GetClosest<Prop>(position, propArray);
    }

    public static Entity[] GetAllEntities() => Array.ConvertAll<int, Entity>(MemoryAccess.GetEntityHandles(), new Converter<int, Entity>(Entity.FromHandle));

    public static Entity[] GetNearbyEntities(Vector3 position, float radius) => Array.ConvertAll<int, Entity>(MemoryAccess.GetEntityHandles(position, radius), new Converter<int, Entity>(Entity.FromHandle));

    public static Prop[] GetAllPickupObjects() => Array.ConvertAll<int, Prop>(MemoryAccess.GetPickupObjectHandles(), (Converter<int, Prop>) (handle => new Prop(handle)));

    public static Prop[] GetNearbyPickupObjects(Vector3 position, float radius) => Array.ConvertAll<int, Prop>(MemoryAccess.GetPickupObjectHandles(position, radius), (Converter<int, Prop>) (handle => new Prop(handle)));

    public static Prop GetClosestPickupObject(Vector3 position, float radius)
    {
      Prop[] propArray = Array.ConvertAll<int, Prop>(MemoryAccess.GetPickupObjectHandles(position, radius), (Converter<int, Prop>) (handle => new Prop(handle)));
      return World.GetClosest<Prop>(position, propArray);
    }

    public static T GetClosest<T>(Vector3 position, params T[] spatials) where T : ISpatial
    {
      ISpatial spatial1 = (ISpatial) null;
      float num = 3E+38f;
      foreach (T spatial2 in spatials)
      {
        float squared = position.DistanceToSquared(spatial2.Position);
        if ((double) squared <= (double) num)
        {
          spatial1 = (ISpatial) spatial2;
          num = squared;
        }
      }
      return (T) spatial1;
    }

    public static T GetClosest<T>(Vector2 position, params T[] spatials) where T : ISpatial
    {
      ISpatial spatial1 = (ISpatial) null;
      float num = 3E+38f;
      Vector3 vector3 = new Vector3(position.X, position.Y, 0.0f);
      foreach (T spatial2 in spatials)
      {
        float squared2D = vector3.DistanceToSquared2D(spatial2.Position);
        if ((double) squared2D <= (double) num)
        {
          spatial1 = (ISpatial) spatial2;
          num = squared2D;
        }
      }
      return (T) spatial1;
    }

    public static unsafe Vector3 GetSafeCoordForPed(
      Vector3 position,
      bool sidewalk = true,
      int flags = 0)
    {
      NativeVector3 nativeVector3;
      return Function.Call<bool>(Hash.GET_SAFE_COORD_FOR_PED, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) sidewalk, (InputArgument) (void*) &nativeVector3, (InputArgument) flags) ? (Vector3) nativeVector3 : Vector3.Zero;
    }

    public static Vector3 GetNextPositionOnStreet(Vector2 position, bool unoccupied = false) => World.GetNextPositionOnStreet(new Vector3(position.X, position.Y, 0.0f), unoccupied);

    public static unsafe Vector3 GetNextPositionOnStreet(Vector3 position, bool unoccupied = false)
    {
      if (unoccupied)
      {
        for (int index = 1; index < 40; ++index)
        {
          NativeVector3 nativeVector3;
          Function.Call(Hash.GET_NTH_CLOSEST_VEHICLE_NODE, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) index, (InputArgument) (void*) &nativeVector3, (InputArgument) 1, (InputArgument) 1077936128, (InputArgument) 0);
          position = (Vector3) nativeVector3;
          if (!Function.Call<bool>(Hash.IS_POINT_OBSCURED_BY_A_MISSION_ENTITY, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 5f, (InputArgument) 5f, (InputArgument) 5f, (InputArgument) 0))
            return position;
        }
      }
      else
      {
        NativeVector3 nativeVector3;
        if (Function.Call<bool>(Hash.GET_NTH_CLOSEST_VEHICLE_NODE, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 1, (InputArgument) (void*) &nativeVector3, (InputArgument) 1, (InputArgument) 1077936128, (InputArgument) 0))
          return (Vector3) nativeVector3;
      }
      return Vector3.Zero;
    }

    public static Vector3 GetNextPositionOnSidewalk(Vector2 position) => World.GetNextPositionOnSidewalk(new Vector3(position.X, position.Y, 0.0f));

    public static unsafe Vector3 GetNextPositionOnSidewalk(Vector3 position)
    {
      NativeVector3 nativeVector3;
      if (Function.Call<bool>(Hash.GET_SAFE_COORD_FOR_PED, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) true, (InputArgument) (void*) &nativeVector3, (InputArgument) 0))
        return (Vector3) nativeVector3;
      return Function.Call<bool>(Hash.GET_SAFE_COORD_FOR_PED, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) false, (InputArgument) (void*) &nativeVector3, (InputArgument) 0) ? (Vector3) nativeVector3 : Vector3.Zero;
    }

    public static string GetZoneLocalizedName(Vector2 position) => World.GetZoneLocalizedName(new Vector3(position.X, position.Y, 0.0f));

    public static string GetZoneLocalizedName(Vector3 position) => Game.GetGXTEntry(World.GetZoneDisplayName(position));

    public static string GetZoneDisplayName(Vector2 position) => World.GetZoneDisplayName(new Vector3(position.X, position.Y, 0.0f));

    public static string GetZoneDisplayName(Vector3 position) => Function.Call<string>(Hash.GET_NAME_OF_ZONE, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z);

    public static string GetStreetName(Vector2 position) => World.GetStreetName(new Vector3(position.X, position.Y, 0.0f));

    public static unsafe string GetStreetName(Vector3 position)
    {
      int num1;
      int num2;
      Function.Call(Hash.GET_STREET_NAME_AT_COORD, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) (void*) &num1, (InputArgument) (void*) &num2);
      return Function.Call<string>(Hash.GET_STREET_NAME_FROM_HASH_KEY, (InputArgument) num1);
    }

    public static Blip CreateBlip(Vector3 position) => new Blip(Function.Call<int>(Hash.ADD_BLIP_FOR_COORD, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z));

    public static Blip CreateBlip(Vector3 position, float radius) => new Blip(Function.Call<int>(Hash.ADD_BLIP_FOR_RADIUS, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) radius));

    public static Camera CreateCamera(Vector3 position, Vector3 rotation, float fov) => new Camera(Function.Call<int>(Hash.CREATE_CAM_WITH_PARAMS, (InputArgument) "DEFAULT_SCRIPTED_CAMERA", (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) rotation.X, (InputArgument) rotation.Y, (InputArgument) rotation.Z, (InputArgument) fov, (InputArgument) 1, (InputArgument) 2));

    public static Ped CreatePed(Model model, Vector3 position, float heading = 0.0f)
    {
      if (!model.IsPed || !model.Request(1000))
        return (Ped) null;
      return new Ped(Function.Call<int>(Hash.CREATE_PED, (InputArgument) 26, (InputArgument) model.Hash, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) heading, (InputArgument) false, (InputArgument) false));
    }

    public static Ped CreateRandomPed(Vector3 position) => new Ped(Function.Call<int>(Hash.CREATE_RANDOM_PED, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z));

    public static Vehicle CreateVehicle(Model model, Vector3 position, float heading = 0.0f)
    {
      if (!model.IsVehicle || !model.Request(1000))
        return (Vehicle) null;
      return new Vehicle(Function.Call<int>(Hash.CREATE_VEHICLE, (InputArgument) model.Hash, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) heading, (InputArgument) false, (InputArgument) false));
    }

    public static unsafe Vehicle CreateRandomVehicle(Vector3 position, float heading = 0.0f)
    {
      int num1;
      int num2;
      Function.Call(Hash.GET_RANDOM_VEHICLE_MODEL_IN_MEMORY, (InputArgument) 1, (InputArgument) (void*) &num1, (InputArgument) (void*) &num2);
      Model model = (Model) num1;
      if (!model.IsVehicle || !model.IsLoaded)
        return (Vehicle) null;
      return new Vehicle(Function.Call<int>(Hash.CREATE_VEHICLE, (InputArgument) model.Hash, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) heading, (InputArgument) false, (InputArgument) false));
    }

    public static Prop CreateProp(
      Model model,
      Vector3 position,
      bool dynamic,
      bool placeOnGround)
    {
      if (!model.Request(1000))
        return (Prop) null;
      if (placeOnGround)
        position.Z = World.GetGroundHeight(position);
      return new Prop(Function.Call<int>(Hash.CREATE_OBJECT, (InputArgument) model.Hash, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 1, (InputArgument) 1, (InputArgument) dynamic));
    }

    public static Prop CreateProp(
      Model model,
      Vector3 position,
      Vector3 rotation,
      bool dynamic,
      bool placeOnGround)
    {
      Prop prop = World.CreateProp(model, position, dynamic, placeOnGround);
      if ((Entity) prop != (Entity) null)
        prop.Rotation = rotation;
      return prop;
    }

    public static Prop CreatePropNoOffset(Model model, Vector3 position, bool dynamic)
    {
      if (!model.Request(1000))
        return (Prop) null;
      return new Prop(Function.Call<int>(Hash.CREATE_OBJECT_NO_OFFSET, (InputArgument) model.Hash, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 1, (InputArgument) 1, (InputArgument) dynamic));
    }

    public static Prop CreatePropNoOffset(
      Model model,
      Vector3 position,
      Vector3 rotation,
      bool dynamic)
    {
      Prop propNoOffset = World.CreatePropNoOffset(model, position, dynamic);
      if ((Entity) propNoOffset != (Entity) null)
        propNoOffset.Rotation = rotation;
      return propNoOffset;
    }

    public static Pickup CreatePickup(
      PickupType type,
      Vector3 position,
      Model model,
      int value)
    {
      if (!model.Request(1000))
        return (Pickup) null;
      int handle = Function.Call<int>(Hash.CREATE_PICKUP, (InputArgument) (Enum) type, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 0, (InputArgument) value, (InputArgument) true, (InputArgument) model.Hash);
      return handle == 0 ? (Pickup) null : new Pickup(handle);
    }

    public static Pickup CreatePickup(
      PickupType type,
      Vector3 position,
      Vector3 rotation,
      Model model,
      int value)
    {
      if (!model.Request(1000))
        return (Pickup) null;
      int handle = Function.Call<int>(Hash.CREATE_PICKUP_ROTATE, (InputArgument) (Enum) type, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) rotation.X, (InputArgument) rotation.Y, (InputArgument) rotation.Z, (InputArgument) 0, (InputArgument) value, (InputArgument) 2, (InputArgument) true, (InputArgument) model.Hash);
      return handle == 0 ? (Pickup) null : new Pickup(handle);
    }

    public static Prop CreateAmbientPickup(
      PickupType type,
      Vector3 position,
      Model model,
      int value)
    {
      if (!model.Request(1000))
        return (Prop) null;
      int handle = Function.Call<int>(Hash.CREATE_AMBIENT_PICKUP, (InputArgument) (Enum) type, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 0, (InputArgument) value, (InputArgument) model.Hash, (InputArgument) false, (InputArgument) true);
      return handle == 0 ? (Prop) null : new Prop(handle);
    }

    public static Checkpoint CreateCheckpoint(
      CheckpointIcon icon,
      Vector3 position,
      Vector3 pointTo,
      float radius,
      Color color)
    {
      int handle = Function.Call<int>(Hash.CREATE_CHECKPOINT, (InputArgument) (Enum) icon, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) pointTo.X, (InputArgument) pointTo.Y, (InputArgument) pointTo.Z, (InputArgument) radius, (InputArgument) color.R, (InputArgument) color.G, (InputArgument) color.B, (InputArgument) color.A, (InputArgument) 0);
      return handle == 0 ? (Checkpoint) null : new Checkpoint(handle);
    }

    public static Checkpoint CreateCheckpoint(
      CheckpointCustomIcon icon,
      Vector3 position,
      Vector3 pointTo,
      float radius,
      Color color)
    {
      int handle = Function.Call<int>(Hash.CREATE_CHECKPOINT, (InputArgument) 42, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) pointTo.X, (InputArgument) pointTo.Y, (InputArgument) pointTo.Z, (InputArgument) radius, (InputArgument) color.R, (InputArgument) color.G, (InputArgument) color.B, (InputArgument) color.A, (InputArgument) icon);
      return handle == 0 ? (Checkpoint) null : new Checkpoint(handle);
    }

    public static Rope AddRope(
      RopeType type,
      Vector3 position,
      Vector3 rotation,
      float length,
      float minLength,
      bool breakable)
    {
      Function.Call(Hash.ROPE_LOAD_TEXTURES, (InputArgument[]) Array.Empty<InputArgument>());
      return new Rope(Function.Call<int>(Hash.ADD_ROPE, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) rotation.X, (InputArgument) rotation.Y, (InputArgument) rotation.Z, (InputArgument) length, (InputArgument) (Enum) type, (InputArgument) length, (InputArgument) minLength, (InputArgument) 0.5f, (InputArgument) false, (InputArgument) false, (InputArgument) true, (InputArgument) 1f, (InputArgument) breakable, (InputArgument) 0));
    }

    public static void ShootBullet(
      Vector3 sourcePosition,
      Vector3 targetPosition,
      Ped owner,
      WeaponAsset weaponAsset,
      int damage,
      float speed = -1f)
    {
      Function.Call(Hash.SHOOT_SINGLE_BULLET_BETWEEN_COORDS, (InputArgument) sourcePosition.X, (InputArgument) sourcePosition.Y, (InputArgument) sourcePosition.Z, (InputArgument) targetPosition.X, (InputArgument) targetPosition.Y, (InputArgument) targetPosition.Z, (InputArgument) damage, (InputArgument) 1, (InputArgument) weaponAsset.Hash, (InputArgument) ((Entity) owner == (Entity) null ? 0 : owner.Handle), (InputArgument) 1, (InputArgument) 0, (InputArgument) speed);
    }

    public static void AddExplosion(
      Vector3 position,
      ExplosionType type,
      float radius,
      float cameraShake,
      Ped owner = null,
      bool aubidble = true,
      bool invisible = false)
    {
      if (Entity.Exists((Entity) owner))
        Function.Call(Hash.ADD_OWNED_EXPLOSION, (InputArgument) owner.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) (Enum) type, (InputArgument) radius, (InputArgument) aubidble, (InputArgument) invisible, (InputArgument) cameraShake);
      else
        Function.Call(Hash.ADD_EXPLOSION, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) (Enum) type, (InputArgument) radius, (InputArgument) aubidble, (InputArgument) invisible, (InputArgument) cameraShake);
    }

    public static unsafe RelationshipGroup AddRelationshipGroup(string name)
    {
      int hash;
      Function.Call(Hash.ADD_RELATIONSHIP_GROUP, (InputArgument) name, (InputArgument) (void*) &hash);
      return new RelationshipGroup(hash);
    }

    public static RaycastResult Raycast(
      Vector3 source,
      Vector3 target,
      IntersectOptions options,
      Entity ignoreEntity = null)
    {
      return new RaycastResult(Function.Call<int>(Hash._START_SHAPE_TEST_RAY, (InputArgument) source.X, (InputArgument) source.Y, (InputArgument) source.Z, (InputArgument) target.X, (InputArgument) target.Y, (InputArgument) target.Z, (InputArgument) (Enum) options, (InputArgument) (ignoreEntity == (Entity) null ? 0 : ignoreEntity.Handle), (InputArgument) 7));
    }

    public static RaycastResult Raycast(
      Vector3 source,
      Vector3 direction,
      float maxDistance,
      IntersectOptions options,
      Entity ignoreEntity = null)
    {
      Vector3 vector3 = source + direction * maxDistance;
      return new RaycastResult(Function.Call<int>(Hash._START_SHAPE_TEST_RAY, (InputArgument) source.X, (InputArgument) source.Y, (InputArgument) source.Z, (InputArgument) vector3.X, (InputArgument) vector3.Y, (InputArgument) vector3.Z, (InputArgument) (Enum) options, (InputArgument) (ignoreEntity == (Entity) null ? 0 : ignoreEntity.Handle), (InputArgument) 7));
    }

    public static RaycastResult RaycastCapsule(
      Vector3 source,
      Vector3 target,
      float radius,
      IntersectOptions options,
      Entity ignoreEntity = null)
    {
      return new RaycastResult(Function.Call<int>(Hash.START_SHAPE_TEST_CAPSULE, (InputArgument) source.X, (InputArgument) source.Y, (InputArgument) source.Z, (InputArgument) target.X, (InputArgument) target.Y, (InputArgument) target.Z, (InputArgument) radius, (InputArgument) (Enum) options, (InputArgument) (ignoreEntity == (Entity) null ? 0 : ignoreEntity.Handle), (InputArgument) 7));
    }

    public static RaycastResult RaycastCapsule(
      Vector3 source,
      Vector3 direction,
      float maxDistance,
      float radius,
      IntersectOptions options,
      Entity ignoreEntity = null)
    {
      Vector3 vector3 = source + direction * maxDistance;
      return new RaycastResult(Function.Call<int>(Hash.START_SHAPE_TEST_CAPSULE, (InputArgument) source.X, (InputArgument) source.Y, (InputArgument) source.Z, (InputArgument) vector3.X, (InputArgument) vector3.Y, (InputArgument) vector3.Z, (InputArgument) radius, (InputArgument) (Enum) options, (InputArgument) (ignoreEntity == (Entity) null ? 0 : ignoreEntity.Handle), (InputArgument) 7));
    }

    public static RaycastResult GetCrosshairCoordinates() => World.Raycast(GameplayCamera.Position, GameplayCamera.GetOffsetPosition(new Vector3(0.0f, 1000f, 0.0f)), IntersectOptions.Everything);

    public static RaycastResult GetCrosshairCoordinates(Entity ignoreEntity) => World.Raycast(GameplayCamera.Position, GameplayCamera.GetOffsetPosition(new Vector3(0.0f, 1000f, 0.0f)), IntersectOptions.Everything, ignoreEntity);

    public static void DrawMarker(
      MarkerType type,
      Vector3 pos,
      Vector3 dir,
      Vector3 rot,
      Vector3 scale,
      Color color,
      bool bobUpAndDown = false,
      bool faceCamera = false,
      bool rotateY = false,
      string textueDict = null,
      string textureName = null,
      bool drawOnEntity = false)
    {
      if (!string.IsNullOrEmpty(textueDict) && !string.IsNullOrEmpty(textureName))
        Function.Call(Hash.DRAW_MARKER, (InputArgument) (Enum) type, (InputArgument) pos.X, (InputArgument) pos.Y, (InputArgument) pos.Z, (InputArgument) dir.X, (InputArgument) dir.Y, (InputArgument) dir.Z, (InputArgument) rot.X, (InputArgument) rot.Y, (InputArgument) rot.Z, (InputArgument) scale.X, (InputArgument) scale.Y, (InputArgument) scale.Z, (InputArgument) color.R, (InputArgument) color.G, (InputArgument) color.B, (InputArgument) color.A, (InputArgument) bobUpAndDown, (InputArgument) faceCamera, (InputArgument) 2, (InputArgument) rotateY, (InputArgument) textueDict, (InputArgument) textureName, (InputArgument) drawOnEntity);
      else
        Function.Call(Hash.DRAW_MARKER, (InputArgument) (Enum) type, (InputArgument) pos.X, (InputArgument) pos.Y, (InputArgument) pos.Z, (InputArgument) dir.X, (InputArgument) dir.Y, (InputArgument) dir.Z, (InputArgument) rot.X, (InputArgument) rot.Y, (InputArgument) rot.Z, (InputArgument) scale.X, (InputArgument) scale.Y, (InputArgument) scale.Z, (InputArgument) color.R, (InputArgument) color.G, (InputArgument) color.B, (InputArgument) color.A, (InputArgument) bobUpAndDown, (InputArgument) faceCamera, (InputArgument) 2, (InputArgument) rotateY, (InputArgument) 0, (InputArgument) 0, (InputArgument) drawOnEntity);
    }

    public static void DrawLightWithRange(
      Vector3 position,
      Color color,
      float range,
      float intensity)
    {
      Function.Call(Hash.DRAW_LIGHT_WITH_RANGE, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) color.R, (InputArgument) color.G, (InputArgument) color.B, (InputArgument) range, (InputArgument) intensity);
    }

    public static void DrawSpotLight(
      Vector3 pos,
      Vector3 dir,
      Color color,
      float distance,
      float brightness,
      float roundness,
      float radius,
      float fadeout)
    {
      Function.Call(Hash.DRAW_SPOT_LIGHT, (InputArgument) pos.X, (InputArgument) pos.Y, (InputArgument) pos.Z, (InputArgument) dir.X, (InputArgument) dir.Y, (InputArgument) dir.Z, (InputArgument) color.R, (InputArgument) color.G, (InputArgument) color.B, (InputArgument) distance, (InputArgument) brightness, (InputArgument) roundness, (InputArgument) radius, (InputArgument) fadeout);
    }

    public static void DrawSpotLightWithShadow(
      Vector3 pos,
      Vector3 dir,
      Color color,
      float distance,
      float brightness,
      float roundness,
      float radius,
      float fadeout)
    {
      Function.Call(Hash._DRAW_SPOT_LIGHT_WITH_SHADOW, (InputArgument) pos.X, (InputArgument) pos.Y, (InputArgument) pos.Z, (InputArgument) dir.X, (InputArgument) dir.Y, (InputArgument) dir.Z, (InputArgument) color.R, (InputArgument) color.G, (InputArgument) color.B, (InputArgument) distance, (InputArgument) brightness, (InputArgument) roundness, (InputArgument) radius, (InputArgument) fadeout);
    }

    public static void DrawLine(Vector3 start, Vector3 end, Color color) => Function.Call(Hash.DRAW_LINE, (InputArgument) start.X, (InputArgument) start.Y, (InputArgument) start.Z, (InputArgument) end.X, (InputArgument) end.Y, (InputArgument) end.Z, (InputArgument) color.R, (InputArgument) color.G, (InputArgument) color.B, (InputArgument) color.A);

    public static void DrawPoly(Vector3 vertexA, Vector3 vertexB, Vector3 vertexC, Color color) => Function.Call(Hash.DRAW_POLY, (InputArgument) vertexA.X, (InputArgument) vertexA.Y, (InputArgument) vertexA.Z, (InputArgument) vertexB.X, (InputArgument) vertexB.Y, (InputArgument) vertexB.Z, (InputArgument) vertexC.X, (InputArgument) vertexC.Y, (InputArgument) vertexC.Z, (InputArgument) color.R, (InputArgument) color.G, (InputArgument) color.B, (InputArgument) color.A);

    public static void RemoveAllParticleEffectsInRange(Vector3 pos, float range) => Function.Call(Hash.REMOVE_PARTICLE_FX_IN_RANGE, (InputArgument) pos.X, (InputArgument) pos.Y, (InputArgument) pos.Z, (InputArgument) range);
  }
}
