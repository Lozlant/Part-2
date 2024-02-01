using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public int score;
    Collider2D runway;
    // Start is called before the first frame update
    void Start()
    {
        runway = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.transform.position);
        if (runway.OverlapPoint(collision.gameObject.transform.position))
        {
            collision.gameObject.GetComponent<Plane>().isLanding = true;
            score++;
        }
    }
}
