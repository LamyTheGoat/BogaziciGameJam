using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMovementObjects : MonoBehaviour
{
    [SerializeField] private Transform waypointsParent;
    [SerializeField] private float speed;
    [SerializeField] private float waitingTime;


    [SerializeField]private List<Vector3> waypoints;
    private Vector3 currentWaypoint;
    private int currentIndex;
    private bool freezed = false;
    private float nextUnfreezeTime = 0f;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = new List<Vector3>();
        int i = 0;
        foreach (Transform t in waypointsParent.GetComponentInChildren<Transform>())
        {

            waypoints.Add(t.position);

            i++;
        }

        waypointsParent.SetParent(null);
        rb = GetComponent<Rigidbody>();
        currentIndex = 0;
        currentWaypoint = waypoints[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfReached();
    }
    void CheckIfReached()
    {
        if (freezed)
        {
            if (Time.time > nextUnfreezeTime)
            {
                freezed = false;
                nextUnfreezeTime = 0;
                NextWaypoint();

            }
            return;
        }

        if (transform.position == currentWaypoint)
        {
            freezed = true;
            nextUnfreezeTime = Time.time + waitingTime;
            return;
        }
        else
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime));

        }
    }
    void NextWaypoint()
    {
        if (currentIndex == waypoints.Count - 1)
        {

            currentIndex = 0;

        }
        else
        {
            currentIndex++;
        }

        currentWaypoint = waypoints[currentIndex];

    }
}
