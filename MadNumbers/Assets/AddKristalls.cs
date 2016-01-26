using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddKristalls : MonoBehaviour {
    Text _text;
    public Image _image;
    public Sprite[] _sprites;
	// Use this for initialization
	void Start () 
    {
        _text = gameObject.GetComponent<Text>();
        _text.text = string.Format("x {0}", PlayerPrefs.GetInt("Kristalls"));
        if (PlayerPrefs.GetString("Finish") == "Win" && PlayerPrefs.GetString("Level_target") == "kristalls")
        {
            if (PlayerPrefs.GetString("Level") == "game6X6" || PlayerPrefs.GetString("Level") == "game8X8")
            {
                StartCoroutine(_AddKristalls(1));
            }
            else
            {
                StartCoroutine(_AddKristalls(2));
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    IEnumerator _AddKristalls(int kol)
    {
        yield return new WaitForSeconds(1f);        
        _image.sprite = _sprites[1];
        for (int i = 0; i < 5; i++)
        {
            _image.gameObject.transform.localScale = new Vector2(_image.gameObject.transform.localScale.x + 0.02f, _image.gameObject.transform.localScale.y + 0.02f);
            yield return new WaitForSeconds(0.2f);
        }
        for (int i = 0; i < 5; i++)
        {
            _image.gameObject.transform.localScale = new Vector2(_image.gameObject.transform.localScale.x - 0.02f, _image.gameObject.transform.localScale.y - 0.02f);
            yield return new WaitForSeconds(0.1f);
        }
        PlayerPrefs.SetInt("Kristalls", PlayerPrefs.GetInt("Kristalls") + kol);
        _text.text = string.Format("x {0}", PlayerPrefs.GetInt("Kristalls"));
        _image.sprite = _sprites[0];
    }
}
