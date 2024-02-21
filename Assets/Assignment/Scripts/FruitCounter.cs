using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCounter : Counter
{
    public int objectHeading;
    

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && isArrivedCounter)
        {
            Debug.Log("Active");
            player.setHeadOn(objectHeading);
        }
    }
}
