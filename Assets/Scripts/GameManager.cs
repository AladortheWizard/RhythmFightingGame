using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioSource music;
    public bool startPlaying;
    public BeatScroller scroller;
    public ScrollerP2 scroller2;
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
                scroller2.hasStarted = true;
                scroller.hasStarted = true;

                music.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.T)){
            ComboManagerP2.instance.state = "air";
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ComboManagerP2.instance.state = "neutral";
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ComboManager.instance.state = "air";
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ComboManager.instance.state = "neutral";
        }
    }

        
        public void noteHit()
        {
       
        score += scorePerNote;
        }

        public void noteMiss()
    {
        
    }
    }

