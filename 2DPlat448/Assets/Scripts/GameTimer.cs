using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

static public float seconds = 0.0f;
public Text disvar;
static public bool notInMenu = true;
static public float final = 0.0f;

void Update() 
{        
  if(notInMenu) {
        seconds += Time.deltaTime;
        int minutes = ((int)seconds) / 60; 
        double b = System.Math.Round(seconds % 60, 2);
        if (disvar != null) {
            disvar.text = minutes.ToString("0") + ":" + b.ToString() + "s";  
        }
  }          
}

static public void storeTime(float final_seconds) {
    final = final_seconds;
    if(final_seconds < PlayerPrefs.GetFloat("score1")) {
        PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4"));
        PlayerPrefs.SetFloat("score4", PlayerPrefs.GetFloat("score3"));
        PlayerPrefs.SetFloat("score3", PlayerPrefs.GetFloat("score2"));
        PlayerPrefs.SetFloat("score2", PlayerPrefs.GetFloat("score1"));
        PlayerPrefs.SetFloat("score1", final_seconds);
    }
    else if(final_seconds < PlayerPrefs.GetFloat("score2")) {
        PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4"));
        PlayerPrefs.SetFloat("score4", PlayerPrefs.GetFloat("score3"));
        PlayerPrefs.SetFloat("score3", PlayerPrefs.GetFloat("score2"));
        PlayerPrefs.SetFloat("score2", final_seconds);
    }
    else if(final_seconds < PlayerPrefs.GetFloat("score3")) {
        PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4"));
        PlayerPrefs.SetFloat("score4", PlayerPrefs.GetFloat("score3"));
        PlayerPrefs.SetFloat("score3", final_seconds);
    }
    else if(final_seconds < PlayerPrefs.GetFloat("score4")) {
        PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4"));
        PlayerPrefs.SetFloat("score4", final_seconds);
    }
    else if(final_seconds < PlayerPrefs.GetFloat("score5")) {
        PlayerPrefs.SetFloat("score5", final_seconds);
    }
}

public void changeInMenu() {
    notInMenu = !notInMenu;
}

}