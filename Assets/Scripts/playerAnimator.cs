using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimator : MonoBehaviour
{
    private Move move;
    private Jump jump;
    private Ground ground;
    private Vector3 these;

    private float speed;

    Animator anim;

    


    void Awake()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<Move>();
        jump = GetComponent<Jump>();
        ground = GetComponent<Ground>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsRising", jump.GetIsRising());
        anim.SetBool("OnGround", ground.GetOnGround());

        speed = move.GetVelocity();

        anim.SetFloat("Speed", Mathf.Abs(speed));

        if (speed < 0)
        {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (speed > 0)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
