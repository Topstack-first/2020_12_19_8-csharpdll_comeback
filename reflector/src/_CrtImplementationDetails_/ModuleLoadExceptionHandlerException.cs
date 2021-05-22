namespace _CrtImplementationDetails_
{
    using System;
    using System.Runtime.Serialization;
    using System.Security;

    [Serializable]
    internal class ModuleLoadExceptionHandlerException : ModuleLoadException
    {
        private const string formatString = "\n{0}: {1}\n--- Start of primary exception ---\n{2}\n--- End of primary exception ---\n\n--- Start of nested exception ---\n{3}\n--- End of nested exception ---\n";
        private Exception <backing_store>NestedException;

        protected ModuleLoadExceptionHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.NestedException = (Exception) info.GetValue("NestedException", typeof(Exception));
        }

        public ModuleLoadExceptionHandlerException(string message, Exception innerException, Exception nestedException) : base(message, innerException)
        {
            this.NestedException = nestedException;
        }

        [SecurityCritical]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("NestedException", this.NestedException, typeof(Exception));
        }

        public override string ToString()
        {
            string str2 = (this.InnerException == null) ? string.Empty : this.InnerException.ToString();
            string str = (this.NestedException == null) ? string.Empty : this.NestedException.ToString();
            object[] args = new object[] { this.GetType() };
            string str5 = (this.Message == null) ? string.Empty : this.Message;
            args[1] = str5;
            string str4 = (str2 == null) ? string.Empty : str2;
            args[2] = str4;
            string str3 = (str == null) ? string.Empty : str;
            args[3] = str3;
            return string.Format("\n{0}: {1}\n--- Start of primary exception ---\n{2}\n--- End of primary exception ---\n\n--- Start of nested exception ---\n{3}\n--- End of nested exception ---\n", args);
        }

        public Exception NestedException
        {
            get => 
                this.<backing_store>NestedException;
            set => 
                this.<backing_store>NestedException = value;
        }
    }
}

