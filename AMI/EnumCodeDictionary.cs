using System;
using System.Reflection;
using System.Collections.Generic;

namespace AMI
{
    internal static class EnumCodeDictionary<T>
    {
        public static readonly IReadOnlyDictionary<T, string> Forward;
        public static readonly IReadOnlyDictionary<string, T> Reverse;

        static EnumCodeDictionary()
        {
            var type = typeof(T);
            var items = Enum.GetValues(type);

            var forward = new Dictionary<T, string>(items.Length);
            var reverse = new Dictionary<string, T>(items.Length);

            foreach (T item in items)
            {
                var name = Enum.GetName(type, item);
                var member = type.GetMember(name)[0];
                var attribute = member.GetCustomAttribute<EnumCodeAttribute>();

                forward.Add(item, attribute.Code);
                reverse.Add(attribute.Code, item);
            }

            Forward = forward;
            Reverse = reverse;
        }
    }
}
