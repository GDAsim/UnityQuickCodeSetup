using System;
using System.Runtime.Serialization;
using UnityEngine;

public static class EnumExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns the [EnumMember(Value = "")] on enum if exist, else enum.ToString(); 
    /// </summary>
    public static string GetEnumMemberValue(this Enum enumValue)
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        var enumMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(EnumMemberAttribute));

        string enumMemberValue = enumMemberAttribute?.Value ?? enumValue.ToString();

        return enumMemberValue;
    }

    /// <summary>
    /// Returns the unity [InspectorName()] on enum if exist, else enum.ToString(); 
    /// </summary>
    public static string GetInspectorName(this Enum enumValue)
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        var inspectorNameAttribute = (InspectorNameAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(InspectorNameAttribute));

        string inspectorNameValue = inspectorNameAttribute?.displayName ?? enumValue.ToString();

        return inspectorNameValue;
    }

    //====================================================================================================
    //====================================================================================================
}