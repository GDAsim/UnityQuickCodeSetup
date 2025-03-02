/*
 * About:
 * Script that Levitate and Rotate the gameobject 
 * 
 * Notes:
 * Very old script 
 * Probable source : https://assetstore.unity.com/packages/tools/particles-effects/floatate-2837
 */

using UnityEngine;

public class Floatate : MonoBehaviour
{
    public float BobSpeed = 3.0f;
    public float BobHeight = 0.5f;
    public float BobOffset = 0.0f;

    public float PrimaryRot = 80.0f; //First axies degrees per second
    public float SecondaryRot = 40.0f; //Second axies degrees per second
    public float TertiaryRot = 20.0f; //Third axies degrees per second

    float originalPosY;

    void Awake()
    {
        originalPosY = transform.position.y;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, PrimaryRot, 0) * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(SecondaryRot, 0, 0) * Time.deltaTime, Space.Self);
        transform.Rotate(new Vector3(0, 0, TertiaryRot) * Time.deltaTime, Space.Self);

        Vector3 position = transform.position;
        position.y = originalPosY + (((Mathf.Cos((Time.time + BobOffset) * BobSpeed) + 1) / 2) * BobHeight);
        transform.position = position;
    }
}