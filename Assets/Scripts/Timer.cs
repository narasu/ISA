using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private static Timer instance;
    public static Timer Instance
    {
        get
        {
            return instance;
        }
    }

    float t = 0f;
    private TMP_Text timeText;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        timeText = GetComponentInChildren<TMP_Text>();
        timeText.enabled = false;
        
    }

    void Update()
    {
        t += Time.deltaTime;
    }

    public void SetText()
    {
        timeText.text = "Time: " + t.ToString("F3");
        timeText.enabled = true;
    }
}
