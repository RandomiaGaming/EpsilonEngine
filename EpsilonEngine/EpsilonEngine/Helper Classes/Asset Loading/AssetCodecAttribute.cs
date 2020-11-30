using System;

namespace EpsilonEngine
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class RegisterCodecAttribute : Attribute
    {
        public readonly string targetExtension = "";
        public RegisterCodecAttribute(string targetExtension)
        {
            if(targetExtension is null)
            {
                throw new NullReferenceException();
            }
            if(targetExtension == "")
            {
                throw new ArgumentException();
            }
            this.targetExtension = targetExtension.ToUpper();
        }
    }
}