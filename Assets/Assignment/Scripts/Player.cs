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
    public GameObject headObject;
    public Sprite[] headsprites = new Sprite[8];
    int objectHeading = 0;

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
    public void setHeadOn(int n)//n=0 Null, 1 watermelon, 2 pear, 3 orange, 4 cup, 5 watermelon_cup, 6 pear_cup, 7 orange_cup 
    {
        objectHeading = n;
        if (n == 0)
        {
            headObject.SetActive(false);
        }
        else
        {
            headObject.SetActive(true);
            headObject.GetComponent<SpriteRenderer>().sprite = headsprites[n];
        }
    }
    public void juicing(BowlCounter bowl)
    {
        //Debug.Log(objectHeading);
        if (objectHeading < 1 || objectHeading > 3) return;
        bowl.changeJuice(objectHeading);
    }
}
