using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	
    public void OnRestart()
    {
        switch (PlayerPrefs.GetString("Level"))
        {
            case "game6X6":
                SceneManager.LoadScene("game6X6");
                break;
            case "game8X8":
                SceneManager.LoadScene("game8X8");
                break;
            case "game12X12":
                SceneManager.LoadScene("game12X12");
                break;
            case "game16X16":
                SceneManager.LoadScene("game16X16");
                break;
            default:
                SceneManager.LoadScene("MainMenu");
                break;
        }
        
    }
}
