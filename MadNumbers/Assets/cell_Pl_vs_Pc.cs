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
    //public GameObject ColorThis;
    int cellNumber;
    int color;
    bool isColor=false;

    // Use this for initialization
    void Start()
    {
        pole = GameObject.FindWithTag("Pole");
        if (NumbersThis == null)
        {
            cellNumber = Random.Range(0, 11);
            NumbersThis = (GameObject)Instantiate(Numbers, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            SpriteRenderer chouseSprite = NumbersThis.AddComponent<SpriteRenderer>();
            chouseSprite.sprite = numbers[cellNumber];
            chouseSprite.sortingLayerName = "cell";
            chouseSprite.sortingOrder = 2;
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
        gPole.ChangePoints(this.Number);
        gPole.ChouseLine(x, y);
        gPole.setBack(x, y, cellNumber, color);
        //Destroy(ColorThis);
        Destroy(NumbersThis);
        Destroy(gameObject);
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
        }
        else
        {            
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            chouseColor.sprite = colorsDown[1];
        }   
    }
    public void UnChousen()
    {
        if (color == 0)
        {            
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            chouseColor.sprite = colors[0];
        }
        else
        {            
            SpriteRenderer chouseColor = gameObject.GetComponent<SpriteRenderer>();
            chouseColor.sprite = colors[1];
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
            chouseSprite.sortingOrder = 2;
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

}
