using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraObjectFitterExample : MonoBehaviour
{
    enum FitType
    {
        FitObjectToCamera,
        FitCameraToObject
    }
    [SerializeField] FitType fitType;

    [SerializeField] GameObject targetGameobject;
    [SerializeField] float fitFactor = 2.0f;

    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        if (!targetGameobject) return;

        switch (fitType)
        {
            case FitType.FitObjectToCamera:
                CameraObjectFitter.FitObjectWithinCamera(targetGameobject, cam, fitFactor);
                targetGameobject.transform.localScale = Vector3.one * (1 + Mathf.PingPong(Time.time, 1));
                break;
            case FitType.FitCameraToObject:
                CameraObjectFitter.FitCameraWithinObject(cam, targetGameobject, fitFactor);
                targetGameobject.transform.localScale = Vector3.one * (1 + Mathf.PingPong(Time.time, 1));
                break;
        }
    }
}