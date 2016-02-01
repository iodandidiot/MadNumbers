using UnityEngine;
using System.Collections;

public class rocket1 : MonoBehaviour {

    public bool left;
    public bool right;
    public float leftX;
    public float rightX;
    public enum rocket {rocket1=0,rocket2=1};
    public rocket _thisRocket;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (left && gameObject.transform.position.x > leftX)
        {
            transform.position = new Vector2(transform.position.x - 0.02f, transform.position.y);
        }
        if (left && gameObject.transform.position.x <= leftX)
        {
            if (_thisRocket == rocket.rocket2)
            {
                StartCoroutine("stop");
            }
            else
            {
                left = false;
                right = true;
            }
            
        }
        if (right && gameObject.transform.position.x < rightX)
        {
            transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);
        }
        if (gameObject.transform.position.x >= rightX)
        {
            if (_thisRocket == rocket.rocket1)
            {
                StartCoroutine("stop");
            }
            else
            {
                left = true;
                right = false;
            }
        }
	}

    IEnumerator stop()
    {
        yield return new WaitForSeconds(20f);
        if (_thisRocket == rocket.rocket2)
        {
            left = false;
            right = true;
        }
        else
        {
            left = true;
            right = false;
        }

    }
}
