using UnityEngine;
using System.Collections;

public class CompAnim : MonoBehaviour {

    public GameObject almaz;
    public GameObject eye;
    public GameObject say;
    public GameObject whiteFlag;
    public GameObject redFlag;
    public Game_PlayerVsPc pole;
    private int PlayerPoints;
    private int CompPoints;
    bool whitef=false;
    bool redf = false;
    Animator whiteFlagAnim;
    Animator redFlagAnim;
    public AudioClip [] robot;
    AudioSource _audio;
    bool sayBool;
	// Use this for initialization
	void Start () 
    {
        _audio = gameObject.GetComponent<AudioSource>();
        StartCoroutine("animEye");
        whiteFlag.gameObject.SetActive(false);
        redFlag.gameObject.SetActive(false);
        PlayerPoints = pole.PlayerPoints;
        CompPoints = pole.CompPoints;
        whiteFlagAnim = whiteFlag.GetComponent<Animator>();
        redFlagAnim = redFlag.GetComponent<Animator>();
        StartCoroutine("Say");
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayerPoints = pole.PlayerPoints;
        CompPoints = pole.CompPoints;
        if (CompPoints - PlayerPoints > 20 && !whitef)
        {
            setRedFlag();
        }
        else
        {
            redFlag.gameObject.SetActive(false);
            StopCoroutine("setRedFlagCor");
        }
        if (PlayerPoints - CompPoints > 20 && !whitef)
        {
                iLost();
        }
	}

    IEnumerator animEye()
    {
        for (int i = 1; i > 0; )
        {
            almaz.gameObject.SetActive(false);
            eye.gameObject.SetActive(true);
            yield return new WaitForSeconds(20f);
            almaz.gameObject.SetActive(true);
            eye.gameObject.SetActive(false);
            yield return new WaitForSeconds(Random.Range(15,30));
        }        
    }

    public void setWhitFlag()
    {
        StopCoroutine("WhiteFlag");
        StartCoroutine("WhiteFlag");
        whitef = false;
    }

    IEnumerator WhiteFlag()
    {
        whiteFlag.gameObject.SetActive(false);
        yield return new WaitForSeconds(10f);
        whiteFlag.gameObject.SetActive(true);
        whitef = true;
        whiteFlagAnim.enabled=true;
        for (int i = 0; i < 10; )
        {
            yield return new WaitForSeconds(5f);
            whiteFlagAnim.enabled = false;
            yield return new WaitForSeconds(15f);
            whiteFlagAnim.enabled = true;
        }
        
    }
    public void setRedFlag()
    {
        StopCoroutine("setRedFlagCor");
        StopCoroutine("WhiteFlag");
        StartCoroutine("setRedFlagCor");
        redf = false;
    }

    IEnumerator setRedFlagCor()
    {

        redFlag.gameObject.SetActive(true);
        redf = true;
        redFlagAnim.enabled = true;
        for (int i = 0; i < 10; )
        {
            yield return new WaitForSeconds(5f);
            redFlagAnim.enabled = false;
            yield return new WaitForSeconds(20f);
            redFlagAnim.enabled = true;
        }

    }
    public void myStep()
    {
        if (!sayBool)
        {
            _audio.clip = robot[0];
            _audio.Play();
            StartCoroutine("Say");
        }
        
    }
    public void machinMaslo()
    {
        if (!sayBool)
        {
            _audio.clip = robot[1];
            _audio.Play();
            StartCoroutine("Say");
        }
        
    }
    public void youSmart()
    {
        if (!sayBool)
        {
            if (Random.Range(0, 2) == 1) _audio.clip = robot[3];
            else _audio.clip = robot[8];
            _audio.Play();
            StartCoroutine("Say");
        }
        
    }
    public void youLoose()
    {
        if (!sayBool)
        {
            if (Random.Range(0, 2) == 1) _audio.clip = robot[7];
            else _audio.clip = robot[2];
            _audio.Play();
            StartCoroutine("Say");
        }
        
    }
    public void iLost()
    {
        if (!sayBool)
        {
            _audio.clip = robot[6];
            _audio.Play();
            StartCoroutine("Say");
        }

    }
    IEnumerator Say()
    {
        sayBool = true;
        say.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        say.gameObject.SetActive(false);
        sayBool = false;
    }
}
