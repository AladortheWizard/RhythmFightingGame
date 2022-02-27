using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioSource music;
    public bool startPlaying;
    public BeatScroller scroller;
    public static GameManager instance;

    public int score;
    public int scorePerNote = 100;
    
    public List<KeyCode> keys = new List<KeyCode>();
    // Start is called before the first frame update
    
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                scroller.hasStarted = true;

                music.Play();
            }
        }
    }
        public void noteHit()
        {
        Debug.Log("Hit Note");
        score += scorePerNote;
        }

        public void noteMiss()
    {
        Debug.Log("Note Miss");
    }
    }

