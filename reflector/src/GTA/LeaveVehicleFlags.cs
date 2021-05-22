namespace GTA
{
    using System;

    [Flags]
    public enum LeaveVehicleFlags
    {
        None = 0,
        WarpOut = 0x10,
        LeaveDoorOpen = 0x100,
        BailOut = 0x1000
    }
}

