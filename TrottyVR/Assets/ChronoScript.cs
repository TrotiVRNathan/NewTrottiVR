using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Chrono : MonoBehaviour


{  
    [SerializeField] TextMeshProUGUI chronoText;
    public float chrono;


    // Start is called before the first frame update
    void Start()
    {
        chrono = 0.0f;
    }


    // Update is called once per frame
    void Update()
    {
        void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
         float milliSeconds = (timeToDisplay % 1) * 1000;


        chronoText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }


    chrono += Time.deltaTime;


    DisplayTime(chrono);
    }
}

