using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GFW12x12 : MonoBehaviour {

    public Text textWin;
    public Text textLoos;
    // Use this for initialization
    void Start()
    {
        textWin.text = string.Format("{0}", PlayerPrefs.GetInt("game12X12Win"));
        textLoos.text = string.Format("{0}", PlayerPrefs.GetInt("game12X12Loos"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
