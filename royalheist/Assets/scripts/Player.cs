using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Animations;
using UnityEngine;

/*
    @Author: Pedro Victor
    Royal Heist v2.0
*/

public class Player : MonoBehaviour
{
    float speed = 6f; // Player speed
    Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log("Horizontal: " + GetXAxisValue() + ", Vertical: " + GetYAxisValue());
        Move();
        Attack();
    }

    private float GetXAxisValue()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    private float GetYAxisValue()
    {
        return Input.GetAxisRaw("Vertical");
    }

    public void Move()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        //x-Movement
        transform.position += new Vector3(xMovement * speed * Time.deltaTime, 0, 0);

        //y-Movement
        transform.position += new Vector3(0, yMovement * speed * Time.deltaTime, 0);

        switch (xMovement)
        {
            // Left: 2
            case -1:
                anim.SetInteger("direction", 2);
                break;
            // Right: 3
            case 1:
                anim.SetInteger("direction", 3);
                break;
        }
        switch (yMovement)
        {
            // Down: 1
            case -1:
                anim.SetInteger("direction", 1);
                break;
            // Up: 0
            case 1:
                anim.SetInteger("direction", 0);
                break;
        }
        bool isWalking = xMovement != 0 || yMovement != 0;
        anim.SetBool("isWalking", isWalking);
    }

    //TODO
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.ResetTrigger("isAttacking");
    
    
            int direction = anim.GetInteger("direction");
            anim.SetInteger("direction", direction);

            anim.SetTrigger("isAttacking");
        }
    }
}
