using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.CurrentState == GameStatus.play && Input.GetAxisRaw("Vertical")==0)
        {
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * moveSpeed);
            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * moveSpeed);
            }

        }
    }
}
