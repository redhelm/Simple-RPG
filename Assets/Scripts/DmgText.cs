using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Animation animation = gameObject.GetComponent<Animation>();
        animation.Play();
	}

    public void DestroyText()
    {
        Destroy(gameObject);
    }
	
}
