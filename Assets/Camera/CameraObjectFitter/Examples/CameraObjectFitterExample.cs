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

        float rotateSpeed = 90;

        switch (fitType)
        {
            case FitType.FitObjectToCamera:
                CameraObjectFitter.FitObjectWithinCamera(targetGameobject, cam, fitFactor);
                //cam.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                break;
            case FitType.FitCameraToObject:
                CameraObjectFitter.FitCameraWithinObject(cam, targetGameobject, fitFactor);
                //targetGameobject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                break;
        }
    }
}