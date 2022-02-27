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
    public RectTransform rectTransform;
    public GameObject notes;

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
            StartCoroutine(Lerp(bpm * Time.deltaTime, rectTransform));
        }

    }

    IEnumerator Lerp(float duration, RectTransform rect)
    {
        float time = 0;
        while (time < duration)
        {
            rect.localPosition = new Vector3(-217, Mathf.Lerp(-450, 131, time), 0);
            time+= 0.5f * Time.deltaTime;
            yield return null;
        }



    }
}
