using UnityEngine;
using System.Reflection;
using System;

public static class ComponentExtentions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Copy the property and values of the another component of the same type, returns the component after copy
    /// Uses Reflection
    /// </summary>
    public static T CopyComponent<T>(this Component comp, T other) where T : Component
    {
        Type type = comp.GetType();

        if (type != other.GetType()) return null;

        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default;
        PropertyInfo[] infos = type.GetProperties(flags);
        foreach (var info in infos)
        {
            if (info.CanWrite)
            {
                try
                {
                    info.SetValue(comp, info.GetValue(other, null), null);
                }
                catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
            }
        }
        FieldInfo[] finfos = type.GetFields(flags);
        foreach (var finfo in finfos)
        {
            finfo.SetValue(comp, finfo.GetValue(other));
        }
        return comp as T;
    }
}
