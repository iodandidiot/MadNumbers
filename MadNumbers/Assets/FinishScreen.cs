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
            if (PlayerPrefs.GetString("Level_target") == "GFW")
            {
                if (PlayerPrefs.GetString("Level") == "game6X6")
                {
                    PlayerPrefs.SetInt("game6X6Win", PlayerPrefs.GetInt("game6X6Win") + 1);
                }
                if (PlayerPrefs.GetString("Level") == "game8X8")
                {
                    PlayerPrefs.SetInt("game8X8Win", PlayerPrefs.GetInt("game8X8Win") + 1);
                }
                if (PlayerPrefs.GetString("Level") == "game12X12")
                {
                    PlayerPrefs.SetInt("game12X12Win", PlayerPrefs.GetInt("game12X12Win") + 1);
                }
            }
        }
        else
        {
            FinalText.text = "You Lost";
            if (PlayerPrefs.GetString("Level_target") == "GFW")
            {
                if (PlayerPrefs.GetString("Level") == "game6X6")
                {
                    PlayerPrefs.SetInt("game6X6Loos", PlayerPrefs.GetInt("game6X6Loos") + 1);
                }
                if (PlayerPrefs.GetString("Level") == "game8X8")
                {
                    PlayerPrefs.SetInt("game8X8Loos", PlayerPrefs.GetInt("game8X8Loos") + 1);
                }
                if (PlayerPrefs.GetString("Level") == "game12X12")
                {
                    PlayerPrefs.SetInt("game12X12Loos", PlayerPrefs.GetInt("game12X12Loos") + 1);
                }
            }
        }
        FinalScore.text = string.Format("{0}", PlayerPrefs.GetInt("FinishScore"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
