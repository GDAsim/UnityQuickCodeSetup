using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public static partial class GameObjectExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Add and returns a child gameObject under this gameObject with the specified name and HideFlags
    /// </summary>
    public static GameObject AddEmptyChild(this GameObject parent, string name, HideFlags flags = HideFlags.None)
    {
        GameObject child = new(name);
        child.hideFlags = flags;
        child.transform.parent = parent.transform;
        child.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        child.transform.localScale = Vector3.one;
        return child;
    }

    /// <summary>
    /// Add and returns a parent gameObject to this gameObject with the specified name and HideFlags
    /// </summary>
    public static GameObject AddEmptyParent(this GameObject child, string name, HideFlags flags = HideFlags.None)
    {
        GameObject parent = new(name);
        parent.hideFlags = flags;
        parent.transform.position = child.transform.position;
        parent.transform.rotation = child.transform.rotation;
        parent.transform.localScale = child.transform.lossyScale;
        child.transform.parent = parent.transform;
        child.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        child.transform.localScale = Vector3.one;
        return parent;
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Recursively returns children gameObjects, active or inactive
    /// </summary>
    public static IEnumerable<GameObject> GetChildren(this GameObject parent, bool includeInactive = false)
    {
        var transform = parent.transform;
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            if (includeInactive || child.activeInHierarchy)
            {
                yield return child;
            }
        }
    }

    /// <summary>
    /// Destroy all children
    /// </summary>
    public static void DestroyAllChildren(this GameObject gameObject)
    {
        foreach (var child in gameObject.GetChildren(true))
        {
            Object.Destroy(child);
        }
    }

    /// <summary>
    /// Destroy all children in edit mode
    /// </summary>
    public static void DestroyAllChildrenImmediate(this GameObject gameObject)
    {
        foreach (var child in gameObject.GetChildren(true))
        {
            Object.DestroyImmediate(child);
        }
    }

    /// <summary>
    /// Destroy active children
    /// </summary>
    public static void DestroyActiveChildren(this GameObject gameObject)
    {
        foreach (var child in gameObject.GetChildren())
        {
            Object.Destroy(child);
        }

    }

    /// <summary>
    /// Destroy active children Immediate
    /// </summary>
    public static void DestroyActiveChildrenImmediate(this GameObject gameObject)
    {
        foreach (var child in gameObject.GetChildren())
        {
            Object.DestroyImmediate(child);
        }
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Gets the parent with a certain name 
    /// </summary>
    public static GameObject FindParentWithName(this GameObject child, string name)
    {
        Transform currentParent = child.transform.parent;
        while (currentParent != null)
        {
            if (currentParent.name == name)
            {
                return currentParent.gameObject;
            }
            currentParent = currentParent.parent;
        }
        return null;
    }

    /// <summary>
    /// Gets the child gameObject with certain name
    /// </summary>
    public static GameObject FindChildWithName(this GameObject inside, string name)
    {
        foreach (Transform child in inside.transform)
        {
            if (child.name == name)
            {
                return child.gameObject;
            }
        }
        return null;
    }

    /// <summary>
    /// Gets the child gameObject with certain name recurisvely Breadth-first search
    /// </summary>
    public static Transform FindDeepChild_BFS(this Transform t, string childName)
    {
        Queue<Transform> queue = new();

        queue.Enqueue(t);

        while (queue.Count > 0)
        {
            var parent = queue.Dequeue();
                
            foreach (Transform child in parent)
            {
                if (child.name == childName) return child;

                queue.Enqueue(child);
            }
        }

        return null;
    }

    /// <summary>
    /// Gets the child gameObject with certain name recurisvely Depth-first search
    /// </summary>
    public static Transform FindDeepChild_DFS(this Transform t, string childName)
    {
        Stack<Transform> stack = new();

        stack.Push(t);

        while (stack.Count > 0)
        {
            var parent = stack.Pop();

            foreach (Transform child in parent)
            {
                if (child.name == childName) return child;

                stack.Push(child);
            }
        }

        return null;
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Get Bounds from gameobject renderer component
    /// </summary>
    public static Bounds? GetRenderBounds(this GameObject go)
    {
        if (!go.TryGetComponent<Renderer>(out var render)) return null;
        return render.bounds;
    }

    /// <summary>
    /// Get Bounds from gameobject collider component
    /// </summary>
    public static Bounds? GetColliderBounds(this GameObject go)
    {
        if (!go.TryGetComponent<Collider>(out var collider)) return null;
        return collider.bounds;
    }

    /// <summary>
    /// Get bounds from gameobject collider or renderer with collider being the priority
    /// </summary>
    public static Bounds? GetAnyBounds(this GameObject go)
    {
        if (go.TryGetComponent(out Collider collider)) return collider.bounds;

        if (go.TryGetComponent(out Renderer render)) return render.bounds;

        return null;
    }

    /// <summary>
    /// Get Bounds from gameobject renderer component + all children renderer component
    /// </summary>
    public static Bounds? GetTotalRenderBounds(this GameObject go)
    {
        Bounds? bounds = GetRenderBounds(go);

        foreach (Transform child in go.transform)
        {
            if (bounds.HasValue == false)
            {
                bounds = GetTotalRenderBounds(child.gameObject);
            }
            else
            {
                Bounds? childBounds = GetTotalRenderBounds(child.gameObject);
                if (childBounds.HasValue)
                {
                    Bounds btemp = bounds.Value;
                    btemp.Encapsulate(childBounds.Value);
                    bounds = btemp;
                }
            }
        }

        return bounds;
    }

    /// <summary>
    /// Get Bounds from gameobject collider component + all children collider component
    /// </summary>
    public static Bounds? GetTotalColliderBounds(this GameObject go)
    {
        Bounds? bounds = GetColliderBounds(go);

        foreach (Transform child in go.transform)
        {
            if (bounds.HasValue == false)
            {
                bounds = GetTotalColliderBounds(child.gameObject);
            }
            else
            {
                Bounds? childBounds = GetTotalColliderBounds(child.gameObject);
                if (childBounds.HasValue)
                {
                    Bounds btemp = bounds.Value;
                    btemp.Encapsulate(childBounds.Value);
                    bounds = btemp;
                }
            }
        }

        return bounds;
    }

    /// <summary>
    /// Get Bounds from gameobject collider/renderer component + all children collider/renderer component
    /// </summary>
    public static Bounds? GetTotalAnyBounds(this GameObject go)
    {
        Bounds? bounds = GetAnyBounds(go);

        foreach (Transform child in go.transform)
        {
            if (bounds.HasValue == false)
            {
                bounds = GetTotalAnyBounds(child.gameObject);
            }
            else
            {
                Bounds? childBounds = GetTotalAnyBounds(child.gameObject);
                if (childBounds.HasValue)
                {
                    Bounds btemp = bounds.Value;
                    btemp.Encapsulate(childBounds.Value);
                    bounds = btemp;
                }
            }
        }

        return bounds;
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Get the first Component in direct children only
    /// </summary>
    public static T GetComponentInDirectChildren<T>(this GameObject go, bool includeInactive = false) where T : Component
    {
        foreach (Transform child in go.transform)
        {
            if (includeInactive || child.gameObject.activeInHierarchy)
            {
                if (child.TryGetComponent<T>(out var component))
                {
                    return component;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// Get all Components in direct children only
    /// </summary>
    public static T[] GetComponentsInDirectChildren<T>(this GameObject go, bool includeInactive = false) where T : Component
    {
        List<T> tempList = new();
        foreach (Transform child in go.transform)
        {
            if (includeInactive || child.gameObject.activeInHierarchy)
            {
                tempList.AddRange(child.GetComponents<T>());
            }
        }
        return tempList.ToArray();
    }

    /// <summary>
    /// Get the first Component in sibilings in heirachy order
    /// </summary>
    public static T GetComponentInSiblings<T>(this GameObject go, bool includeInactive = false) where T : Component
    {
        var transform = go.transform;
        var parent = transform.parent;

        if (parent == null) return null;

        foreach (Transform child in parent)
        {
            if (includeInactive || transform.gameObject.activeInHierarchy)
            {
                if (child != transform)
                {
                    if (transform.TryGetComponent<T>(out var component))
                    {
                        return component;
                    }
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Get the Components in sibilings in heirachy order
    /// </summary>
    public static T[] GetComponentsInSiblings<T>(this GameObject go, bool includeInactive) where T : Component
    {
        var transform = go.transform;
        var parent = transform.parent;

        if (parent == null) return null;

        List<T> tempList = new();
        foreach (Transform child in parent)
        {
            if (includeInactive || child.gameObject.activeInHierarchy)
            {
                if (child != transform)
                {
                    tempList.AddRange(child.GetComponents<T>());
                }
            }
        }
        return tempList.ToArray();
    }

    /// <summary>
    /// Get the Component in direct parent only
    /// </summary>
    public static T GetComponentInDirectParent<T>(this GameObject child) where T : Component
    {
        Transform parent = child.transform.parent;

        if (parent == null) return null;

        return parent.GetComponent<T>();
    }

    /// <summary>
    /// Get the Components in direct parent only
    /// </summary>
    public static T[] GetComponentsInDirectParent<T>(this GameObject child) where T : Component
    {
        Transform parent = child.transform.parent;

        if (parent == null) return null;

        return parent.GetComponents<T>();
    }

    /// <summary>
    /// Returns the names of all the components attached to this gameObject
    /// </summary>
    public static string[] GetComponentsNames(this GameObject go)
    {
        return go.GetComponents<Component>().Select(c => c.GetType().Name).ToArray();
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Add a new copy of the component
    /// Requires GetCopyOf Component Extension Method
    /// </summary>
    public static T AddComponent<T>(this GameObject go, T toAdd) where T : Component
    {
        return go.AddComponent<T>().CopyComponent(toAdd);
    }

    /// <summary>
    /// Create a parent gameobject with toggle group component
    /// </summary>
    public static ToggleGroup CreateToggleGroup(this GameObject go, string name)
    {
        GameObject newGO = new(name);
        newGO.transform.parent = go.transform;
        var tg = newGO.AddComponent<ToggleGroup>();
        return tg;
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Set Layer to all direct children
    /// </summary>
    public static void SetLayerToDirectChildren(this GameObject go, int layer)
    {
        var children = go.GetComponentsInChildren<Transform>(includeInactive: true);
        foreach (var child in children)
        {
            child.gameObject.layer = layer;
        }
    }

    //====================================================================================================
    //====================================================================================================
}