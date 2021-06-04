using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToPoint : MonoBehaviour
{
    [SerializeField] private Transform point;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                            point.position.y,
                                                            other.gameObject.transform.position.z);

        if(Mathf.Abs(other.GetComponent<Rigidbody>().velocity.y) > 50)
        {
            other.GetComponent<Rigidbody>().velocity =new  Vector3(other.GetComponent<Rigidbody>().velocity.x, 50 * Mathf.Sign(other.GetComponent<Rigidbody>().velocity.y), other.GetComponent<Rigidbody>().velocity.z);
        }
    }
}
