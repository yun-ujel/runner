using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // These values are serialized so that it's possible to edit them in the Unity inspector
    // Some of these use sliders for the sake of convenience, although they're not entirely necessary
    [SerializeField] private inputController input = null;
    [SerializeField, Range(0f, 80f)] private float jumpHeight = 20f;
    [SerializeField, Range(0, 10)] private int maxAirJumps = 0;
    [SerializeField, Range(0f, 20f)] private float downwardMovementMultiplier = 6f;
    [SerializeField, Range(0f, 20f)] private float upwardMovementMultiplier = 4f;
    [SerializeField] private float defaultGravityScale;


    // Both the inputController and Ground are other scripts referenced in this,
    // but because inputController is interchangeable, it's serialized.
    // This Jump script would likely not function without Ground, which may potentially be a flaw
    private Rigidbody2D body;
    private Ground ground;
    private Vector2 velocity;

    // jumpPhase is used to count the number of jumps used
    private int jumpPhase;
    // desiredJump is used to define if the player has pressed the jump button or not
    private bool desiredJump;
    // jumpStatus is used for variable jump heights
    private int jumpStatus;
    private bool onGround;


    // Awake is called just before Start (?)
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();

        defaultGravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // desiredJump is defined as true when the player inputs a jump,
        // it remains defined because it uses the "or operator" (  |=  ),
        // this lets us define it as false ourselves without the Update method screwing us over
        desiredJump |= input.RetrieveJumpInput();
    }

    // FixedUpdate runs at a fixed interval independent of the framerate,
    // It's used for the purpose of consistency in physics calculations
    private void FixedUpdate()
    {
        // At the start of physics calculations, take the Velocity variable and make it equal to velocity in the previous frame,
        // so that it's vertical component can be modified and later reused
        onGround = ground.GetOnGround();
        velocity = body.velocity;


        // When on the ground, the amount of midair jumps used is reset
        // The jump state is set to 1, meaning the player is grounded and hasn't jumped
        if (onGround)
        {
            jumpPhase = 0;
            jumpStatus = 1;
        }
       
        // When desiredJump is true, reset it to false and call for the Jump method
        // This method could theoretically be used in this line instead of being called,
        // but it's better to be used as an independent method for the sake of convenience and performance
        if (desiredJump)
        {
            desiredJump = false;
            JumpAction();
        }

        // If the player is holding the jump button while midair, and hasn't already let go:
        if ((input.RetrieveJumpStatus()) && (!onGround) && (jumpStatus != 0))
        {
            // Change the jump state to this condition "Rising"
            jumpStatus = 2;
            Debug.Log("Status: Rising");
        }
        // If the player was rising, and has now let go of the jump button:
        else if ((!input.RetrieveJumpStatus()) && (jumpStatus == 2) && (body.velocity.y > 0))
        {
            // Call for the FallAction method and set the jump state to this condition "Falling"
            FallAction();
            jumpStatus = 0;
            Debug.Log("Status: Falling");
        }


        // I did not make use of a Boolean for the jumpStatus variable,
        // despite that the "Falling" and "Grounded" conditions are very similar

        // This is because if the FallAction method was constantly applied while the player wasn't holding jump,
        // it could potentially override the initial momentum that comes from a jump

        // I initially intended to do this, but instead chose to lower the velocity just once instead,
        // so that I wouldn't have to mess with the existing velocity calculations
        // and to make the curve appear slightly smoother

        // This could potentially be a flaw



        // If the player is moving upwards,
        if (body.velocity.y > 0)
        {
            // Apply the upwards multiplier to the gravity
            body.gravityScale = upwardMovementMultiplier;
        }
        // If the player is moving downwards,
        else if(body.velocity.y < 0)
        {
            // Apply the downwards multiplier to the gravity
            body.gravityScale = downwardMovementMultiplier;
        }
        // If the player is neither moving upwards or downwards, (usually due to being grounded)
        else if(body.velocity.y == 0)
        {
            // Reset the gravity to it's original scale
            body.gravityScale = defaultGravityScale;
        }


        // After completing physics calculations, change the rigidbody velocity to match the new velocity,
        // with it's y values modified and it's other values unbothered
        body.velocity = velocity;
    }


    private void JumpAction()
    {

        // Check if either the player is grounded or if they haven't yet used all of their midair jumps
        if(onGround || jumpPhase < maxAirJumps)
        {
            // If so, add 1 to their used jumps and follow through with the jump method
            jumpPhase += 1;


            // This is a specific calculation to ensure that the player always reaches the variable jumpHeight in units at the peak of their jump
            // this is done without consideration of the interference of gravity multipliers, which makes it a little more work to configure
            // Mathf is used for calculations with floats, Sqrt meaning Square Root
            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            if(velocity.y > 0f)
            {
                // Mathf.Max picks the higher of two values, which in this case is used to ensure that the jumpSpeed is always above 0
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            // Here the jumpSpeed is added to the velocity
            velocity.y = 0f;

            velocity.y += jumpSpeed;

        }
    }

    // This method is used to lower the jump velocity, for use in variable jumps 
    private void FallAction()
    {
        velocity.y = velocity.y * 0.2f;
    }

    public bool GetIsRising()
    {
        if(velocity.y > 0f)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
