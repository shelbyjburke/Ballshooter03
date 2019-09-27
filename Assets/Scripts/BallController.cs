﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb_ball;
    public GameObject aimGuide;
    public float ballSpeed;

    public bool ballStopped;

    // Start is called before the first frame update
    void Start()
    {
        rb_ball = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ballSpeed = rb_ball.velocity.magnitude;
        if (rb_ball.IsSleeping())
        {
            ballStopped = true;
        }
        else { ballStopped = false; }
    }    


    public void ballShoot() // adds force to ball in a direction away from camera
    {
        rb_ball = this.GetComponent<Rigidbody>();
        aimGuide = GameObject.Find("AimGuide");
        rb_ball.AddForce(aimGuide.transform.forward * 25, ForceMode.VelocityChange);
    }    

    public void slowBall()
    {        
            rb_ball.velocity *= 0.8f;                        
    }

    public void checkForBallStop()
    {
        if (ballSpeed < 0.01f)
        {
            StopBall();
            // Debug.Log("stopping Ball");            
        }
    }

    public void StopBall() //immediately halts the ball movement
    {
        rb_ball.isKinematic = true;
        rb_ball.isKinematic = false;
    }



}
