using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour {

	void Start()
    {
        if (!GameControl.control.hasSavedGame())
        {
            gameObject.SetActive(false);
        }
    }
}
