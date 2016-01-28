using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class level8X8ButtonGFW : MonoBehaviour {

    public void onClick()
    {
        PlayerPrefs.SetString("Level", "game8X8");
        PlayerPrefs.SetString("Level_target", "GFW");
        if (PlayerPrefs.GetInt("Help") == 0)
        {
            SceneManager.LoadScene("help");
        }
        else
        {
            SceneManager.LoadScene("game8X8");
        }

    }
}
