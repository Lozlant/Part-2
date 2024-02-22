using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCounter : Counter
{
    public Order order;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && isArrivedCounter)
        {
            //Debug.Log("Active");
            order.SendMessage("matchOrder",player.objectHeading-5);
            player.setHeadOn(0);
        }
    }
}
