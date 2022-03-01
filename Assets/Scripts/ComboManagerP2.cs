using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManagerP2 : MonoBehaviour
{

    public List<KeyCode> keyToPress = new List<KeyCode>();


    public static ComboManagerP2 instance;

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
                Debug.Log(NoteObj.pressedPublic.ToString());
                if (NoteObj.pressedPublic == true)
                {
                    Debug.Log("pressedpublic");
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        animator.Play("Kick");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        cache.Add(KeyCode.Z);

                    }


                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        animator.Play("Punch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        cache.Add(KeyCode.X);

                    }

                    if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.X))
                    {
                        animator.Play("Gash");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);

                    }

                    if (cache.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.T))
                    {
                        animator.Play("CraneKick");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("upZ");
                        cache.Clear();
                    }

                    if (cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.T))
                    {
                        animator.Play("LadderPunch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("upX");
                        cache.Clear();
                    }

                    if (cache.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.G))
                    {
                        animator.Play("LegSweep");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6739271f);
                        MegaCombos.Add("downZ");
                        cache.Clear();
                    }

                    if (cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.G))
                    {
                        animator.Play("GroundedPunch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("downX");
                        cache.Clear();
                    }

                    if (cache.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.H))
                    {
                        animator.Play("RoundhouseKick");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("sideZ");
                        cache.Clear();
                    }

                    if (cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.H))
                    {
                        animator.Play("DoublePunch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("sideX");
                        cache.Clear();
                    }

                    if (cache.Contains(KeyCode.Z) && cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.T))
                    {
                        animator.Play("Spear");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("upZX");
                        cache.Clear();
                    }

                    if (cache.Contains(KeyCode.Z) && cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.G))
                    {
                        animator.Play("Spike");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("downZX");
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
        if (MegaCombos.IndexOf("upX") == 0)
        {
            if (MegaCombos.IndexOf("sideZ") == 1)
            {
                if (MegaCombos.IndexOf("downZ") == 2)
                {
                    if (MegaCombos.IndexOf("sideX") == 3)
                    {
                        animator.Play("Spin");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Clear();
                    }
                }
            }
        }

        //Flip
        if (MegaCombos.IndexOf("downZ") == 0)
        {
            if (MegaCombos.IndexOf("downX") == 1)
            {
                if (MegaCombos.IndexOf("upZ") == 2)
                {
                    animator.Play("Flip");
                    gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                    MegaCombos.Clear();
                }
            }
        }

        //Dive
        if (MegaCombos.IndexOf("downX") == 0)
        {
            if (MegaCombos.IndexOf("downZ") == 1)
            {
                if (MegaCombos.IndexOf("upZ") == 2)
                {
                    if (MegaCombos.IndexOf("sideX") == 3)
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

