using System.Collections;
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
        score1.text += " " + PlayerPrefs.GetFloat("score1").ToString();
        score2.text += " " + PlayerPrefs.GetFloat("score2").ToString();
        score3.text += " " + PlayerPrefs.GetFloat("score3").ToString();
        score4.text += " " + PlayerPrefs.GetFloat("score4").ToString();
        score5.text += " " + PlayerPrefs.GetFloat("score5").ToString();
    }

    public void resetLeaderboard() {
        PlayerPrefs.SetFloat("score1", 999.99f);
        PlayerPrefs.SetFloat("score2", 999.99f);
        PlayerPrefs.SetFloat("score3", 999.99f);
        PlayerPrefs.SetFloat("score4", 999.99f);
        PlayerPrefs.SetFloat("score5", 999.99f);
    }
}
