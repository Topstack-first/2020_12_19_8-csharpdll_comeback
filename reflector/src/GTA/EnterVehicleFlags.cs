namespace GTA
{
    using System;

    [Flags]
    public enum EnterVehicleFlags
    {
        None = 0,
        WarpToDoor = 2,
        AllowJacking = 8,
        WarpIn = 0x10,
        EnterFromOppositeSide = 0x40000,
        OnlyOpenDoor = 0x80000
    }
}

