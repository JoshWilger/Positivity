using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarlyDialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text NPCText;
    [SerializeField] private Image theImg;
    [SerializeField] private TMP_Text pressSpace;
    [SerializeField] private GameObject theNPC;
    [SerializeField] private GameObject thePlayer;

    [SerializeField] private MissionClass mission;
    [SerializeField] private Animator anim;

    public bool completed = false;
    bool interact = false;
    int spacesPressed = 0;
    int secondsPassed = 1;

    // Start is called before the first frame update
    void Start()
    {
        theImg.enabled = false;
        NPCText.text = "";
        pressSpace.text = "";

        if (completed)
        {
            anim.SetTrigger("better");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interact)
        {
            switch (spacesPressed)
            {
                case 0:
                    NPCText.text = "Oh em gee, like, everyone and everything is so gross, like I can't even right now.";
                    pressSpace.text = "Press Space...";
                    break;
                case 1:
                    NPCText.text = "I was on twitter the other day, and, like, I saw this guy who was so gross, like ew. ";
                    pressSpace.text = "Press Space...";
                    break;
                case 2:
                    NPCText.text = "I wish I had a boyfriend who wasn't as gross as some of these randos online...";
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
            if (!completed)
            {
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