using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_PlayerVsPc : MonoBehaviour {

    public GameObject cell;
    public int poleRazmer;
    GameObject[,] cells;
    public int PlayerPoints;
    public int CompPoints;
    public Text pointsTextPlayer;
    public Text pointsTextComp;
    private int _turn = 1;
    public int maxDepth;
    bool start;
    public Image pointsTextPlayerBG;
    public Image pointsTextCompBG;
    public Sprite[] pointsBG;
    public float poleKoef;
    public float poleKoefx;
    public float poleKoefy;
    // Use this for initialization
    void Start()
    {        
        cells = new GameObject[poleRazmer, poleRazmer];
        Generate();
        pointsTextPlayer.text = string.Format("{0}", PlayerPoints);
        pointsTextComp.text = string.Format("{0}", CompPoints);        
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            ChouseLine(Random.Range(0, poleRazmer), Random.Range(0, poleRazmer), true);
            start = true;
        }        
    }

    private void Generate()
    {
        for (int i = 0; i < poleRazmer; i++)
        {
            for (int j = 0; j < poleRazmer; j++)
            {
                cells[i, j] = (GameObject)Instantiate(cell, new Vector2(poleKoefx + j * poleKoef, poleKoefy - i * poleKoef), Quaternion.identity);
                cell_Pl_vs_Pc cellPozition = cells[i, j].GetComponent<cell_Pl_vs_Pc>();
                cellPozition.x = j;
                cellPozition.y = i;

            }
        }
        
    }

    public void ChangePoints(int number)
    {
        if (_turn == 0)
        {
            PlayerPoints += number;
            pointsTextPlayer.text = string.Format("{0}", PlayerPoints);
            if (number > 0)
            {
                pointsTextPlayerBG.sprite = pointsBG[1];
            }
            else
            {
                pointsTextPlayerBG.sprite = pointsBG[2];
            }
            StartCoroutine(ChangeScoreBg(0));
        }
        else
        {
            CompPoints += number;
            pointsTextComp.text = string.Format("{0}", CompPoints);
            if (number > 0)
            {
                pointsTextCompBG.sprite = pointsBG[4];
            }
            else
            {
                pointsTextCompBG.sprite = pointsBG[5];
            }
            StartCoroutine(ChangeScoreBg(1));
        }

    }
    public void ChouseLine(int x, int y,bool start=false)
    {
        OffAllCollaider();
        bool isEnd=true;
        if (_turn == 0)
        {
            StartCoroutine(CompStep(x));
            for (int j = 0; j < poleRazmer; j++)
            {
                if (cells[j, x] != null && j != y || cells[j, x] != null && start)
                {
                    isEnd = false;
                    //PolygonCollider2D cellColl = cells[j, x].AddComponent<PolygonCollider2D>();
                    //SpriteRenderer _render = cells[j, x].GetComponent<SpriteRenderer>();
                    //_render.color = Color.blue;
                    cell_Pl_vs_Pc cellChosen = cells[j, x].GetComponent<cell_Pl_vs_Pc>();

                    cellChosen.Chousen();
                }
                
            }            
            _turn = 1;
            if (isEnd) EndGame(0,x,y);
            //StartCoroutine(CompStep(x));
            return;
        }
        else
        {
            for (int i = 0; i < poleRazmer; i++)
            {
                if (cells[y, i] != null && i != x || cells[y, i] != null && start)
                {
                    isEnd = false;
                    PolygonCollider2D cellColl = cells[y, i].AddComponent<PolygonCollider2D>();
                    //SpriteRenderer _render = cells[y, i].GetComponent<SpriteRenderer>();
                    //_render.color = Color.blue;
                    cell_Pl_vs_Pc cellChosen = cells[y, i].GetComponent<cell_Pl_vs_Pc>();
                    cellChosen.Chousen();

                }
            }
            _turn = 0;
            if (isEnd) EndGame(1,x,y);
            return;
        }
    }
    private void OffAllCollaider()
    {

        for (int i = 0; i < poleRazmer; i++)
        {
            for (int j = 0; j < poleRazmer; j++)
            {
                if (cells[i, j] != null)
                {
                    Collider2D cellColl = cells[i, j].GetComponent<Collider2D>();
                    Destroy(cellColl);
                    cell_Pl_vs_Pc cellChosen = cells[i, j].GetComponent<cell_Pl_vs_Pc>();
                    cellChosen.UnChousen();
                }
            }
        }
        
    }
    public int AIchoice(int _turn, int _line, int depth,int bestScoreComp=0,int bestScorePl = 0)
    {
        int ScorePl;
        int ScoreComp;
        int bestChoice=0;
        int temp=0;
        int bestStep = -1;
        
        if (bestScorePl == 0 && bestScoreComp == 0)
        {
            ScorePl = PlayerPoints;
            ScoreComp = CompPoints;
        }
        else
        {
            ScorePl = bestScorePl;
            ScoreComp = bestScoreComp;
        }
        for (int i = 0; i < poleRazmer; i++)
        {
            if (_turn == 1)//компьютер
            {
                if (cells[i,_line] != null)
                {
                    
                    cell_Pl_vs_Pc checkNumber = cells[i,_line].GetComponent<cell_Pl_vs_Pc>();
                    int ai=-1;
                    if (Mathf.Abs(checkNumber.Number) != 99)
                    {
                        temp = checkNumber.Number;
                        checkNumber.Number = 98;
                        int next = 0;
                        
                        if (depth < maxDepth)
                        {
                            ai=AIchoice(0, i, depth+1, ScoreComp + temp, ScorePl);
                            if (ai != -1)
                            {
                                cell_Pl_vs_Pc checkNumber2 = cells[i, ai].GetComponent<cell_Pl_vs_Pc>();
                                next = checkNumber2.Number;
                            }
                            else
                            {
                                bestStep = i;
                                checkNumber.Number = Mathf.Abs(temp) - 1;
                                return bestStep;
                            }    
                        }
                        if (bestChoice == 0 || bestChoice < ScoreComp - ScorePl + temp - next || bestChoice == ScoreComp - ScorePl + temp - next && Random.Range(0,2)==1)
                        {

                            bestChoice = ScoreComp - ScorePl + temp - next;
                            bestStep = i;
                        }                        
                        checkNumber.Number = Mathf.Abs(temp) - 1;
                    }
                    else continue;
                }
                else continue;                                                                                      
            }
            else
            {
                if (cells[_line,i] != null)
                {
                    cell_Pl_vs_Pc checkNumber = cells[_line, i].GetComponent<cell_Pl_vs_Pc>();
                    int ai = -1;
                    if (Mathf.Abs(checkNumber.Number) != 99)
                    {
                        temp=checkNumber.Number;
                        checkNumber.Number = 98;
                        int next = 0;
                        
                        if (depth < maxDepth)
                        {
                            ai = AIchoice(1, i, depth + 1, ScoreComp, ScorePl+temp);
                            if (ai != -1)
                            {
                                cell_Pl_vs_Pc checkNumber2 = cells[ai, i].GetComponent<cell_Pl_vs_Pc>();
                                next = checkNumber2.Number;
                            }
                            else
                            {
                                bestStep = i;
                                checkNumber.Number = Mathf.Abs(temp) - 1;
                                return bestStep;
                            }
                        }
                        if (bestChoice == 0 || bestChoice < ScorePl - ScoreComp + temp + next || bestChoice == ScoreComp - ScorePl + temp - next && Random.Range(0, 2) == 1)
                        {
                            bestChoice = ScorePl - ScoreComp + temp + next;
                            bestStep = i;
                        }
                        checkNumber.Number = Mathf.Abs(temp)-1;
                    }
                    
                    else continue;
                }
                else continue;
            }
        }
        //print(bestStep);
        return bestStep;
        
    }
    IEnumerator CompStep(int x)
    {
        yield return new WaitForSeconds(1f);
        GameObject compChoice = cells[AIchoice(_turn, x, 1), x];
        for(int i=0;i<10;i++)
        {
            SpriteRenderer _render=compChoice.GetComponent<SpriteRenderer>();
            Color color =new Color(1, 0.92f, 0.016f, 1);
            color.a -= i/10;
            _render.color = color;            
            yield return new WaitForSeconds(0.1f);
        }
        cell_Pl_vs_Pc stepComp = compChoice.GetComponent<cell_Pl_vs_Pc>();
        stepComp.OnMouseDown();
    }


    private void EndGame(int _turn,int x, int y)
    {
        if (IsCells(x,y))
        {
            if (_turn == 0)
            {
                PlayerPrefs.SetString("Finish", "Win");
                PlayerPrefs.SetInt("FinishScore", PlayerPoints);
                SceneManager.LoadScene("final");
            }
            else
            {
                PlayerPrefs.SetString("Finish", "Lost");
                PlayerPrefs.SetInt("FinishScore", PlayerPoints);
                SceneManager.LoadScene("final");
            }
            //img.gameObject.SetActive(true);
            //restartButton.gameObject.SetActive(true);
        }
        else
        {
            if (PlayerPoints > CompPoints)
            {
                PlayerPrefs.SetString("Finish", "Win");
                PlayerPrefs.SetInt("FinishScore", PlayerPoints);
                SceneManager.LoadScene("final");
            }
            else
            {
                PlayerPrefs.SetString("Finish", "Lost");
                PlayerPrefs.SetInt("FinishScore", PlayerPoints);
                SceneManager.LoadScene("final");
            }
            //img.gameObject.SetActive(true);
            //restartButton.gameObject.SetActive(true);
        }
    }

    private bool IsCells(int x,int y)
    {        
        foreach (GameObject i in cells)
        {
            if (i != null && i != cells[y, x])
            {                
                return true;
            }
            else continue;
        }
        return false;
    }

    IEnumerator  ChangeScoreBg(int turn)
    {
        yield return new WaitForSeconds(0.5f);
        if (turn == 1)
        {
            pointsTextCompBG.sprite = pointsBG[3];
        }
        else
        {
            pointsTextPlayerBG.sprite = pointsBG[0];
        }
        
    }

    public void setBack(int x,int y, int number, int color)
    {
        if (_turn == 0)
        {
            PlayerPrefs.SetInt("CompStepX", x);
            PlayerPrefs.SetInt("CompStepY", y);
            PlayerPrefs.SetInt("CompStepNumber", number);
            PlayerPrefs.SetInt("CompStepColor", color);
        }
        if (_turn == 1)
        {
            PlayerPrefs.SetInt("PlayerStepX", x);
            PlayerPrefs.SetInt("PlayerStepY", y);
            PlayerPrefs.SetInt("PlayerStepNumber", number);
            PlayerPrefs.SetInt("PlayerStepColor", color);
        }
    }

    public void getBack()
    {
        
        print(cells.Length);
        print(string.Format("{0} , {1}", PlayerPrefs.GetInt("PlayerStepY"), PlayerPrefs.GetInt("PlayerStepx")));
        cells[PlayerPrefs.GetInt("PlayerStepY"), PlayerPrefs.GetInt("PlayerStepX")] = (GameObject)Instantiate(cell, new Vector2(poleKoefx + PlayerPrefs.GetInt("PlayerStepX") * poleKoef, poleKoefy - PlayerPrefs.GetInt("PlayerStepY") * poleKoef), Quaternion.identity);
        cell_Pl_vs_Pc cellChosen = cells[PlayerPrefs.GetInt("PlayerStepY"), PlayerPrefs.GetInt("PlayerStepX")].GetComponent<cell_Pl_vs_Pc>();
        cellChosen.firstNumber = PlayerPrefs.GetInt("PlayerStepNumber");
        cellChosen.firstColor = PlayerPrefs.GetInt("PlayerStepColor");
        if (PlayerPrefs.GetInt("PlayerStepColor") == 0)
        {
            PlayerPoints -= PlayerPrefs.GetInt("PlayerStepNumber");
            PlayerPoints -= 1;
        }
        else
        {
            PlayerPoints += PlayerPrefs.GetInt("PlayerStepNumber");
            PlayerPoints += 1;
        }
        cell_Pl_vs_Pc cellPozition = cells[PlayerPrefs.GetInt("PlayerStepY"), PlayerPrefs.GetInt("PlayerStepX")].GetComponent<cell_Pl_vs_Pc>();
        cellPozition.x = PlayerPrefs.GetInt("PlayerStepX");
        cellPozition.y = PlayerPrefs.GetInt("PlayerStepY");
        cellChosen.Chousen();
        cells[PlayerPrefs.GetInt("CompStepY"), PlayerPrefs.GetInt("CompStepX")] = (GameObject)Instantiate(cell, new Vector2(poleKoefx + PlayerPrefs.GetInt("CompStepX") * poleKoef, poleKoefy - PlayerPrefs.GetInt("CompStepY") * poleKoef), Quaternion.identity);
        cell_Pl_vs_Pc cellChosen1 = cells[PlayerPrefs.GetInt("CompStepY"), PlayerPrefs.GetInt("CompStepX")].GetComponent<cell_Pl_vs_Pc>();
        cellChosen1.firstNumber = PlayerPrefs.GetInt("CompStepNumber");
        cellChosen1.firstColor = PlayerPrefs.GetInt("CompStepColor");
        if (PlayerPrefs.GetInt("CompStepColor") == 0)
        {
            CompPoints -= PlayerPrefs.GetInt("CompStepNumber");
            CompPoints -= 1;
        }
        else
        {
            CompPoints += PlayerPrefs.GetInt("CompStepNumber");
            CompPoints += 1;
        }
        pointsTextComp.text = string.Format("{0}", CompPoints);   
        pointsTextPlayer.text = string.Format("{0}", PlayerPoints);
        cell_Pl_vs_Pc cellPozition1 = cells[PlayerPrefs.GetInt("CompStepY"), PlayerPrefs.GetInt("CompStepX")].GetComponent<cell_Pl_vs_Pc>();
        cellPozition1.x = PlayerPrefs.GetInt("CompStepX");
        cellPozition1.y = PlayerPrefs.GetInt("CompStepY");
        _turn = 1;
        ChouseLine(PlayerPrefs.GetInt("PlayerStepX"), PlayerPrefs.GetInt("PlayerStepY"));
        StartCoroutine(getBackCoro(PlayerPrefs.GetInt("PlayerStepX"), PlayerPrefs.GetInt("PlayerStepY")));
        print(cells.Length);
    }
    IEnumerator getBackCoro(int x,int y)
    {
        yield return new WaitForEndOfFrame();
        PolygonCollider2D cellColl = cells[y, x].AddComponent<PolygonCollider2D>();
        cell_Pl_vs_Pc cellChosen = cells[y, x].GetComponent<cell_Pl_vs_Pc>();
        cellChosen.Chousen();   
    }    
}
