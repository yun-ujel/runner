using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject startPlaforms;
    [Space]
    [SerializeField] private float maxCameraSpeed = 16f;
    [SerializeField] private float speedMultiplier = 1.0001f;
    [SerializeField] private float startingCameraSpeed = 3f;
    public float cameraSpeed;

    private bool startMoving;

    private Rigidbody2D body;
    private Vector2 velocity;
    Move pmc;

    GameObject player;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        OnStart();
    }

    private void FixedUpdate()
    {
        if (startMoving)
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
        else
        {
            if (player.transform.position.x > 1f)
            {
                Debug.Log("Started");
                startMoving = true;
                cameraSpeed = startingCameraSpeed;
            }
        }
    }

    public void OnStart()
    {
        startMoving = false;

        cameraSpeed = 0f;
        body.velocity = Vector2.zero;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
