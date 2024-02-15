using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneName : MonoBehaviour
{
    TextMeshProUGUI sceneNameLable;

    // Start is called before the first frame update
    void Start()
    {
        sceneNameLable=GetComponent<TextMeshProUGUI>();
        sceneNameLable.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
