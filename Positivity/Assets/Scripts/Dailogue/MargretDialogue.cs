using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MargretDialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text NPCText;
    [SerializeField] private Image theImg;
    [SerializeField] private TMP_Text pressSpace;
    [SerializeField] private GameObject theNPC;
    [SerializeField] private GameObject thePlayer;

    [SerializeField] private MissionClass mission;
    [SerializeField] private ItemStick stickScript;
    [SerializeField] private Animator anim;

    bool interact = false;
    int spacesPressed = 0;
    int secondsPassed = 1;

    // Start is called before the first frame update
    void Start()
    {
        theImg.enabled = false;
        NPCText.text = "";
        pressSpace.text = "";

        if (stickScript.completed == true)
        {
            anim.SetTrigger("better");
        }
    }

    void Update()
    {
        if (interact)
        {
            switch (spacesPressed)
            {
                case 0:
                    NPCText.text = "My flowers can't grow! They haven't been watered in many days...";
                    pressSpace.text = "Press Space...";
                    break;
                case 1:
                    NPCText.text = "I'm too old to be moving around this much, so I can't water the flowers.";
                    pressSpace.text = "Press Space...";
                    break;
                case 2:
                    NPCText.text = "My husband used to water the flowers, but he passed away a few months ago...";
                    pressSpace.text = "";
                    break;
            }
            if (Input.GetButton("Jump"))
            {
                if(secondsPassed == 1)
                {
                    spacesPressed++;
                }
                else if(secondsPassed == 60)
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
            if (stickScript.completed == false)
            {
                theImg.enabled = true;
                interact = true;
            }
            else
            {
                theImg.enabled = true;
                NPCText.text = "My flowers! They have bloomed! Thank you!";
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
