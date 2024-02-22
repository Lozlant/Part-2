using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D goalkeeperRb;
    public float maxDistance=3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 target;
        if (Controller.selectedPlayer == null) return;
        Vector2 distance = ((Vector2)Controller.selectedPlayer.transform.position-(Vector2)transform.position);
        //Debug.Log(distance.magnitude);
        if (distance.magnitude > maxDistance * 2) target = (Vector2)transform.position + distance.normalized * maxDistance;
        else target = (Vector2)transform.position + distance * 0.5f;
        goalkeeperRb.MovePosition(target);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
