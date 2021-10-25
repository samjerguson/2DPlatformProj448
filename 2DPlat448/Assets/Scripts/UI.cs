using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().GameOver += OnGameOver; //now the GameOver event will call the OnGameOver method in this script, if necessary
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGameOver()
    {

    }
}
