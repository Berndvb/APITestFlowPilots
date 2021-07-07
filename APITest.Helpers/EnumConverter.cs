using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace APITest.Helpers
{
    public class TolerantEnumConverter : JsonConverter
    {
        ConcurrentDictionary<Type, Dictionary<string, object>> _fromValueMap = new ConcurrentDictionary<Type, Dictionary<string, object>>(); // string representation to Enum value map

        ConcurrentDictionary<Type, Dictionary<object, string>> _toValueMap = new ConcurrentDictionary<Type, Dictionary<object, string>>(); // Enum value to string map

        public string UnknownValue { get; set; } = "Unknown";

        #region JsonConverter

        public override bool CanConvert(Type objectType)
        {
            Type type = IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType;
            return type.GetTypeInfo().IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool isNullable = IsNullableType(objectType);
            Type enumType = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;

            InitMap(enumType);

            if (reader.TokenType == JsonToken.String)
            {
                string enumText = reader.Value.ToString();

                object val = FromValue(enumType, enumText);

                if (val != null)
                    return val;
            }
            else if (reader.TokenType == JsonToken.Integer)
            {
                int enumVal = Convert.ToInt32(reader.Value);
                int[] values = (int[])Enum.GetValues(enumType);
                if (values.Contains(enumVal))
                {
                    return Enum.Parse(enumType, enumVal.ToString());
                }
            }

            if (!isNullable)
            {
                string[] names = Enum.GetNames(enumType);

                string unknownName = names
                    .Where(n => string.Equals(n, UnknownValue, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();

                if (unknownName == null)
                {
                    throw new JsonSerializationException($"Unable to parse '{reader.Value}' to enum {enumType}. Consider adding Unknown as fail-back value.");
                }

                return Enum.Parse(enumType, unknownName);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type enumType = value.GetType();

            InitMap(enumType);

            string val = ToValue(enumType, value);

            writer.WriteValue(val);
        }

        #endregion

        #region Private

        bool IsNullableType(Type t)
        {
            return (t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        void InitMap(Type enumType)
        {
            if (_fromValueMap.ContainsKey(enumType))
                return; // already initialized

            var fromMap = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            var toMap = new Dictionary<object, string>();

            var fields = from p in enumType.GetRuntimeFields()
                         where p.IsPublic && p.IsStatic
                         select p;

            foreach (var field in fields)
            {
                string name = field.Name;
                object enumValue = Enum.Parse(enumType, name);

                // use EnumMember attribute if exists
                var enumMemberAttrbiute = field.GetCustomAttribute<EnumMemberAttribute>();

                if (enumMemberAttrbiute != null)
                {
                    string enumMemberValue = enumMemberAttrbiute.Value;

                    fromMap[enumMemberValue] = enumValue;
                    toMap[enumValue] = enumMemberValue;
                }
                else
                {
                    toMap[enumValue] = name;
                }

                fromMap[name] = enumValue;
            }

            _fromValueMap[enumType] = fromMap;
            _toValueMap[enumType] = toMap;
        }

        string ToValue(Type enumType, object obj)
        {
            var map = _toValueMap[enumType];

            return map[obj];
        }

        object FromValue(Type enumType, string value)
        {
            var map = _fromValueMap[enumType];

            if (!map.ContainsKey(value))
                return null;

            return map[value];
        }

        #endregion
    }
}