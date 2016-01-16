using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GoMainMenu : MonoBehaviour {

	// Use this for initialization
    public void MainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
