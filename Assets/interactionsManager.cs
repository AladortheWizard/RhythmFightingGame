using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void DoDamage(float dmg, string strongAgainst, float stunDuration, GameObject healthBar, string attacker, bool special)
    {
        if (attacker == "p1")
        {


            if (strongAgainst == ComboManagerP2.instance.state || ComboManagerP2.instance.state == "stun" || ComboManagerP2.instance.state == "neutral")
            {

                healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x - dmg * .01f, 1, 1);
                ComboManagerP2.instance.stun = stunDuration;
            }

            else if (ComboManagerP2.instance.state != "neutral" && strongAgainst == "neutral")
            {

            }
            else if (ComboManagerP2.instance.state != "stun" && strongAgainst == "stun")
            {

            }
        }
        else if (attacker == "p2")
        {


            if (strongAgainst == ComboManager.instance.state || ComboManager.instance.state == "stun" || ComboManager.instance.state == "neutral")
            {
                healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x - (dmg * .01f), 1, 1);
                ComboManager.instance.stun = stunDuration;
            }
            else if (ComboManager.instance.state != "neutral" && strongAgainst == "neutral")
            {

            }
            else if (ComboManager.instance.state != "stun" && strongAgainst == "stun")
            {

            }
        }
    }
}
