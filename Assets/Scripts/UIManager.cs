using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    bool started = false;
    float t = 0f;
    public TMP_Text timeText;
    public TMP_Text dirText;
    public TMP_Text gameText;
    public TMP_Text healthText;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        timeText.enabled = false;
        dirText.enabled = false;
        gameText.enabled = false;
        healthText.enabled = false;
        
    }

    void Update()
    {
        if (started)
            t += Time.deltaTime;
    }

    public void SetA()
    {
        gameText.text = "Game: A";
        healthText.enabled = true;
        started = true;
    }

    public void SetB()
    {
        gameText.text = "Game: B";
        healthText.enabled = true;
        started = true;
    }

    public void SetText()
    {
        timeText.text = "Time: " + t.ToString("F3");
        timeText.enabled = true;

        dirText.enabled = true;
        if (Player2D.Instance.transform.position.x < 0)
        {
            dirText.text = "Direction: Left";
        }
        else
        {
            dirText.text = "Direction: Right";
        }

        gameText.enabled = true;
    }
}
