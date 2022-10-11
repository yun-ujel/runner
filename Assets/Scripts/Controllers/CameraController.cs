using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float startingCameraSpeed = 0.2f;
    private Rigidbody2D body;
    private Vector2 velocity;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        velocity = body.velocity;

        velocity.x = startingCameraSpeed;

        body.velocity = velocity;
    }
}
