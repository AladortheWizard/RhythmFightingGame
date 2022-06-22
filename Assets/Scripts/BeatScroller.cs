using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float tempo;
    public bool hasStarted;
    public bool direction;
    public static float songPos;
    public float dspSongTime;
    public static float posBeats;

    // Start is called before the first frame update
    void Start()
    {
        tempo /= 60f;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasStarted)
        {
            dspSongTime = 0;
        }
        else
        {
            songPos += tempo * Time.deltaTime;

            posBeats = Mathf.Round(songPos * 1f) / 1f;
            if (!direction)
            {
                transform.position += new Vector3(tempo * Time.deltaTime, 0f, 0f);
            }
            if (direction)
            {
                transform.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);
            }
        }
        
    }
}
