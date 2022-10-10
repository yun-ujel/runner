using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // These values are serialized so that it's possible to edit them in the Unity inspector
    // Some of these use sliders for the sake of convenience, although they're not entirely necessary
    [SerializeField] private inputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    // Both the inputController and Ground are other scripts referenced in this,
    // but because inputController is interchangeable, it's serialized.
    // This Movement script would likely not function without Ground, which may potentially be a flaw
    private Ground ground;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;

    // Awake is called just before Start (?)
    void Awake()
    {
        // These variables are used for reference of other components
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
    }

    // Update is called once per frame
    void Update()
    {
        // This takes the direction of movement from the input
        direction.x = input.RetrieveMoveInput();
        // This uses that direction and multiplies it with the maxSpeed minus the friction, as long as this is above 0
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);
    }

    // FixedUpdate runs at a fixed interval independent of the framerate,
    // It's used for the purpose of consistency in physics calculations
    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        // This sets the velocity to the current Rigidbody velocity before calculating changes
        velocity = body.velocity;

        // If onGround is true, the acceleration becomes grounded acceleration
        // if not, air acceleration is used instead
        acceleration = onGround ? maxAcceleration : maxAirAcceleration;

        maxSpeedChange = acceleration * Time.deltaTime;

        // This sets the velocity to move towards it's maximum, desiredVelocity,
        // at the rate of change stated by maxSpeedChange.
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        // After completing physics calculations, change the rigidbody velocity to match the new velocity,
        // with it's x values modified and it's other values unbothered,
        // so that scripts that change other parts of velocity are not harmed
        body.velocity = velocity;
    }

    public float GetVelocity()
    {
        return velocity.x;
    }
}
