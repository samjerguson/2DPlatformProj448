using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class overmusic : MonoBehaviour
{

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameWon")
        {
            Destroy(this.gameObject);
        }
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(this.gameObject);
        }
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            Destroy(this.gameObject);
        }
        if (SceneManager.GetActiveScene().name == "TestSuite")
        {
            Destroy(this.gameObject);
        }





    }
}