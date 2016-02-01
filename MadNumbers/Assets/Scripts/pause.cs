using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {

    public GameObject pauseSet;

    public void onPause()
    {
        pauseSet.SetActive(true);
    }
    public void offPause()
    {
        pauseSet.SetActive(false);
    }
}
