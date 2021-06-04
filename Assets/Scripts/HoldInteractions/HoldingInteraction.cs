using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingInteraction : MonoBehaviour
{
    [SerializeField] string target = "Player";
    [SerializeField] string holdingObjectString;
    [SerializeField] ActionType type;

    public enum ActionType
    {
        Delete,
        Move,
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals(target))
        {
            if(collision.gameObject.GetComponent<ObjectHolding>().isHolding && collision.gameObject.GetComponent<ObjectHolding>().holdingObjectString.Equals(holdingObjectString))
            {
                HoldableObjects holdingObject = collision.gameObject.GetComponent<ObjectHolding>().holdingObject.Drop();
                holdingObject.Kill();
                switch (type)
                {
                    case ActionType.Delete: Delete(); break;
                    case ActionType.Move: Move(); break;
                }
            }

        }
    }

    void Delete()
    {
        Destroy(gameObject);
    }

    void Move()
    {

    }
}
