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

    public void DoDamage(float dmg, string strongAgainst, float stunDuration, GameObject healthBar, string attacker)
    {
        if(attacker == "p1")
            {
                if (strongAgainst == ComboManagerP2.instance.state || ComboManagerP2.instance.state == "stun")
                {
                healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x - dmg, 1, 1);
                ComboManagerP2.instance.Stun(stunDuration);
                }
        }
        else if(attacker == "p2")
            {
            if (strongAgainst == ComboManager.instance.state || ComboManager.instance.state == "stun")
            {
                healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x - dmg, 1, 1);
                ComboManager.StartCoroutine(Stun(stunDuration));
            }
        }
    }
}
