using UnityEngine;
using Random = UnityEngine.Random;

public class DisposableStopwatchExample : MonoBehaviour
{
    void Start()
    {
        using (new DisposableStopwatch(timespan => Debug.Log($"{timespan} elapsed")))
        {
            SpawnGameObjects();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisposableStopwatch.Time(SpawnGameObjects, 1);
        }
    }

    void SpawnGameObjects()
    {
        var num = 10000;

        var parent = Instantiate(new GameObject()).transform;
        for (int i = 0; i < num; i++)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = new Vector3(Random.Range(0, num / 100f), Random.Range(0, num / 100f), Random.Range(0, num / 100f));
            go.transform.rotation = Random.rotation;
            go.transform.parent = parent;
        }
    }
}
