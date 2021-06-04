using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBasic : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    public float walkingSpeed;
    public Transform grndcheck;
    public float grndDistance;
    public LayerMask groundMask;
    public float jumpForce;
    public float hInput;
    public string state;
    public Rigidbody rb;





    private float nextTimeToForce = 0f;
    public bool isGrounded;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(grndcheck.position, grndDistance, groundMask);
        if (gameManagerScript.gameHasEnded != true)
        Move();
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
           
        }
    }   





    //HANGI HAREKETIN YAPILACAGINA KARAR VERME/ DECIDING MOVEMENT STYLE
    public void Move()
    {
        switch (state)
        {
            case "dragmove":
                DragMovement();
                //jumpForce = 15;
                break;
        }
        Jump();
        SelfDestruct();
    }


    //ZIPLAMA/JUMP
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Debug.Log("Zıp");
            rb.AddForce(Vector3.up * jumpForce * 10);
        }

    }



    //NORMAL HAREKET/ DEFAULT MOVEMENT
    public void DragMovement()
    {
        hInput = Input.GetAxis("Horizontal");
        float vMovement = hInput * walkingSpeed;
        rb.velocity = new Vector3(vMovement, rb.velocity.y, 0);
    }


    void SelfDestruct()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManagerScript.EndGame();
        }
    }
}
