using System.Collections;
using UnityEngine;

public class Baobab : Thing {

    private float strenght = 0;

    private void Start()
    {
        GameManager.instance.RegisterBaobab();
        StartCoroutine(Growth());
    }

    private void Update()
    {
        if (strenght >= 4 || GameManager.instance.CurrentState == GameStatus.gameover)
        {
            StopAllCoroutines();
            GameManager.instance.GameOver();
        }
    }
    public override void BtnDown()
    {
        strenght--;
        transform.localScale /= 2;
        if (strenght == 0)
        {
            base.BtnDown();
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }

    // Does nothing yet
    public override void BtnUp()
    {
        base.BtnUp();
    }

    IEnumerator Growth()
    {
        strenght++;
        transform.localScale *= 2;
        yield return new WaitForSeconds(10f);
        StartCoroutine(Growth());
    }


}
