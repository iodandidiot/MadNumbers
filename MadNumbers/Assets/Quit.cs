using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        if (PlayerPrefs.GetInt("Help") == 0)
        {
            PlayerPrefs.SetInt("BackCount", PlayerPrefs.GetInt("BackCount") + 5);
        }
	}

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            Application.Quit();
        }
    }
}
