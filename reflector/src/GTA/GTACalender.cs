namespace GTA
{
    using System;
    using System.Globalization;

    internal class GTACalender : GregorianCalendar
    {
        public override int GetDaysInMonth(int year, int month, int era) => 
            0x1f;

        public override int GetDaysInYear(int year, int era) => 
            0x174;
    }
}

