using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float degreesPerSecond = 300;

    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, degreesPerSecond*dirX) * Time.deltaTime);
    }
}
