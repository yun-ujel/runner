using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float cameraSpeed = 2f;
    [SerializeField] private float speedMultiplier = 1.0001f;
    private Rigidbody2D body;
    private Vector2 velocity;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        velocity = body.velocity;

        cameraSpeed *= speedMultiplier;

        velocity.x = cameraSpeed;

        body.velocity = velocity;
    }

}
