using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolding : MonoBehaviour
{
    public string holdingObjectString = "";
    public bool isHolding = false;

    public HoldableObjects holdingObject;

    public Transform objectHoldingPosition;
    public Vector3 holdingObjectScale = new Vector3(0.2f, 0.2f, 0.2f);


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            holdingObject.Drop();
        }
    }
}
