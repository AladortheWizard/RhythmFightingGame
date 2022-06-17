using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winManager : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject scroller;
    public GameObject scroller2;

    public Animator transition;
    public float transitionTime = 1f;
    public GameObject canvas;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if(p2.transform.localScale.x <= 0)
        {
            canvas.SetActive(true);
            transition.Play("Player1_Win");
            StartCoroutine(AudioFadeOut.FadeOut(audio, 500));
            scroller.transform.position = new Vector3(0, 0, 0);
            scroller2.transform.position = new Vector3(0, 0, 0);

        }

        if (p1.transform.lossyScale.x <= 0)
        {
            canvas.SetActive(true);
            transition.Play("Player2_Win");
            StartCoroutine(AudioFadeOut.FadeOut(audio, 500));
            scroller.transform.position = new Vector3(0, 0, 0);
            scroller2.transform.position = new Vector3(0, 0, 0);

        }
    }
}
