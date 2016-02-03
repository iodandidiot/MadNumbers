using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {

    public GameObject pauseSet;
    bool on=false;

    public void onPause()
    {
        pauseSet.SetActive(true);
        on = true;
    }
    public void offPause()
    {
        pauseSet.SetActive(false);
        on = false;
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Escape)))
        {
            if (on)
            {
                offPause();
                return;
            }
            else
            {
                onPause();
                return;
            }
        }
    }
}
