﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class level_12X12_button : MonoBehaviour {

    public void onClick()
    {
        PlayerPrefs.SetString("Level", "game12X12");
        PlayerPrefs.SetString("Level_target", "kristalls");
        SceneManager.LoadScene("game12X12");

    }
}
