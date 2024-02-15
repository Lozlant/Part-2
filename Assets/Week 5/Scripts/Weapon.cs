using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 movement = new Vector3(-4,0,0);
    float timer=0, timeExit=5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeExit)
        {
            timer=0;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1);
            Destroy(gameObject);
        
    }


}
