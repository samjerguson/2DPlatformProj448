using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

static public float seconds = 0.0f;
public Text disvar;
static public bool notInMenu = true;

void Update() 
{        
  if(notInMenu) {
        seconds += Time.deltaTime;
        int minutes = ((int)seconds) / 60; 
        double b = System.Math.Round(seconds % 60, 2);
        disvar.text = minutes.ToString("0") + ":" + b.ToString() + "s";  
  }          
}

static public void storeTime() {
  if(seconds < PlayerPrefs.GetFloat("score1")) {
      PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4"));
      PlayerPrefs.SetFloat("score4", PlayerPrefs.GetFloat("score3"));
      PlayerPrefs.SetFloat("score3", PlayerPrefs.GetFloat("score2"));
      PlayerPrefs.SetFloat("score2", PlayerPrefs.GetFloat("score1"));
      PlayerPrefs.SetFloat("score1", seconds);
  }
  else if(seconds < PlayerPrefs.GetFloat("score2")) {
      PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4"));
      PlayerPrefs.SetFloat("score4", PlayerPrefs.GetFloat("score3"));
      PlayerPrefs.SetFloat("score3", PlayerPrefs.GetFloat("score2"));
      PlayerPrefs.SetFloat("score2", seconds);
  }
  else if(seconds < PlayerPrefs.GetFloat("score3")) {
      PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4"));
      PlayerPrefs.SetFloat("score4", PlayerPrefs.GetFloat("score3"));
      PlayerPrefs.SetFloat("score3", seconds);
  }
  else if(seconds < PlayerPrefs.GetFloat("score4")) {
      PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4"));
      PlayerPrefs.SetFloat("score4", seconds);
  }
  else if(seconds < PlayerPrefs.GetFloat("score5")) {
      PlayerPrefs.SetFloat("score5", seconds);
  }
}

public void changeInMenu() {
    notInMenu = !notInMenu;
}

}