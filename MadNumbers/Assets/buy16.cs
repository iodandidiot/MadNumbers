using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buy16 : MonoBehaviour {

	public Text backText;

    public void onBuy()
    {
        PlayerPrefs.SetInt("BackCount", PlayerPrefs.GetInt("BackCount") + 16);

        backText.text = string.Format("{0}", PlayerPrefs.GetInt("BackCount"));
    }
}
