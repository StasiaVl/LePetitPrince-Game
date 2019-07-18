using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool smtIsThere = false;
    private Thing smt = null;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (smtIsThere && GameManager.instance.CurrentState == GameStatus.play)
        {
            if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))//(Input.GetAxisRaw("Vertical")==-1) hz why it doesn't work
            {
                smt.BtnDown();
            }
            if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))//(Input.GetAxisRaw("Vertical")==-1) hz why it doesn't work
            {
                smt.BtnUp();
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
         smtIsThere = true;
         Thing newT = collision.gameObject.GetComponent<Thing>();
         smt = newT;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //GameManager.instance.CanDo = false;
       
        smtIsThere = false;
        smt = null;
    }
}
