using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{

    public float bpm;
    public float bpmInSecs;
    public float songPos;
    public float posBeats;
    float dspSongTime;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject notes;
    public GameObject play;
    public GameObject bug;
    public AudioSource audio;
    public GameObject controls;
    public float min = -450;
    public float max = 131;

    public static Conductor instance;

    
    // Start is called before the first frame update
    void Start()
    {
        bpmInSecs = 60f / bpm;
        dspSongTime = (float)AudioSettings.dspTime;

        text1.SetActive(true);
        text2.SetActive(false);

        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        songPos = (float)(AudioSettings.dspTime - dspSongTime);

        posBeats = songPos / bpmInSecs;
        posBeats = Mathf.Round(posBeats * 10f) / 10f;

        if (posBeats == 8.5)
        {
            text1.SetActive(false);
            text2.SetActive(true);
        }

        if (posBeats == 16.5)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(true);
            notes.SetActive(true);
            play.SetActive(true);
            bug.SetActive(true);
            StartCoroutine(Lerp((bpm + 30) * Time.deltaTime, text3.transform, -175.2f, -580, 113.7f, 0));
            StartCoroutine(Lerp((bpm + 20) * Time.deltaTime, play.transform, -301, -480, -113.28f, 0));
            StartCoroutine(Lerp((bpm + 20) * Time.deltaTime, bug.transform, -91.2f, -480, -89.2f, 0));
            StartCoroutine(Lerp((bpm + 20) * Time.deltaTime, controls.transform, 132.5f, -480, -113.28f, 0));

        }

    }

    IEnumerator Lerp(float duration, Transform rect, float x, float y, float y2, float z)
    {
        float time = 0;
        while (time < duration)
        {
            rect.localPosition = new Vector3(x, Mathf.Lerp(y, y2, time), z);
            time += 0.5f * Time.deltaTime;
            yield return null;
        }



    }
}
