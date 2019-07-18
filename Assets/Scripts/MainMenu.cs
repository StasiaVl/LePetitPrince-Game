using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {


    [SerializeField]
    private Image Hint;

    private Vector3 position;

    // Use this for initialization
    private void Start()
    {
        position = Hint.transform.position;
    }
    public void ShowHint()
    {
        Hint.transform.position = transform.position;
    }

    public void GoBack()
    {
        Hint.transform.position = position;
    }
}
