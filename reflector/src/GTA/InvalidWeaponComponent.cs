namespace GTA
{
    using System;

    public class InvalidWeaponComponent : WeaponComponent
    {
        internal InvalidWeaponComponent() : base(null, null, (WeaponComponentHash) (-1))
        {
        }

        public override bool Active
        {
            get => 
                false;
            set
            {
            }
        }

        public override string DisplayName =>
            "WCT_INVALID";

        public override string LocalizedName =>
            Game.GetGXTEntry(this.DisplayName);

        public override ComponentAttachmentPoint AttachmentPoint =>
            (ComponentAttachmentPoint) (-1);
    }
}

