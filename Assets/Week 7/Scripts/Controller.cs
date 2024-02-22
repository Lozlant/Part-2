using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge = 1;
    Vector2 direction;

    public static PlayerMover selectedPlayer { get; private set; }

    public static void SetSelectedPlayer(PlayerMover player)
    {
        if(selectedPlayer != null)
        {
            selectedPlayer.Selected(false);
            
        }
        selectedPlayer = player;
        selectedPlayer.Selected(true);
    }

    private void FixedUpdate()
    {
        if(selectedPlayer != null && direction!=Vector2.zero)
        {
            selectedPlayer.Move(direction);
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = charge;
        }
    }

    private void Update()
    {
        if (selectedPlayer == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge+=Time.deltaTime;
            charge=Mathf.Clamp(charge, 0,maxCharge);
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)selectedPlayer.transform.position).normalized * charge;
        }

    }

}
