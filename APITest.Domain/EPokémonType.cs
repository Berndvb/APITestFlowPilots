using APITest.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace APITest.Domain
{
    [JsonConverter(typeof(TolerantEnumConverter))]
    public enum EPokémonType
    {
        [EnumMember(Value = "Grass")]
        Grass,
        [EnumMember(Value = "Poison")]
        Poison,
        [EnumMember(Value = "Fire")]
        Fire,
        [EnumMember(Value = " Water")]
        Water,
        [EnumMember(Value = "Ghost")]
        Ghost,
        [EnumMember(Value = "Ground")]
        Ground,
        [EnumMember(Value = "Rock")]
        Rock,
        [EnumMember(Value = "Steel")]
        Steel,
        [EnumMember(Value = "Electric")]
        Electric,
        [EnumMember(Value = "Normal")]
        Normal,
        [EnumMember(Value = "Ice")]
        Ice,
        [EnumMember(Value = "Fighting")]
        Fighting,
        [EnumMember(Value = "Flying")]
        Flying,
        [EnumMember(Value = "Dragon")]
        Dragon,
        [EnumMember(Value = "Psychic")]
        Psychic,
        [EnumMember(Value = "Bug")]
        Bug,
        [EnumMember(Value = "Fairy")]
        Fairy,
        [EnumMember(Value = "Dark")]
        Dark
    }
}
