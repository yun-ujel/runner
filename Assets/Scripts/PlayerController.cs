using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;

    public float maxSpeed = 5.0f; 
    public float tempSpeed;
    public float jumpForce = 100.0f;
    bool isOnGround = false;
    

    Rigidbody2D playerObject;   

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>();
        tempSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, jumpForce));
        }

        float movementValueX = 1.0f;

        playerObject.velocity = new Vector2 (movementValueX * tempSpeed, playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);

    }
}
