﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    public List<KeyCode> keyToPress = new List<KeyCode>();


    public static ComboManager instance;

    Animator animator = new Animator();

    public List<string> MegaCombos = new List<string>();
    List<KeyCode> cache = new List<KeyCode>();

    public GameObject healthbar;
    public string state;
    public float stun;
    public float stunCache;
    public float stunDuration;
    bool isStunned;

    AnimatorClipInfo[] clipInfos;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        clipInfos = animator.GetCurrentAnimatorClipInfo(0);
        if (stun > 0)
        {
            isStunned = true;
            StartCoroutine(Stun());
        }

        if (BeatScroller.posBeats == stunDuration)
        {
            isStunned = false;
            stunCache = 0;
            stunDuration = 0;
        }

        if (isStunned == true)
        {
            animator.Play("Miss");
        }
        foreach (KeyCode key in keyToPress)
        {
            if (isStunned == false)
            {

                if (Input.GetKeyDown(key))
                {
                    if (NoteObj.pressedPublic)
                    {
                        if (Input.GetKeyDown(KeyCode.Comma))
                        {
                            animator.Play("Kick");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            cache.Add(KeyCode.Comma);
                            state = "neutral";
                            InteractionsManager.DoDamage(1, "neutral", 0, healthbar, "p1", false);
                        }


                        if (Input.GetKeyDown(KeyCode.Period))
                        {
                            animator.Play("Punch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            cache.Add(KeyCode.Period);
                            state = "neutral";
                            InteractionsManager.DoDamage(1, "neutral", 0, healthbar, "p1", false);
                        }

                        if (Input.GetKeyDown(KeyCode.Comma) && Input.GetKeyDown(KeyCode.Period))
                        {
                            animator.Play("Gash");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            state = "stun";
                            InteractionsManager.DoDamage(40, "neutral", 2, healthbar, "p1", true);
                        }


                        if (Input.GetKeyDown(KeyCode.DownArrow))
                        {

                            animator.Play("Crouch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            state = "ground";
                        }

                        if (Input.GetKeyDown(KeyCode.UpArrow))
                        {

                            animator.Play("Jump");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            state = "air";
                        }

                        if (cache.Contains(KeyCode.Comma) && cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            animator.Play("Spear");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("upCommaPeriod");
                            cache.Clear();
                            state = "stun";
                            InteractionsManager.DoDamage(40, "air", 2, healthbar, "p1", true);
                        }

                        if (cache.Contains(KeyCode.Comma) && cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            animator.Play("Spike");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("downCommaPeriod");
                            cache.Clear();
                            state = "stun";
                            InteractionsManager.DoDamage(40, "ground", 2, healthbar, "p1", true);
                        }
                        if (cache.Contains(KeyCode.Comma) && Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            animator.Play("CraneKick");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("upComma");
                            cache.Clear();
                            state = "air";
                            InteractionsManager.DoDamage(10, "air", 0, healthbar, "p1", false);
                        }

                        if (cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            animator.Play("LadderPunch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("upPeriod");
                            cache.Clear();
                            state = "air";
                            InteractionsManager.DoDamage(11, "air", 0, healthbar, "p1", false);
                        }

                        if (cache.Contains(KeyCode.Comma) && Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            animator.Play("LegSweep");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("downComma");
                            cache.Clear();
                            state = "ground";
                            InteractionsManager.DoDamage(12, "ground", 0, healthbar, "p1", false);
                        }

                        if (cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            animator.Play("GroundedPunch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("downPeriod");
                            cache.Clear();
                            state = "ground";
                            InteractionsManager.DoDamage(12, "ground", 0, healthbar, "p1", false);
                        }

                        if (cache.Contains(KeyCode.Comma) && Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            animator.Play("RoundhouseKick");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("sideComma");
                            cache.Clear();
                            state = "neutral";
                            InteractionsManager.DoDamage(14, "neutral", 0, healthbar, "p1", false);
                        }

                        if (cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            animator.Play("DoublePunch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("sidePeriod");
                            cache.Clear();
                            state = "neutral";
                            InteractionsManager.DoDamage(15, "neutral", 0, healthbar, "p1", false);
                        }
                    }


                    //Miss Graphic
                    else
                    {
                        animator.Play("Miss");

                    }

                }
            }
        }


        //Mega Combos

        //Spin
        if (MegaCombos.IndexOf("upPeriod") == 0)
        {
            if (MegaCombos.IndexOf("sideComma") == 1)
            {
                if (MegaCombos.IndexOf("downComma") == 2)
                {
                    if (MegaCombos.IndexOf("sidePeriod") == 3)
                    {
                        animator.Play("Spin");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Clear();
                        InteractionsManager.DoDamage(25, "neutral", 0, healthbar, "p1", false);
                    }
                }
            }
        }

        //Flip
        if (MegaCombos.IndexOf("downComma") == 0)
        {
            if (MegaCombos.IndexOf("downPeriod") == 1)
            {
                if (MegaCombos.IndexOf("upComma") == 2)
                {
                    animator.Play("Flip");
                    gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                    MegaCombos.Clear();
                    InteractionsManager.DoDamage(20, "air", 0, healthbar, "p1", false);
                }
            }
        }

        //Dive
        if (MegaCombos.IndexOf("downPeriod") == 0)
        {
            if (MegaCombos.IndexOf("downComma") == 1)
            {
                if (MegaCombos.IndexOf("upComma") == 2)
                {
                    if (MegaCombos.IndexOf("sidePeriod") == 3)
                    {

                        animator.Play("CurvePunch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Clear();
                        InteractionsManager.DoDamage(23, "air", 0, healthbar, "p1", false);
                    }
                }
            }
        }
    }

    IEnumerator Stun()
    {
        stunCache = BeatScroller.posBeats;
        Debug.Log(BeatScroller.posBeats);
        stunDuration = stunCache + stun;
        Debug.Log(stunDuration);
        stun = 0;
        yield return null;
    }
}

