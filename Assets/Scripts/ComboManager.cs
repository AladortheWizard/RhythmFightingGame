using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    public List<KeyCode> keyToPress = new List<KeyCode>();


    public static ComboManager instance;

    Animator animator = new Animator();

    public List<string> MegaCombos = new List<string>();
    List<KeyCode> cache = new List<KeyCode>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode key in keyToPress)
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

                    }


                    if (Input.GetKeyDown(KeyCode.Period))
                    {
                        animator.Play("Punch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        cache.Add(KeyCode.Period);

                    }

                    if (Input.GetKeyDown(KeyCode.Comma) && Input.GetKeyDown(KeyCode.Period))
                    {
                        animator.Play("Gash");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);

                    }

                                        if (cache.Contains(KeyCode.Comma) && Input.GetKeyDown(KeyCode.UpArrow))
                                        {
                                            animator.Play("CraneKick");
                                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                                            MegaCombos.Add("upComma");
                                            cache.Clear();
                                        }

                                        if (cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.UpArrow))
                                        {
                                            animator.Play("LadderPunch");
                                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                                            MegaCombos.Add("upPeriod");
                                            cache.Clear();
                                        }

                                        if (cache.Contains(KeyCode.Comma) && Input.GetKeyDown(KeyCode.DownArrow))
                                        {
                                            animator.Play("LegSweep");
                                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                                            MegaCombos.Add("downComma");
                                            cache.Clear();
                                        }

                                        if (cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.DownArrow))
                                        {
                                            animator.Play("GroundedPunch");
                                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                                            MegaCombos.Add("downPeriod");
                                            cache.Clear();
                                        }

                                        if (cache.Contains(KeyCode.Comma) && Input.GetKeyDown(KeyCode.LeftArrow))
                                        { 
                                            animator.Play("RoundhouseKick");
                                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                                            MegaCombos.Add("sideComma");
                                            cache.Clear();
                                        }

                                        if (cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.LeftArrow))
                                        {
                                            animator.Play("DoublePunch");
                                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                                            MegaCombos.Add("sidePeriod");
                                            cache.Clear();
                                        }

                                        if (cache.Contains(KeyCode.Comma) && cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.UpArrow))
                                        {
                                            animator.Play("Spear");
                                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                                            MegaCombos.Add("upCommaPeriod");
                                            cache.Clear();
                                        }

                                        if (cache.Contains(KeyCode.Comma) && cache.Contains(KeyCode.Period) && Input.GetKeyDown(KeyCode.DownArrow))
                                        {
                                            animator.Play("Spike");
                                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                                            MegaCombos.Add("downCommaPeriod");
                                            cache.Clear();
                                        }
                                    }


                //Miss Graphic
                else
                {
                    animator.Play("Miss");
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
                    }
                }
            }
        }





    }
    }

