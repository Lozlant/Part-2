using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCounter : Counter
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && isArrivedCounter)
        {
            //Debug.Log("Active");
            player.setHeadOn(0);
        }
    }
}
