using System;
using System.Runtime.Serialization;
using UnityEngine;

public static class EnumUtilities
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Try to get enum equivalent from string, return true on success
    /// </summary>
    public static bool TryGetEnum<T>(string enumString, out T enumValue, bool isCaseSensitive = false)
    {
        enumValue = default;

        if (!string.IsNullOrEmpty(enumString))
        {
            var enumType = typeof(T);
            foreach (var enumName in Enum.GetNames(enumType))
            {
                bool checkMatch;
                var fieldInfo = enumType.GetField(enumName);

                // First check enumMember attr
                var enumMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(EnumMemberAttribute));
                checkMatch = enumMemberAttribute != null &&
                    ((isCaseSensitive && enumMemberAttribute.Value == enumString) ||
                    enumMemberAttribute.Value.ToLower() == enumString.ToLower());
                if (checkMatch)
                {
                    enumValue = (T)Enum.Parse(enumType, enumName);
                    return true;
                }

                // Second check unity inspector attr
                var inspectorNameAttribute = (InspectorNameAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(InspectorNameAttribute));
                checkMatch = (inspectorNameAttribute != null) &&
                    ((isCaseSensitive && inspectorNameAttribute.displayName == enumString) ||
                    inspectorNameAttribute.displayName.ToLower() == enumString.ToLower());
                if (checkMatch)
                {
                    enumValue = (T)Enum.Parse(enumType, enumName);
                    return true;
                }

                // Third check direct name
                checkMatch = (isCaseSensitive && enumName == enumString) ||
                    enumName.ToLower() == enumString.ToLower();
                if (checkMatch)
                {
                    enumValue = (T)Enum.Parse(enumType, enumName);
                    return true;
                }
            }
        }

        return false;
    }

    //====================================================================================================
    //====================================================================================================
    
    /// <summary>
    /// Returns a random enum value
    /// </summary>
    public static T RandomValue<T>()
    {
        var values = Enum.GetValues(typeof(T));
        var randomValue = (T)values.GetValue(new System.Random().Next(values.Length));
        return randomValue;
    }
}