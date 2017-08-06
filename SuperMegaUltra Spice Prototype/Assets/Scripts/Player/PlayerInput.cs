using UnityEngine;
using System.Collections;



public class PlayerInput : MonoBehaviour {

    /*
     * Enumeration of the jump states possible by the player. These are used to
     * communicate to the platforms
     */
    public enum JUMP_STATE
    {
        Up,
        Down,
        No
    };
    public JUMP_STATE jumpState = JUMP_STATE.No;

    public float forceUp;
    public float forceDown;
    public bool isDead = false;

    private Rigidbody2D rd;
    private bool forceAdded;

    public void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    /*
     * Function: Update
     * Purpose: Handle user input on the vertical axis (jump axis) to move up or down.
     *          This uses the two members currentPlatformLevel and jumpState to 
     *          communicate needs to the collision handler of the platform.
     */
    void Update()
    {
        //get the jump axis
        float yAxis = 0;
        if (Input.GetKeyDown(KeyCode.W))
            yAxis = 1;
        if (Input.GetKeyDown(KeyCode.S))
            yAxis = -1;

        //if jump is enabled and positive jump
        if (!forceAdded && yAxis > 0 && !isDead)
        {
            jumpState = JUMP_STATE.Up;
        }
        //negative jump
        else if (!forceAdded && yAxis < 0 && !isDead)
        {
            jumpState = JUMP_STATE.Down;
        }
        
    }

    void FixedUpdate()
    {
        if(jumpState == JUMP_STATE.Up && !forceAdded)
        {
            rd.AddForce(Vector2.up * forceUp);
            forceAdded = true;
        }
        else if(jumpState == JUMP_STATE.Down && !forceAdded)
        {
            rd.AddForce(Vector2.down * forceDown);
            forceAdded = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        //reenable ability to jump
        forceAdded = false;
        jumpState = JUMP_STATE.No;
    }
}
