using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{

    public float spinValue;
    Vector3 current;
    float x;
    float y;
    public float startVal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        current = new Vector3(x, y, spinValue);
        transform.eulerAngles = current;

        spinValue = ((Mathf.Tan(Conductor.instance.songPos) * 20f * 3f)) + startVal;
    }
}
