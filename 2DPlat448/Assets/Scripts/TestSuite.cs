﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestSuite : MonoBehaviour
{
    public Text to_game;
    public Text to_game2;
    private int step = 0;
    private bool can_press_y = false;
    private float seconds = 0f;

    // Start is called before the first frame update
    void Start()
    {
        print("In the test environment");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Beginning
        if(step == 0) {
            to_game.text = "Welcome to the Test Suite! In order to continute, press y";
            if(Input.GetKeyDown(KeyCode.Y)) {
                step++;
            }
        }
        //Walking Test
        else if(step == 1) {
            to_game.text = "To test if walking works, hold down the d or a key";
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) {
                to_game2.text = "If walking works right, press y to continue";
                can_press_y = true;
            }
            if(Input.GetKeyDown(KeyCode.Y) && can_press_y) {
                    to_game2.text = "";
                    can_press_y = false;
                    step++;
                }
        }
        //Jumping Test
        else if(step == 2) {
            to_game.text = "Now lets test jumping. Hold down the spacebar to jump at various heights. You can also hold a or d along with spacebar to jump diagonally!";
            if(Input.GetKeyDown(KeyCode.Space)) {
                to_game2.text = "If the jumping is working, press y to continue";
                can_press_y = true;
            }
            if(Input.GetKeyDown(KeyCode.Y) && can_press_y) {
                to_game2.text = "";
                can_press_y = false;
                step++;
            }
        }
        //Going off screen test
        else if(step == 3) {
            seconds += Time.deltaTime;
            to_game.text = "Now test what happens when you go off the boundaries of the screen";
            if(seconds > 3f) {
                to_game2.text = "If you teleport to the other side, press y to continue";
                can_press_y = true;
            }
            if(Input.GetKeyDown(KeyCode.Y) && can_press_y) {
                to_game2.text = "";
                can_press_y = false;
                seconds = 0f;
                step++;
            }
        }
        else if(step == 4) {
            seconds += Time.deltaTime;
            to_game.text = "Now test jumping on top of the platforms";
            if(seconds > 3f) {
                to_game2.text = "If jumping on the platforms works, press y to continue";
                can_press_y = true;
            }
            if(Input.GetKeyDown(KeyCode.Y) && can_press_y) {
                to_game2.text = "";
                can_press_y = false;
                seconds = 0f;
                step++;
            }
        }
        else if(step == 5) {
            to_game.text = "All the basic controls are a success, game is ready to be played";
            to_game2.text = "Press y to go back to the game menu";
            can_press_y = true;
            if(Input.GetKeyDown(KeyCode.Y)) {
                SceneManager.LoadScene(0);
            }
        }
    }
}
