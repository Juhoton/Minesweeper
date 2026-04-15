using UnityEngine;

public class Rotate : MonoBehaviour
{
    float speed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
    }
}
