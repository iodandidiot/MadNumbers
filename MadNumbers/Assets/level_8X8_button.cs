﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class level_8X8_button : MonoBehaviour {

    public void onClick()
    {
        PlayerPrefs.SetString("Level", "game8X8");
        PlayerPrefs.SetString("Level_target", "kristalls");
        SceneManager.LoadScene("game8X8");

    }
}
