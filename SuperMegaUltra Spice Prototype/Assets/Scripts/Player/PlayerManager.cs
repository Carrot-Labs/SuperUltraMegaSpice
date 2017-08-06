using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
    public bool dead = false;
    public bool jump = false;
    public bool collided = false;

    public int blocksCleared = 0;

    private PlayerInput inputScript;
    private PlayerScroller scrollScript;
    private Animator animator;

	// Use this for initialization
	void Start () {
        inputScript = GetComponent<PlayerInput>();
        scrollScript = GetComponent<PlayerScroller>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //get update from input script for jump state
        if(inputScript.jumpState == PlayerInput.JUMP_STATE.No)
        {
            jump = false;
        }
        else
        {
            jump = true;
        }

        //get update from scroll script for collision state
        //todo

        //update the animator
        animator.SetBool("Collided", collided);
        animator.SetBool("Dead", dead);
        animator.SetBool("Jump", jump);

        //if dead then disable ability to jump and move forward
        //and if not then then take off limits
        scrollScript.isDead = dead;
        inputScript.isDead = dead;
	}
}
