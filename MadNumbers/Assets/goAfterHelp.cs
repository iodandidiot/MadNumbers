using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goAfterHelp : MonoBehaviour {

    public void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("Help") == 0)
        {
            PlayerPrefs.SetInt("Help", 1);
            if (PlayerPrefs.GetString("Level") == "game6X6")
            {
                SceneManager.LoadScene("game6X6");
            }
            if (PlayerPrefs.GetString("Level") == "game8X8")
            {
                SceneManager.LoadScene("game8X8");
            }
            if (PlayerPrefs.GetString("Level") == "game12X12")
            {
                SceneManager.LoadScene("game12X12");
            }
        }
        
    }
}
