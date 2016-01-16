using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour {
    public Text FinalText;
    public Text FinalScore;
	// Use this for initialization
	void Start () 
    {
        if (PlayerPrefs.GetString("Finish") == "Win")
        {
            FinalText.text = "You Win";
        }
        else
        {
            FinalText.text = "You Lost";
        }
        FinalScore.text = string.Format("{0}", PlayerPrefs.GetInt("FinishScore"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
