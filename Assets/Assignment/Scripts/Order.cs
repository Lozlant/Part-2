using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Order : MonoBehaviour
{
    public Slider slider;
    public Image cup;
    public AnimationCurve appear;
    RectTransform rectTransform;

    public float maxTimer;
    float timer;
    Vector3 destination;
    float animationTimerValue=0f;

    public int juiceType=0;
    public Sprite[] juiceSprites= new Sprite[3];

    int state=0;
    Vector3 startPosition;

    int score = 0;
    public TextMeshProUGUI scoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = transform.position;
        destination = transform.position+new Vector3(800f,0f,0f);

        scoreText.text = "$$ " + score.ToString();
        slider.maxValue = maxTimer;
        reset();

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0: //
                animationTimerValue += 1f * Time.deltaTime;
                float interpolation = appear.Evaluate(animationTimerValue);
                Vector3 movement = Vector3.Lerp(startPosition, destination, interpolation);
                if(Mathf.Abs(destination.x-movement.x) < 0.1)
                {
                    state = 1;
                }
                rectTransform.position=movement;
                break;
            case 1://count down
                timer += Time.deltaTime;
                slider.value = maxTimer - timer;
                if (timer >= maxTimer)
                {
                    score -= 200;
                    scoreText.text = "$$ " + score.ToString();
                    reset();
                }
                break;
        }
        
    }
    void reset()
    {
        timer = 0f;
        animationTimerValue = 0f;

        juiceType = (int)Random.Range(0, 3);
        cup.sprite = juiceSprites[juiceType];

        transform.position = startPosition;
        slider.value=slider.maxValue;

        state = 0;

    }

    public void matchOrder(int heading)
    {
        if (heading == -5) return;
        Debug.Log(heading);

        if(juiceType == heading)
        {
            score+=100;
        }
        else
        {
            score -= 200;
        }

        scoreText.text = "$$ " + score.ToString();
        reset();
    }
}
