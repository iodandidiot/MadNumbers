using UnityEngine;
using System.Collections;

public class touchHelp1 : MonoBehaviour {

    public help_script help;
    public void OnMouseDown()
    {
        help.StartHelp2();
        Destroy(gameObject);
    }
}
