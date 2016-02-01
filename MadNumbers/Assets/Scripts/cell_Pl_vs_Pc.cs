using UnityEngine;
using System.Collections;

public class cell_Pl_vs_Pc : MonoBehaviour {

    public Sprite[] numbers;
    public Sprite[] colors;
    public Sprite[] colorsDown;
    public GameObject Numbers;
    public int x;
    public int y;
    GameObject pole;
    GameObject NumbersThis;
    GameObject CrEmpty;
    //public GameObject ColorThis;
    int cellNumber;
    int color;
    bool isColor=false;
    public CompAnim compAnim;
    float numberPosition;
    public GameObject empty;
    SpriteRenderer emptySprite;
    GameObject almaz;
    //public CompAnim _compAnim;
    // Use this for initialization
    void Start()
    {
        almaz = GameObject.Find("almazik_0");
        compAnim = GameObject.Find("compAnim").GetComponent<CompAnim>();
        pole = GameObject.FindWithTag("Pole");
        if (NumbersThis == null)
        {
            cellNumber = Random.Range(0, 11);
            NumbersThis = (GameObject)Instantiate(Numbers, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            SpriteRenderer chouseSprite = NumbersThis.AddComponent<SpriteRenderer>();
            chouseSprite.sprite = numbers[cellNumber];
            numberPosition = NumbersThis.gameObject.transform.position.y;
            chouseSprite.sortingLayerName = "cell";
            chouseSprite.sortingOrder = 3;
        }
        
        //ColorThis = (GameObject)Instantiate(Numbers, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
        if (!isColor)
        {
            color = Random.Range(0, 2);
            chouseColor.sprite = colors[color];
            chouseColor.sortingLayerName = "cell";
            chouseColor.sortingOrder = 1;
        }
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        Game_PlayerVsPc gPole = pole.GetComponent<Game_PlayerVsPc>();
        if (almaz ==null )
        {
            if (cellNumber > 6 && color == 0 && gPole.Turn==0)
            {
                compAnim.youSmart();
            }
            if (cellNumber > 6 && color == 1 && gPole.Turn == 0)
            {
                compAnim.youLoose();
            }
            if (cellNumber > 6 && color == 1 && gPole.Turn == 1)
            {
                compAnim.machinMaslo();
            }
            if (gPole.Turn == 1)
            {
                compAnim.myStep();
            }
            if (color == 0)
            {
                SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
                chouseColor.sprite = colorsDown[2];

            }
            else
            {
                SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
                chouseColor.sprite = colorsDown[3];

            }
            StartCoroutine("onDestroy");
        }
        
    }
    public int Number
    {
        get
        {
            if (color == 0)
            {
                return cellNumber+1;
            }
            else
            {
                return -cellNumber-1;
            }
        }
        set
        {
            cellNumber = value;
        }
    }
    public void Chousen()
    {
        if (color == 0)
        {            
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            chouseColor.sprite = colorsDown[0];
            chouseColor.sortingLayerName = "cell";
            chouseColor.sortingOrder = 2;
            NumbersThis.gameObject.transform.position=new Vector2 (NumbersThis.gameObject.transform.position.x,NumbersThis.gameObject.transform.position.y +0.1f);
        }
        else
        {            
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            chouseColor.sprite = colorsDown[1];
            chouseColor.sortingLayerName = "cell";
            chouseColor.sortingOrder = 2;
            NumbersThis.gameObject.transform.position = new Vector2(NumbersThis.gameObject.transform.position.x, NumbersThis.gameObject.transform.position.y + 0.1f);
        }   
    }
    public void UnChousen()
    {
        if (color == 0)
        {            
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            chouseColor.sprite = colors[0];
            chouseColor.sortingLayerName = "cell";
            chouseColor.sortingOrder = 1;
            NumbersThis.gameObject.transform.position = new Vector2(NumbersThis.gameObject.transform.position.x, numberPosition);
            
        }
        else
        {            
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            chouseColor.sprite = colors[1];
            chouseColor.sortingLayerName = "cell";
            chouseColor.sortingOrder = 1;
            NumbersThis.gameObject.transform.position = new Vector2(NumbersThis.gameObject.transform.position.x, numberPosition);
            
        }
    }
    public int firstNumber
    {        
        set
        {
            cellNumber = value;
            NumbersThis = (GameObject)Instantiate(Numbers, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            SpriteRenderer chouseSprite = NumbersThis.AddComponent<SpriteRenderer>();
            chouseSprite.sprite = numbers[cellNumber];
            chouseSprite.sortingLayerName = "cell";
            chouseSprite.sortingOrder = 3;
            numberPosition = NumbersThis.gameObject.transform.position.y;
        }
    }
    public int firstColor
    {
        set
        {
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            color = value;
            chouseColor.sprite = colors[color];
            chouseColor.sortingLayerName = "cell";
            chouseColor.sortingOrder = 1;
            isColor = true;
        }
    }
    IEnumerator onDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        if (color == 0)
        {
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            chouseColor.sprite = colorsDown[0];

        }
        else
        {
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            chouseColor.sprite = colorsDown[1];

        }  
        yield return new WaitForSeconds(0.1f);
        Game_PlayerVsPc gPole = pole.GetComponent<Game_PlayerVsPc>();
        gPole.ChangePoints(this.Number);
        gPole.ChouseLine(x, y);
        gPole.setBack(x, y, cellNumber, color);
        compAnim.setWhitFlag();
        //Destroy(ColorThis);
        CrEmpty = (GameObject)Instantiate(empty, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        //emptySprite = CrEmpty.AddComponent<SpriteRenderer>();
        ////emptySprite.sortingLayerName = "cell";
        ////emptySprite.sortingOrder = 0;
        Destroy(NumbersThis);
        Destroy(gameObject);
    }
}
