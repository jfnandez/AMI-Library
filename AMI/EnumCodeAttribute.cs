using System;

namespace AMI
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class EnumCodeAttribute : Attribute
    {
        public string Code { get; private set; }

        public EnumCodeAttribute(string code)
        {
            Code = code;
        }
    }
}
