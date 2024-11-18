using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //====================================================================================================
    //====================================================================================================

    public GameObject cube;
    public Camera cam;

    void Start()
    {

        DisposableStopwatch.Time(() =>
        {
        }, 1000000);

        DisposableStopwatch.Time(() =>
        {
        }, 1000000);
    }

    void Update()
    {
        var b = cube.GetComponent<Renderer>().IsVisibleFromCam(cam);
        print(b);

        b = cube.GetComponent<Renderer>().IsFullyVisibleFromCam(cam);
        print(b);
    }

    private void OnDrawGizmos()
    {
    }
}
