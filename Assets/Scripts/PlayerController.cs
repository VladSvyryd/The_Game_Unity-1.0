using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    private float speedIncreaseMilestoneStore;

    public float JumpForce;

    public float jumpTime;
    private float jumpTimeCounter; 

    public float score;

    public bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    public Animator myAnimator;
    //private Collider2D myCollider;            //dont need it anymore because we have a groundCheck objeckt put into Hero to check ground 

    public GameManagerTool gameManager;

    private float moveSpeedStore;
   private float speedMileStoneCountStore;



    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;      //saveing data of speed to a variable to set it back to notmal point after restaerting 106 ,107  line
        speedMileStoneCountStore = speedMilestoneCount;         //save speedMilestone
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        stoppedJumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

         // speed up a player at a certain point
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;   //increase milestone of speed after moveSpeed was increased to make a loop  
            moveSpeed = moveSpeed * speedMultiplier;

        }




        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, JumpForce);
                stoppedJumping = false;
            }

            // make double jump possibles
            if(!grounded && canDoubleJump)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, JumpForce);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = false;
            }
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {

            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, JumpForce);
                jumpTimeCounter -= Time.deltaTime;

            }

        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }


        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "killbox")
        {
            gameManager.RestartGame();

            speedMilestoneCount = speedMileStoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestone;


        }

    }










}
