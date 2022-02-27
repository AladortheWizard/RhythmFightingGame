using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilt : MonoBehaviour
{

    public float tiltValue;
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
        current = new Vector3(x, y, tiltValue);
        transform.eulerAngles = current;

        tiltValue = ((Mathf.Sin(Conductor.instance.songPos * Conductor.instance.bpm / 20f) * 2f * 2f)) + startVal;
    }
}
