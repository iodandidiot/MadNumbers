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
    Animator whiteFlagAnim;
    Animator redFlagAnim;
	// Use this for initialization
	void Start () 
    {
        StartCoroutine("animEye");
        whiteFlag.gameObject.SetActive(false);
        redFlag.gameObject.SetActive(false);
        PlayerPoints = pole.PlayerPoints;
        CompPoints = pole.CompPoints;
        whiteFlagAnim = whiteFlag.GetComponent<Animator>();
        redFlagAnim = redFlag.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayerPoints = pole.PlayerPoints;
        CompPoints = pole.CompPoints;
        if (CompPoints - PlayerPoints > 20 && !whitef)
        {
            redFlag.gameObject.SetActive(true);
        }
        else
        {
            redFlag.gameObject.SetActive(false);
        }
	}

    IEnumerator animEye()
    {
        for (int i = 1; i > 0; )
        {
            almaz.gameObject.SetActive(false);
            eye.gameObject.SetActive(true);
            yield return new WaitForSeconds(10f);
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
        yield return new WaitForSeconds(0.6f);
        whiteFlagAnim.enabled = false;
        yield return new WaitForSeconds(10f);
        whiteFlagAnim.enabled = true;
    }

}
