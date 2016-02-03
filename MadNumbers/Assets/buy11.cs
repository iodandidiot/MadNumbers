using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buy11 : MonoBehaviour {

    public Text backText;

    public void onBuy()
    {
        PlayerPrefs.SetInt("BackCount", PlayerPrefs.GetInt("BackCount") + 11);

        backText.text = string.Format("{0}", PlayerPrefs.GetInt("BackCount"));
    }
}
