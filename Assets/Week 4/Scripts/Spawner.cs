using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject planePrefab;
    float timer;
    float timerTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timerTarget <= timer)
        {
            Instantiate(planePrefab);
            timer= 0;
            timerTarget=Random.Range(1, 5);
        }
    }
}
