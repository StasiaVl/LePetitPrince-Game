using UnityEngine;
using UnityEngine.UI;

public class Star : Thing {

    [SerializeField] private Image timer;
    private Image myTimer;
    //[SerializeField] private Canvas baseCanvas;

    public override void BtnUp()
    {
        //animation
        base.BtnUp();
        DestroyObject(gameObject);
        Destroy(myTimer.gameObject);
    }

    public override void BtnDown()
    {
        GetComponent<Collider2D>().enabled = false;
        //animation
        DestroyObject(gameObject);
        Destroy(myTimer.gameObject);
    }

    private void Start()
    {
        myTimer = Instantiate(timer) as Image;
        myTimer.transform.position = transform.position;
        myTimer.transform.rotation = transform.rotation;
        myTimer.transform.SetParent(FindObjectOfType<Canvas>().transform, false);
    }

    private void Update()
    {
       myTimer.fillAmount -= Time.deltaTime* 0.1f;
       if (myTimer.fillAmount <= 0)
       {
            Destroy(myTimer.gameObject);
           Destroy(gameObject);
       }
    }

    // Update is called once per frame
    void LateUpdate () {
        myTimer.transform.position = transform.position;
    }


}
