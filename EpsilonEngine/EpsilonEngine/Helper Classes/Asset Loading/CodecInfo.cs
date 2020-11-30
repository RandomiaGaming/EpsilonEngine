using System;
using System.IO;
using System.Reflection;

namespace EpsilonEngine
{
    public sealed class CodecInfo
    {
        public readonly MethodInfo method = null;
        public readonly string managedExtension = "";
        public CodecInfo(MethodInfo method)
        {
            if(method is null)
            {
                throw new NullReferenceException();
            }
            this.method = method;
            RegisterCodecAttribute attribute = method.GetCustomAttribute<RegisterCodecAttribute>();
            if (attribute is null || attribute.targetExtension is null)
            {
                throw new ArgumentException();
            }
            managedExtension = attribute.targetExtension;
            ParameterInfo[] parameters = method.GetParameters();
            if(parameters is null || parameters.Length != 2)
            {
                throw new ArgumentException();
            }
            if(parameters[0].ParameterType == typeof(Stream) && parameters[0].Name.ToLower() == "stream" && parameters[1].ParameterType == typeof(string) && parameters[1].Name.ToLower() == "name")
            {
                if(method.ReturnType == null || !method.ReturnType.IsAssignableFrom(typeof(AssetBase)))
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public AssetBase DecodeAsset(Stream stream, string name)
        {
            return (AssetBase)method.Invoke(null, new object[] { stream, name });
        }
    }
}
