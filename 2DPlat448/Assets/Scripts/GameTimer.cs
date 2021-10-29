using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

private float seconds = 0.0f;
public Text disvar;

void Update() 
{              
  seconds += Time.deltaTime;
  int minutes = ((int)seconds) / 60; 
  double b = System.Math.Round(seconds % 60, 2);
  disvar.text = minutes.ToString("0") + ":" + b.ToString() + "s";      
}
}