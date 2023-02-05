using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BenDialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text NPCText;
    [SerializeField] private Image theImg;
    [SerializeField] private TMP_Text pressSpace;
    [SerializeField] private GameObject theNPC;
    [SerializeField] private GameObject thePlayer;

    [SerializeField] private Animator anim;
    [SerializeField] private ItemStick stickyScript;

    bool completed = false;
    bool interact = false;
    int spacesPressed = 0;
    int secondsPassed = 1;


    // Start is called before the first frame update
    void Start()
    {
        theImg.enabled = false;
        NPCText.text = "";
        pressSpace.text = "";

        //If the mission os completed
        if (completed)
        {
            //Set Ben to better
            anim.SetTrigger("better");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Show initial text box
        if (interact)
        {
            switch (spacesPressed)
            {
                case 0:
                    NPCText.text = "AAAAAARGH! I hate EVERYTHING and EVERYONE!";
                    pressSpace.text = "Press Space...";
                    break;
                case 1:
                    NPCText.text = "All my life, I've been working so hard, and for what? FOR WHAT?";
                    pressSpace.text = "Press Space...";
                    break;
                case 2:
                    NPCText.text = "Man if only I had a girlfriend. Then I guess maybe I wouldn't be as mad..";
                    pressSpace.text = "";
                    break;
            }
            if (Input.GetButton("Jump"))
            {
                if (secondsPassed == 1)
                {
                    spacesPressed++;
                }
                else if (secondsPassed == 60)
                {
                    secondsPassed = 0;
                }
                secondsPassed++;
            }
        }
    }

    void Deactivate()
    {
        theImg.enabled = false;
        NPCText.text = "";
        pressSpace.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.gameObject == theNPC)
        {
            //If the mission isn't completed yet
            if (!stickyScript.completed)
            {
                //Show text box
                theImg.enabled = true;
                interact = true;
            }
            else
            {
                theImg.enabled = true;
                NPCText.text = "True love at last! Thank you!";
                anim.SetTrigger("better");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collission)
    {
        interact = false;
        spacesPressed = 0;
        Deactivate();
    }
}
