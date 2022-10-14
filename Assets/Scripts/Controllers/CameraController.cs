using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float maxCameraSpeed = 16f;
    [SerializeField] private float speedMultiplier = 1.0001f;
    [SerializeField] private float startingCameraSpeed = 6f;
    public float cameraSpeed;

    private Rigidbody2D body;
    private Vector2 velocity;
    Move pmc;

    GameObject player;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        onStart();
    }

    private void FixedUpdate()
    {


        velocity = body.velocity;

        if (cameraSpeed < maxCameraSpeed)
        {
            cameraSpeed *= speedMultiplier;
        }
        else
        {
            cameraSpeed = maxCameraSpeed;
        }
        if (player.transform.position.x - 5 > transform.position.x)
        {
            velocity.x = cameraSpeed * 1.1f;
        }
        else
        {
            velocity.x = cameraSpeed;
        }

        body.velocity = velocity;
    }

    public void onStart()
    {
        cameraSpeed = startingCameraSpeed;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

    }
}
