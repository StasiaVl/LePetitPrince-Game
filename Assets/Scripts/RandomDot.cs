using System;
using System.Collections;
using UnityEngine;

public class RandomDot : MonoBehaviour {


    private float angle = 0;
    [SerializeField]
    private float radius = 4.8f; //default for baos
    [SerializeField]
    private float startingOfset = 0;
    [Range(0,1)]
    [SerializeField]
    private int doesWaitingTimeMatter = 0;
    [SerializeField]
    private GameObject thing;

    // Start planting
    public void Begin ()
    {
        StartCoroutine(PlantBao());
    }
	
	// Stop planting
	public void Stop () {
        StopAllCoroutines();
	}

    IEnumerator PlantBao()
    {

        //add normal bool

        yield return new WaitForSeconds(startingOfset);

        GameObject newEnemy = Instantiate(thing) as GameObject;
        angle = UnityEngine.Random.Range(0, (float)Math.PI);
        newEnemy.transform.position = PositionOnPlanet(angle);
        newEnemy.transform.Rotate(Vector3.forward, 57.2958f*(angle - (float)(Math.PI/2)));
        newEnemy.transform.parent = transform;

        yield return new WaitForSeconds(GameManager.instance.WaitingTime * doesWaitingTimeMatter);
        StartCoroutine(PlantBao());
    }

    private Vector2 PositionOnPlanet(float angle)
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        pos.x += radius * (float)Math.Cos(angle);
        pos.y += radius * (float)Math.Sin(angle);
        return pos;
    }
}
