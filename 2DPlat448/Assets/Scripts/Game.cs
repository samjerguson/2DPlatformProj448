using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public List<Transform> checkpoints = new List<Transform>();
    int lives = 3;
    public GameObject player;
    float cameraHalfHeight;
    int currRoom = 1;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().GameOver += OnGameOver; //now the GameOver event will call the OnGameOver method in this script, if necessary
        cameraHalfHeight = Camera.main.orthographicSize;
        checkPreviousTimes();
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 0)
        {
            SceneManager.LoadScene(2);
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
        GameTimer.storeTime();
        SceneManager.LoadScene(3);
    }

    public void coroutineStarter()
    {
        StartCoroutine(PlayerDeath());
    }
    public IEnumerator PlayerDeath()
    {
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

    public void playerHeal()
    {
        lives++;
    }

    public int getLives()
    {
        return lives;
    }

    void checkPreviousTimes() {
        float score1 = PlayerPrefs.GetFloat("score1");
        float score2 = PlayerPrefs.GetFloat("score2");
        float score3 = PlayerPrefs.GetFloat("score3");
        float score4 = PlayerPrefs.GetFloat("score4");
        float score5 = PlayerPrefs.GetFloat("score5");
        if (score1 == 0 && score2 == 0 && score3 == 0 && score4 == 0 && score5 == 0) {
            PlayerPrefs.SetFloat("score1", 999.99f);
            PlayerPrefs.SetFloat("score2", 999.99f);
            PlayerPrefs.SetFloat("score3", 999.99f);
            PlayerPrefs.SetFloat("score4", 999.99f);
            PlayerPrefs.SetFloat("score5", 999.99f);
        }
    }
}
