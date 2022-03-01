using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObj : MonoBehaviour
{

    public bool canBePressed;
    public static bool pressedPublic;
    
     KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (canBePressed == true)
        {
            pressedPublic = true;
        }
        StartCoroutine(checkForDeletion());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            canBePressed = true;
            pressedPublic = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canBePressed)
        {
            if (collision.CompareTag("Activator"))
            {
                canBePressed = false;
                pressedPublic = false;

                GameManager.instance.noteMiss();
                gameObject.SetActive(false);


            }
        }
    }

    IEnumerator checkForDeletion()
    {
        foreach (KeyCode key in GameManager.instance.keys)
        {
            if (Input.GetKeyDown(key))
            {
                if (canBePressed)
                {
                    yield return new WaitForSeconds(0.1f);
                    canBePressed = false;
                    pressedPublic = false;
                    gameObject.SetActive(false);

                    GameManager.instance.noteHit();
                    break;

                }
            }
        }
    }
}
