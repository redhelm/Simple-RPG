using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTraining : MonoBehaviour {

    public GameObject arrow;
    public float fireDelayTime;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot;

    private Vector2 mousePos;
    private Collider2D hitCollider;
    private float nextFire;

    // Use this for initialization
    void Start () {
        nextFire = Time.time;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && Time.time > nextFire)
        {
            Fire();
            nextFire = Time.time + fireDelayTime;
            // TODO: Play Bow Animation
        }
    }

    void Fire()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject obj = Instantiate(arrow, mousePos, Quaternion.identity) as GameObject;
    }
}
