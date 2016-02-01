using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GFW6x6 : MonoBehaviour {

    public Text textWin;
    public Text textLoos;
	// Use this for initialization
	void Start () 
    {
        textWin.text = string.Format("{0}", PlayerPrefs.GetInt("game6X6Win"));
        textLoos.text = string.Format("{0}", PlayerPrefs.GetInt("game6X6Loos"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
