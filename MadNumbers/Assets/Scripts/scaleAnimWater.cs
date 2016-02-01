using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scaleAnimWater : MonoBehaviour {

    public GameObject PlayerGreen;
    public GameObject CompGreen;
    public GameObject PlayerRed;
    public GameObject CompRed;
    public Game_PlayerVsPc pole;
    private int PlayerPoints;
    private int CompPoints;
    void Start()
    {
        PlayerPoints = pole.PlayerPoints;
        CompPoints = pole.CompPoints;
        PlayerGreen.gameObject.SetActive(false);
        CompGreen.gameObject.SetActive(false);
        PlayerRed.gameObject.SetActive(false);
        CompRed.gameObject.SetActive(false);
    }

    void Update()
    {
        PlayerPoints = pole.PlayerPoints;
        CompPoints = pole.CompPoints;
        if (PlayerPoints >= CompPoints)
        {
            CompGreen.gameObject.SetActive(false);
            PlayerRed.gameObject.SetActive(false);
            PlayerGreen.gameObject.SetActive(true);
            CompRed.gameObject.SetActive(true);
            PlayerGreen.gameObject.transform.localScale = new Vector2(PlayerRed.gameObject.transform.localScale.x, 0.2f + (PlayerPoints - CompPoints) / 100f);
            CompRed.gameObject.transform.localScale = new Vector2(PlayerRed.gameObject.transform.localScale.x, 0.2f - (PlayerPoints - CompPoints) / 100f);
        }
        else
        {
            CompGreen.gameObject.SetActive(true);
            PlayerRed.gameObject.SetActive(true);
            PlayerGreen.gameObject.SetActive(false);
            CompRed.gameObject.SetActive(false);
            CompGreen.gameObject.transform.localScale = new Vector2(PlayerRed.gameObject.transform.localScale.x, 0.2f + (CompPoints - PlayerPoints) / 100f);
            PlayerRed.gameObject.transform.localScale = new Vector2(PlayerRed.gameObject.transform.localScale.x, 0.2f - (CompPoints - PlayerPoints) / 100f);
        }
    }
}
