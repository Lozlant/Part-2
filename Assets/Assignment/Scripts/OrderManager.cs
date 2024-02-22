using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    float Timer = 0;
    float maxTimer = 10;

    public GameObject[] orders = new GameObject[3];
    public int numberOfOrder=0;
    int orderIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Timer=maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > maxTimer && numberOfOrder<3)
        {
            Timer = 0;
            numberOfOrder++;
            orders[orderIndex].SetActive(true);
            orders[orderIndex].SendMessage("reset");
            orderIndex =(orderIndex+1)%3;
            
        }
    }
    

}
