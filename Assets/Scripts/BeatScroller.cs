using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float tempo;
    public bool hasStarted;

    public float songPos;
    public float dspSongTime;
    public static float posBeats;

    // Start is called before the first frame update
    void Start()
    {
        tempo = tempo / 60f;
        dspSongTime = (float)AudioSettings.dspTime;
    }

    // Update is called once per frame
    void Update()
    {
        songPos = (float)(AudioSettings.dspTime - dspSongTime);

        posBeats = songPos / tempo;
        posBeats = Mathf.Round(posBeats * 10f) / 10f;

        if (!hasStarted)
        {
            /*if (Input.anyKeyDown)
            {
                hasStarted = true;
            }*/
        }
        else
        {
            transform.position += new Vector3(tempo * Time.deltaTime, 0f , 0f);
        }
        
    }
}
