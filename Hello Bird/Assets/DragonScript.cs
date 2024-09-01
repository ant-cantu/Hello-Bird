using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float rotationSpeed = 5; 
    public float flapStrength;
    public LogicScript logic;
    public Animator animator;
    public AudioSource soundFlap;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !logic.isGameOver)
        {

            myRigidBody.velocity = Vector2.up * flapStrength;
            soundFlap.Play();
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, myRigidBody.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            logic.gameOver();
            animator.enabled = false;
        }
    }
}
