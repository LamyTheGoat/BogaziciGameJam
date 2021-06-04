using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObjects : MonoBehaviour
{
    [SerializeField] string holdableName;
    Rigidbody rb;
    ObjectHolding oh;
    bool collisionActive= true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collisionActive) {
            oh = collision.gameObject.GetComponent<ObjectHolding>();
            if (oh != null)
            {
                if (oh.isHolding)
                {
                    return;
                }
                else
                {
                    PickUp();
                }
            }
        }
        

    }

    public void PickUp()
    {
        oh.isHolding = true;
        oh.holdingObjectString = holdableName;
        oh.holdingObject = this;
        rb.isKinematic = true;
        gameObject.transform.position = oh.objectHoldingPosition.position;
        gameObject.transform.localScale = oh.holdingObjectScale;
        gameObject.transform.SetParent(oh.objectHoldingPosition);
        GetComponent<Collider>().enabled = false;
        collisionActive = false;
    }
    public HoldableObjects Drop()
    {
        oh.isHolding = false;
        oh.holdingObjectString = "";
        oh.holdingObject = null;
        rb.isKinematic = false;
        gameObject.transform.localScale = new Vector3(1,1,1); ;
        gameObject.transform.SetParent(null);
        rb.AddForce(transform.up * 2, ForceMode.Impulse);
        GetComponent<Collider>().enabled = true;
        Invoke("ReactivateCollider", 1.5f);

        return this;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void ReactivateCollider() {
        collisionActive = true;
    }
}
