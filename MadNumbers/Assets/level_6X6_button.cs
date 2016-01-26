using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class level_6X6_button : MonoBehaviour {

    public void onClick()
    {
        PlayerPrefs.SetString("Level", "game6X6");
        PlayerPrefs.SetString("Level_target", "kristalls");
        SceneManager.LoadScene("game6X6");

    }
}
