using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public Vector3 positionMotor;
    public Vector3 rotationMotor;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(positionMotor * Time.deltaTime);
        transform.Rotate(rotationMotor * Time.deltaTime);
    }
}
