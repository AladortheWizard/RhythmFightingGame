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
        Debug.Log(state);

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

                    if (NoteObj.pressedPublic == true)
                    {

                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            animator.Play("Kick");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            cache.Add(KeyCode.Z);
                            state = "neutral";
                            InteractionsManager.DoDamage(1, "neutral", 0, healthbar, "p2", false);
                        }


                        if (Input.GetKeyDown(KeyCode.X))
                        {
                            animator.Play("Punch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            cache.Add(KeyCode.X);
                            state = "neutral";
                            InteractionsManager.DoDamage(1, "neutral", 0, healthbar, "p2", false);
                        }

                        if (Input.GetKeyDown(KeyCode.G))
                        {
                           
                            animator.Play("Crouch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            state = "ground";
                        }

                        if (Input.GetKeyDown(KeyCode.T))
                        {
                            
                            await animator.Play("Jump");
                            state = "air";
                           gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            
                        }

                        if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.X))
                        {
                            animator.Play("Gash");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            state = "stun";
                            InteractionsManager.DoDamage(40, "neutral", 2, healthbar, "p2", true);
                        }

                        if (cache.Contains(KeyCode.Z) && cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.T))
                        {
                            animator.Play("Spear");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("upZX");
                            cache.Clear();
                            state = "stun";
                            InteractionsManager.DoDamage(40, "air", 2, healthbar, "p2", true);
                        }

                        if (cache.Contains(KeyCode.Z) && cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.G))
                        {
                            animator.Play("Spike");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("downZX");
                            cache.Clear();
                            state = "stun";
                            InteractionsManager.DoDamage(40, "ground", 2, healthbar, "p2", true);
                        }

                        if (cache.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.T))
                        {
                            animator.Play("CraneKick");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("upZ");
                            cache.Clear();
                            state = "air";
                            InteractionsManager.DoDamage(10, "air", 0, healthbar, "p2", false);
                        }

                        if (cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.T))
                        {
                            animator.Play("LadderPunch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("upX");
                            cache.Clear();
                            state = "air";
                            InteractionsManager.DoDamage(11, "air", 0, healthbar, "p2", false);
                        }

                        if (cache.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.G))
                        {
                            animator.Play("LegSweep");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6739271f);
                            MegaCombos.Add("downZ");
                            cache.Clear();
                            state = "ground";
                            InteractionsManager.DoDamage(12, "ground", 0, healthbar, "p2", false);
                        }

                        if (cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.G))
                        {
                            animator.Play("GroundedPunch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("downX");
                            cache.Clear();
                            state = "ground";
                            InteractionsManager.DoDamage(12, "ground", 0, healthbar, "p2", false);
                        }

                        if (cache.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.H))
                        {
                            animator.Play("RoundhouseKick");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("sideZ");
                            cache.Clear();
                            state = "neutral";
                            InteractionsManager.DoDamage(14, "neutral", 0, healthbar, "p2", false);
                        }

                        if (cache.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.H))
                        {
                            animator.Play("DoublePunch");
                            gameObject.transform.position = new Vector3(4.03f, -1.44f, -6.739271f);
                            MegaCombos.Add("sideX");
                            cache.Clear();
                            state = "neutral";
                            InteractionsManager.DoDamage(15, "neutral", 0, healthbar, "p2", false);
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
                        InteractionsManager.DoDamage(25, "neutral", 0, healthbar, "p2", false);
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
                    InteractionsManager.DoDamage(20, "air", 0, healthbar, "p2", false);
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
                        InteractionsManager.DoDamage(23, "aor", 0, healthbar, "p2", false);
                    }
                }
            }
        }

        if (clipInfos[0].clip.name == "Idle")
        {
            state = "neutral";
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

