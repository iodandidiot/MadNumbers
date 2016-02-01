using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class help_script : MonoBehaviour {

    public GameObject help1;
    public GameObject help2;
    public GameObject help3;
    public GameObject help4;
    public GameObject help5;
    public GameObject touch11;
    public GameObject touch4;
    public GameObject set1;
    public GameObject set2;
    public GameObject touch5;
    public GameObject touch6;
    public Image score;
    public Text textScore;
    public Sprite[] scores;

	// Use this for initialization
	void Start () 
    {
        help1.SetActive(true);
        set1.SetActive(true);
        set2.SetActive(false);
        help2.SetActive(false);
        help3.SetActive(false);
        help4.SetActive(false);
        help5.SetActive(false);
        score.gameObject.SetActive(false);
        touch5.SetActive(false);
        touch6.SetActive(false);
        StartCoroutine("help_1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator help_1()
    {
        yield return new WaitForSeconds(2f);
        help2.SetActive(true);
        help1.SetActive(false);
        for (int i = 0; i < 10; )
        {
            for (int j = 0; j < 5; j++)
            {
                touch11.gameObject.transform.localScale = new Vector2(touch11.gameObject.transform.localScale.x - 0.015f, touch11.gameObject.transform.localScale.y - 0.015f);
                yield return new WaitForSeconds(0.1f);
            }
            for (int j = 0; j < 5; j++)
            {
                touch11.gameObject.transform.localScale = new Vector2(touch11.gameObject.transform.localScale.x + 0.015f, touch11.gameObject.transform.localScale.y + 0.015f);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
    IEnumerator help_2()
    {
        yield return new WaitForSeconds(0.5f);
        help2.SetActive(false);
        help3.SetActive(true);
        set1.SetActive(false);
        set2.SetActive(true);
        for (int i = 0; i < 2;i++)
        {
            for (int j = 0; j < 5; j++)
            {
                touch4.gameObject.transform.localScale = new Vector2(touch4.gameObject.transform.localScale.x - 0.015f, touch4.gameObject.transform.localScale.y - 0.015f);
                yield return new WaitForSeconds(0.1f);
            }
            for (int j = 0; j < 5; j++)
            {
                touch4.gameObject.transform.localScale = new Vector2(touch4.gameObject.transform.localScale.x + 0.015f, touch4.gameObject.transform.localScale.y + 0.015f);
                yield return new WaitForSeconds(0.1f);
            }
        }
        touch4.SetActive(false);
        yield return new WaitForSeconds(2f);
        StartHelp3();
    }

    public void StartHelp2()
    {
        StopCoroutine("help_1");
        StartCoroutine("help_2");        
    }

    public void StartHelp3()
    {
        help3.SetActive(false);
        help4.SetActive(true);
        set2.SetActive(false);
        score.gameObject.SetActive(true);
        touch5.SetActive(true);
        StartCoroutine("help_3");
    }
    IEnumerator help_3()
    {

        for (int i = 0; i < 2;)
        {
            for (int j = 0; j < 5; j++)
            {
                touch5.gameObject.transform.localScale = new Vector2(touch5.gameObject.transform.localScale.x - 0.015f, touch5.gameObject.transform.localScale.y - 0.015f);
                yield return new WaitForSeconds(0.1f);
            }
            for (int j = 0; j < 5; j++)
            {
                touch5.gameObject.transform.localScale = new Vector2(touch5.gameObject.transform.localScale.x + 0.015f, touch5.gameObject.transform.localScale.y + 0.015f);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
    public void StartHelp4()
    {
        score.sprite = scores[0];
        textScore.text = "108";
        StopCoroutine("help_3");
        StartCoroutine("help_4");
        touch6.SetActive(true);

    }
    IEnumerator help_4()
    {

        for (int i = 0; i < 2; )
        {
            for (int j = 0; j < 5; j++)
            {
                touch6.gameObject.transform.localScale = new Vector2(touch6.gameObject.transform.localScale.x - 0.015f, touch6.gameObject.transform.localScale.y - 0.015f);
                yield return new WaitForSeconds(0.1f);
            }
            for (int j = 0; j < 5; j++)
            {
                touch6.gameObject.transform.localScale = new Vector2(touch6.gameObject.transform.localScale.x + 0.015f, touch6.gameObject.transform.localScale.y + 0.015f);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
    public void StartHelp5()
    {
        textScore.text = "100";
        StopCoroutine("help_4");
        StartCoroutine("help_5");
    }
    IEnumerator help_5()
    {
        score.sprite = scores[1];
        yield return new WaitForSeconds(2f);
        score.gameObject.SetActive(false);
        help4.SetActive(false);
        help5.SetActive(true);
        score.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        if (PlayerPrefs.GetInt("Help") == 0)
        {
            PlayerPrefs.SetInt("Help", 1);
            if (PlayerPrefs.GetString("Level") == "game6X6")
            {
                SceneManager.LoadScene("game6X6");
            }
            if (PlayerPrefs.GetString("Level") == "game8X8")
            {
                SceneManager.LoadScene("game8X8");
            }
            if (PlayerPrefs.GetString("Level") == "game12X12")
            {
                SceneManager.LoadScene("game12X12");
            }
        }
    }
}
