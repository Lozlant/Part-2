using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class Counter : MonoBehaviour
{
    public Player player;
    public float horFacing, verFacing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        player.setDestination((Vector2)transform.position,new Vector2(horFacing,verFacing));
    }


}
