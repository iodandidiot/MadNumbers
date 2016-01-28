using UnityEngine;
using System.Collections;

public class touchHelp3 : MonoBehaviour {

    // Use this for initialization
    public help_script help;
    public void OnMouseDown()
    {
        help.StartHelp5();
        Destroy(gameObject);
    }
}
