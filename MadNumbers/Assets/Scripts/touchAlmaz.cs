using UnityEngine;
using System.Collections;

public class touchAlmaz : MonoBehaviour {

    void Start()
    {
        if (PlayerPrefs.GetString("Level_target") != "kristalls") 
        {
            Destroy(gameObject);
        }
    }

    public void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
