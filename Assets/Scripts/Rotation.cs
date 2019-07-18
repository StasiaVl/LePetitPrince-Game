using UnityEngine;

public class Rotation : MonoBehaviour
{

    [SerializeField] private float speed = -4.5f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}
