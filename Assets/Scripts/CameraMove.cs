using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField]
    private Vector3 nearPos;
    [SerializeField]
    private Vector3 farPos;

    [SerializeField]
    private float nearSize;
    [SerializeField]
    private float farSize;

    [SerializeField]
    private float speed = 0.4f;

    private bool goCloser = true;
    private bool needToGoCloser = false;

    public static CameraMove instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    private float time = 0;

    private void Update()
    {
        if (goCloser)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, nearSize, 0.4f);
        }
        else
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, farSize, 0.4f);
        }
    }

    // private void FixedUpdate()
    // {
    //     if (goCloser && needToGoCloser)
    //     {
    //         Camera.main.orthographicSize = Mathf.Lerp(farSize, nearSize, time);
    //         time += Time.deltaTime;
    //         if (time >= 1 || !goCloser)
    //         {
    //             needToGoCloser = false;
    //             time = 0;
    //         }
    //     }
    //     else if (!goCloser && !needToGoCloser)
    //     {
    //         Camera.main.orthographicSize = Mathf.Lerp(nearSize, farSize, time);
    //         time += Time.deltaTime;
    //         if (time >= 1 || goCloser)
    //         {
    //             needToGoCloser = true;
    //             time = 0;
    //         }
    //     }
    // }

    public void Near()
    {
        goCloser = true;

        transform.position = Vector3.Lerp(transform.position, nearPos, speed);
    }

    public void Far()
    {
        goCloser = false;
        
        transform.position = Vector3.Lerp(transform.position, farPos, speed);
    }
}
