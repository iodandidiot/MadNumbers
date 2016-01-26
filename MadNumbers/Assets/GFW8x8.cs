using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GFW8x8 : MonoBehaviour {

    public Text textWin;
    public Text textLoos;
    // Use this for initialization
    void Start()
    {
        textWin.text = string.Format("{0}", PlayerPrefs.GetInt("game8X8Win"));
        textLoos.text = string.Format("{0}", PlayerPrefs.GetInt("game8X8Loos"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
