using UnityEngine;
using System.Collections;

public class FirstRun : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        if (PlayerPrefs.GetInt("FirstRun") == 0)
        {
            PlayerPrefs.SetInt("BackCount", 5);
        }
	}
	
	
}
