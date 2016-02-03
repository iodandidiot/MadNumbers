using UnityEngine;
using System.Collections;

public class buybackClose : MonoBehaviour {

    public GameObject buyBackSet;

    public void onBuy()
    {
        buyBackSet.SetActive(true);
    }
    public void offBuy()
    {
        buyBackSet.SetActive(false);
    }
}
