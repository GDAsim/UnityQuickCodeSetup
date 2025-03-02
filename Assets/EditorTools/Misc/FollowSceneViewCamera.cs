/* 
 * About:
 * Toggle to have Camera.Main automatically updates to the current scene camera
 * 
 * Note:
 * Undo supported
 */

using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class FollowSceneViewCamera : Editor
{
    static bool isFollowingSceneView = false;
    static Camera followCamera = null;
    static int undoGroup = -1;

    [MenuItem("Tools/Toggle Camera Follow Scene View #v")]
    public static void ToggleCameraFollowSceneView()
    {
        if (!followCamera)
        {
            followCamera = Camera.main;

            if (!followCamera)
            {
                Debug.LogError("No Camera found to follow scene view");
                isFollowingSceneView = false;
                return;
            }
        }

        if(!isFollowingSceneView)
        {
            isFollowingSceneView = true;

            undoGroup = Undo.GetCurrentGroup();
        }
        else
        {
            isFollowingSceneView = false;

            Undo.CollapseUndoOperations(undoGroup);
        }
    }

    static FollowSceneViewCamera()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
        if (isFollowingSceneView)
        {
            var sceneCameras = SceneView.GetAllSceneCameras();
            if(sceneCameras.Length == 0)
            {
                Debug.LogError("No scene view found to follow");
                isFollowingSceneView = false;
                return;
            }

            Undo.RecordObject(followCamera.transform, "followCam");
            followCamera.transform.SetPositionAndRotation(sceneCameras[0].transform.position, sceneCameras[0].transform.rotation);
        }
    }
}