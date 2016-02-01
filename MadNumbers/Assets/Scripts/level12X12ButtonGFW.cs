using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class level12X12ButtonGFW : MonoBehaviour {

    public void onClick()
    {
        PlayerPrefs.SetString("Level", "game12X12");
        PlayerPrefs.SetString("Level_target", "GFW");
        if (PlayerPrefs.GetInt("Help") == 0)
        {
            SceneManager.LoadScene("help");
        }
        else
        {
            SceneManager.LoadScene("game12X12");
        }

    }
}
