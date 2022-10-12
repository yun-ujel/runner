using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float maxCameraSpeed = 16f;
    [SerializeField] private float speedMultiplier = 1.0001f;
    public float cameraSpeed = 2f;

    private Rigidbody2D body;
    private Vector2 velocity;

    GameObject player;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if(player.transform.position.x > transform.position.x)
        {
            transform.position = new Vector3(Mathf.Max(player.transform.position.x - cameraSpeed, transform.position.x), transform.position.y, transform.position.z);
        }

        velocity = body.velocity;

        if (cameraSpeed < maxCameraSpeed)
        {
            cameraSpeed *= speedMultiplier;
        }
        else
        {
            cameraSpeed = maxCameraSpeed;
        }

        velocity.x = cameraSpeed;
        body.velocity = velocity;
    }

}
