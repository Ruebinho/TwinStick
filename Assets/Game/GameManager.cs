using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    public bool gamepaused = false;

    private float initialfixedDeltaTime;

	// Use this for initialization
	void Start () {
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(1));
        print(PlayerPrefsManager.IsLevelUnlocked(2));
        initialfixedDeltaTime = Time.fixedDeltaTime;
    }
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1")){
            recording = false;
        } else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        { 
            if (!gamepaused)
            {
                PauseGame();
            } else if (gamepaused)
            {
                UnpauseGame();
            }
        }

    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        gamepaused = true;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = initialfixedDeltaTime;
        gamepaused = false;
    }

    private void OnApplicationPause(bool pause)
    {
        gamepaused = pause;
        //PauseGame();
    }
}
