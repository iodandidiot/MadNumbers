using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buy24 : MonoBehaviour {

    public Text backText;

    public void onBuy()
    {
        PlayerPrefs.SetInt("BackCount", PlayerPrefs.GetInt("BackCount") + 24);

        backText.text = string.Format("{0}", PlayerPrefs.GetInt("BackCount"));
    }
}
