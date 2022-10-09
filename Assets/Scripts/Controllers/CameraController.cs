using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Range(0f, 2f)] private float cameraSpeed = 0.2f;
    private Rigidbody2D body;
    private Vector2 velocity;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        velocity = body.velocity;

        velocity.x = cameraSpeed;

        body.velocity = velocity;
    }
}
