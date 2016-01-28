using UnityEngine;
using System.Collections;

public class touchHelp : MonoBehaviour {

	// Use this for initialization
    public help_script help;
    public void OnMouseDown()
    {
        help.StartHelp4();
        Destroy(gameObject);
    }
}
