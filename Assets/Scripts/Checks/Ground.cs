using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool isOnGround;
    private float friction;

    // On collision with something, evaluate if it's ground and find it's friction
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
        friction = 0;
    }


    private void EvaluateCollision(Collision2D collision)
    {
        // For each point you collide with,
        for (int i = 0; i < collision.contactCount; i++)
        {
            //  check if the 'normal' value of the point is above or equal to 0.9
            // (The normal value of a flat surface would be 1, so you're essentially checking if the material is flat)
            Vector2 normal = collision.GetContact(i).normal;

            // If it is, return isOnGround = true
            isOnGround |= normal.y >= 0.9f;
        }
    }


    private void RetrieveFriction(Collision2D collision)
    {
        // Retrieve the type of physics material through the collision.
        PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;

        // By default, return the value 0 so if no physics material is used, we still get a value from this method
        friction = 0;

        // If there IS a material, reset the friction value to the one specified
        if (material != null)
        {
            friction = material.friction;
        }
    }


    // These values are for later reference, will make use of them when checking for ground and friction in
    // the movement scripts
    public bool GetOnGround()
    {
        return isOnGround;
    }
    public float GetFriction()
    {
        return friction;
    }

}
