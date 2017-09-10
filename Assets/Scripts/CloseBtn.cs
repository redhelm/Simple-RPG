using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBtn : MonoBehaviour {

    GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
    }

	public void ClosePanel()
    {
        parent.SetActive(false);
    }

}
