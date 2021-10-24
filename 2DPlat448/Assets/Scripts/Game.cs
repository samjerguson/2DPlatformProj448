using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject player;
    float cameraHalfHeight;
    int currRoom = 1;
    int roomCheck;

    // Start is called before the first frame update
    void Start()
    {
        cameraHalfHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        NewRoom(); //camera changes and checkpoint added
        print(currRoom);
    }

    void NewRoom()
    {
        //make sure if camera size is changed, the bottom is still at y = 0, otherwise this breaks
        if (player.transform.position.y > ((currRoom - 1) * (2 * cameraHalfHeight)) + cameraHalfHeight + .5) //+.5 because thats half the player height
        {
            currRoom++;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 2 * cameraHalfHeight, -10);
        }
        else if (player.transform.position.y < Camera.main.transform.position.y - cameraHalfHeight - .5 && currRoom > 1)
        {
            currRoom--;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 2 * cameraHalfHeight, -10);
        }
    }
}
