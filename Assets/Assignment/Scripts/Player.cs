using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    public float speed=5;
    Vector2 destination, finalFacing;

    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();

        destination= transform.position = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        move();
    }

    public void move()
    {
        Vector2 movement = destination - (Vector2)transform.position;
        
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
            animator.SetFloat("Horizontal", finalFacing.x);
            animator.SetFloat("Vertical", finalFacing.y);
        }
        else 
        { 
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.magnitude);
        rb.MovePosition(rb.position+movement.normalized*speed*Time.deltaTime);
        

    }
    public void setDestination(Vector2 des,Vector2 facing)
    {
        destination = des;
        finalFacing = facing;
    }
}
