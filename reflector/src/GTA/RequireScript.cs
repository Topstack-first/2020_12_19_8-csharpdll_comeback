namespace GTA
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
    public class RequireScript : Attribute
    {
        internal Type _dependency;

        public RequireScript(Type dependency)
        {
            this._dependency = dependency;
        }
    }
}

