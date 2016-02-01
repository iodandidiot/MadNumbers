using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class frames : MonoBehaviour {

    public Sprite [] frame;
    RectTransform _pos;
    Image _image;
    public Game_PlayerVsPc pole;
    private int PlayerPoints;
    private int CompPoints;
    bool animation1;
    bool animation2;
    float _y;
    float scaleY;
	// Usebool anim1; this for initialization
	void Start () 
    {
        PlayerPoints = pole.PlayerPoints;
        CompPoints = pole.CompPoints;
        _image = gameObject.GetComponent<Image>();
        _pos = gameObject.GetComponent<RectTransform>();
        _y = _pos.position.y;
        scaleY = gameObject.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    PlayerPoints = pole.PlayerPoints;
        CompPoints = pole.CompPoints;
        if (Mathf.Abs(CompPoints - PlayerPoints)<20)
        {
            _pos.position = new Vector2(_pos.position.x, _y + (CompPoints - PlayerPoints) / 100f);
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, scaleY + (CompPoints - PlayerPoints) / 400f); 
        }
        
        if (PlayerPoints < CompPoints)
        {
                       
            if (!animation1)
            {
                StartCoroutine("anim1");
            }
            
        }
        else
        {                        
            if (!animation2)
            {
                StartCoroutine("anim2");
            }
        }
	}
    IEnumerator anim1()
    {
        StopCoroutine("anim2");
        animation1 = true;
        animation2 = false;
        for (int i = 1; i > 0; )
        {
            _image.sprite = frame[0];
            yield return new WaitForSeconds(0.2f);
            _image.sprite = frame[1];
            yield return new WaitForSeconds(0.2f);
            _image.sprite = frame[2];
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator anim2()
    {
        animation2 = true;
        animation1 = false;
        StopCoroutine("anim1");
        for (int i = 1; i > 0; )
        {
            _image.sprite = frame[3];
            yield return new WaitForSeconds(0.2f);
            _image.sprite = frame[4];
            yield return new WaitForSeconds(0.2f);
            _image.sprite = frame[5];
            yield return new WaitForSeconds(0.2f);
        }
    }
}
