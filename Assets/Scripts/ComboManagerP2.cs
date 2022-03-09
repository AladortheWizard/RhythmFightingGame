using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManagerP2 : MonoBehaviour
{

    public List<KeyCode> keyToPress = new List<KeyCode>();


    public static ComboManagerP2 instance;

    Animator animator = new Animator();

    public List<string> MegaCombos = new List<string>();
   public List<KeyCode> cache = new List<KeyCode>();

    public GameObject healthbar;
    public string state;
    public float stun;

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
            float temp = BeatScroller.posBeats;
            do
            {
                cache.Clear();
                animator.Play("Miss");
                Debug.Log(BeatScroller.posBeats != temp);
            } while (BeatScroller.posBeats != BeatScroller.posBeats + temp);


            stun = 0;
        }

        foreach (KeyCode key in keyToPress)
        {
            if (Input.GetKeyDown(key))
            {
               
                if (NoteObj.pressedPublic == true)
                {
                    
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        animator.Play("Kick");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        cache.Add(KeyCode.Z);
                        state = "neutral";
                        InteractionsManager.DoDamage(5, "neutral", 0, healthbar, "p2");
                    }


                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        animator.Play("Punch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        cache.Add(KeyCode.X);
                        state = "neutral";
                        InteractionsManager.DoDamage(5, "neutral", 0, healthbar, "p2");
                    }

                    if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.X))
                    {
                        animator.Play("Gash");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        state = "stun";
                    }

                    if (cache.Contains(KeyCode.Z) && cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.T))
                    {
                        animator.Play("Spear");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("upZX");
                        cache.Clear();
                        state = "stun";
                    }

                    if (cache.Contains(KeyCode.Z) && cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.G))
                    {
                        animator.Play("Spike");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("downZX");
                        cache.Clear();
                        state = "stun";
                    }

                    if (cache.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.T))
                    {
                        animator.Play("CraneKick");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("upZ");
                        cache.Clear();
                        state = "air";
                        InteractionsManager.DoDamage(5, "air", 0, healthbar, "p2");
                    }

                    if (cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.T))
                    {
                        animator.Play("LadderPunch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("upX");
                        cache.Clear();
                        state = "air";
                    }

                    if (cache.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.G))
                    {
                        animator.Play("LegSweep");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6739271f);
                        MegaCombos.Add("downZ");
                        cache.Clear();
                        state = "ground";
                    }

                    if (cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.G))
                    {
                        animator.Play("GroundedPunch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("downX");
                        cache.Clear();
                        state = "ground";
                    }

                    if (cache.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.H))
                    {
                        animator.Play("RoundhouseKick");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("sideZ");
                        cache.Clear();
                        state = "neutral";
                    }

                    if (cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.H))
                    {
                        animator.Play("DoublePunch");
                        gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                        MegaCombos.Add("sideX");
                        cache.Clear();
                        state = "neutral";
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

        if (clipInfos[0].clip.name == "Idle")
        {
            state = "neutral";
        }

    }
}

