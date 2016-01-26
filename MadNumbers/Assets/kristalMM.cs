using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class kristalMM : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Text _text = gameObject.GetComponent<Text>();
        _text.text = string.Format("x {0}", PlayerPrefs.GetInt("Kristalls"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
