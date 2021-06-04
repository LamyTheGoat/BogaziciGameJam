using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashableObject : MonoBehaviour
{
    [SerializeField] string target = "Player";

    [SerializeField] ActionType type;

    [SerializeField] float velocityTreshold;
    [SerializeField] int HP;
    [SerializeField] List<GameObject> states;
    int currentState = 0;

    public enum ActionType
    {
        Delete,
        Move,


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals(target))
        {
            Debug.Log(collision.relativeVelocity.y);
            if (Mathf.Abs(collision.relativeVelocity.y) >= velocityTreshold)
            {
                HP--;
                currentState++;
                StateHasBeenChanged();
            }
            if(HP <= 0)
            {
                
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

    void StateHasBeenChanged()
    {
        foreach(GameObject o in states)
        {
            o.SetActive(false);
        }
        if(currentState <= states.Count - 1) states[currentState].SetActive(true);

    }
}
