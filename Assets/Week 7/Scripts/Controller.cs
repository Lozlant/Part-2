using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
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
}
