using UnityEngine;

public class Parallax : MonoBehaviour
{
    // animate the game object from -1 to +1 and back
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    // starting value for the Lerp
    static float t = 0.0f;

    void Update()
    {
        if (transform.position.x == 24.95)
        {
            transform.position = Vector3.zero;
            t = 0;
        }
        else
        {
            // animate the position of the game object...
            transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

            // .. and increase the t interpolater
            t += 0.5f * Time.deltaTime;
        }
    }
}