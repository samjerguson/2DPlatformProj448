﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public float waitTime;
    public List<bool> movingLeft;
    public int enemySpeed = 7;
    public List<Transform> mediumEnemyPaths;
    public List<Transform> mediumEnemies; 
    public List<Transform> checkpoints = new List<Transform>();
    int lives = 3;
    public GameObject player;
    float cameraHalfHeight;
    int currRoom = 1;
    static public bool immune = false;
    float time_immune = 0f;


    // Start is called before the first frame update
    void Start()
    {   if(MainMenu.isHard) {
            lives = 1;
        }
        FindObjectOfType<Player>().GameOver += OnGameOver; //now the GameOver event will call the OnGameOver method in this script, if necessary
        cameraHalfHeight = Camera.main.orthographicSize;
        setPreviousTimes();
        mediumEnemies[0].position = mediumEnemyPaths[0].position;
        mediumEnemies[1].position = mediumEnemyPaths[2].position;
        mediumEnemies[2].position = mediumEnemyPaths[4].position;
        //StartCoroutine(MediumEnemyMovement()); 
    }

    // Update is called once per frame
    void Update()
    {
        if(MainMenu.isMedium) {
            MediumEnemyMovement();
        }
        if(lives == 0)
        {
            GameTimer.seconds = 0f;
            SceneManager.LoadScene(2);
        }
        if(Time.time - time_immune > 3) {
            immune = false;
        }
        NewRoom(); //camera changes and checkpoint added
    }

    void NewRoom()
    {
        //make sure if camera size is changed, the bottom is still at y = 0, otherwise this breaks
        if (player.transform.position.y > ((currRoom - 1) * (2 * cameraHalfHeight)) + cameraHalfHeight + .5) //+.5 because thats half the player height
        {
            currRoom++; //we go up a room
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 2 * cameraHalfHeight, -10); //moves camera up after we complete the first room
        }
        else if (player.transform.position.y < Camera.main.transform.position.y - cameraHalfHeight - .5 && currRoom > 1)
        {
            currRoom--; //we go down a room
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 2 * cameraHalfHeight, -10); //moves camera down if we fall
        }
    }

    void OnGameOver()
    {
        GameTimer.storeTime(GameTimer.seconds);
        SceneManager.LoadScene(3);
    }

    public void coroutineStarter()
    {
        StartCoroutine(PlayerDeath());
    }
    public IEnumerator PlayerDeath()
    {
        if(!immune)
        {
            immune = true;
            time_immune = Time.time;
            lives--;
            bool canMove = false;
            FindObjectOfType<Player>().setMove(canMove);
            player.SetActive(false);
            yield return new WaitForSecondsRealtime(1f);
            player.SetActive(true);
            player.transform.position = checkpoints[currRoom - 1].position;
            canMove = true;
            FindObjectOfType<Player>().setMove(canMove);
        }
    }

    public void playerHeal()
    {
        lives++;
    }

    public int getLives()
    {
        return lives;
    }

    void setPreviousTimes() {
        if(PlayerPrefs.GetFloat("score1") != 999.99f){
            print("did nothing");
        } else {
            PlayerPrefs.SetFloat("score1", 999.99f);
            PlayerPrefs.SetFloat("score2", 999.99f);
            PlayerPrefs.SetFloat("score3", 999.99f);
            PlayerPrefs.SetFloat("score4", 999.99f);
            PlayerPrefs.SetFloat("score5", 999.99f);
        }
    }

    void MediumEnemyMovement()
    {
        //while (true)
        //{
            for (int i = 0; i < mediumEnemies.Count; i++)
            {
                if (movingLeft[i] == true)
                {
                    mediumEnemies[i].position = Vector3.MoveTowards(mediumEnemies[i].position, mediumEnemyPaths[2 * i].position, enemySpeed * Time.deltaTime);
                    //mediumEnemies[i].position += (mediumEnemyPaths[2 * i].position - mediumEnemies[i].position).normalized * enemySpeed * Time.deltaTime;
                    if (mediumEnemies[i].position.x < mediumEnemyPaths[2 * i].position.x + 1)
                    {
                        movingLeft[i] = false;
                        //yield return new WaitForSeconds(waitTime);
                    }
                    //yield return null;
                }
                else
                {
                    mediumEnemies[i].position = Vector3.MoveTowards(mediumEnemies[i].position, mediumEnemyPaths[(2 * i) + 1].position, enemySpeed * Time.deltaTime);
                    //mediumEnemies[i].position += (mediumEnemyPaths[(2 * i) + 1].position - mediumEnemies[0].position).normalized * enemySpeed * Time.deltaTime;
                    if (mediumEnemies[i].position.x > mediumEnemyPaths[(2 * i) + 1].position.x - 1)
                    {
                        movingLeft[i] = true;
                        //yield return new WaitForSeconds(waitTime);
                    }
                    //yield return null;
                }
            }
        //
    }
}
