using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text lives;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().GameOver += OnGameOver; //now the GameOver event will call the OnGameOver method in this script, if necessary
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives: " + FindObjectOfType<Game>().getLives();
    }

    void OnGameOver()
    {

    }
}
