
using UnityEngine;

public class Thing : MonoBehaviour {

    [SerializeField]
    private int pointsForBtn_Down = 0;
    [SerializeField]
    private int pointsForBtn_Up = 0;

    public virtual void BtnDown () {
        GameManager.instance.Score += pointsForBtn_Down;
        Debug.Log("Down");
	}
	
	public virtual void BtnUp () {
        GameManager.instance.Score += pointsForBtn_Up;
        Debug.Log("Up");
    }
}
