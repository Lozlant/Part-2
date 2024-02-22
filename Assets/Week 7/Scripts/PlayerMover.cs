using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color normalColor;
    Rigidbody2D rb;
    public float speed = 500;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        normalColor=spriteRenderer.color;

        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected(bool selected)
    {
        if (selected)
        {
            spriteRenderer.color = Color.blue;
        }
        else
        {
            spriteRenderer.color = normalColor;
        }
    }
    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction*speed);
    }
}
