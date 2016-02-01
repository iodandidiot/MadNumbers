using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class level6X6ButtonGFW : MonoBehaviour {

    public void onClick()
    {
        PlayerPrefs.SetString("Level", "game6X6");
        PlayerPrefs.SetString("Level_target", "GFW");
        if (PlayerPrefs.GetInt("Help") == 0)
        {
            SceneManager.LoadScene("help");
        }
        else
        {
            SceneManager.LoadScene("game6X6");
        }

    }
}
