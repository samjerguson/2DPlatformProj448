﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboardManager : MonoBehaviour
{
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;

    // Update is called once per frame
    void Update()
    {
        score1.text += " " + PlayerPrefs.GetFloat("score1", 0).ToString();
        score2.text += " " + PlayerPrefs.GetFloat("score2", 0).ToString();
        score3.text += " " + PlayerPrefs.GetFloat("score3", 0).ToString();
        score4.text += " " + PlayerPrefs.GetFloat("score4", 0).ToString();
        score5.text += " " + PlayerPrefs.GetFloat("score5", 0).ToString();
    }
}