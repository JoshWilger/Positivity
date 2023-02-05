using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AllenDialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text NPCText;
    [SerializeField] private Image theImg;
    [SerializeField] private TMP_Text pressSpace;
    [SerializeField] private GameObject theNPC;
    [SerializeField] private GameObject thePlayer;
    [SerializeField] private MissionClass mission;
    [SerializeField] private SoccerBallKick theBall;
    [SerializeField] private Animator anim;

    private bool interact = false;
    int spacesPressed = 0;
    int secondsPassed = 1;


    // Start is called before the first frame update
    void Start()
    {
        theImg.enabled = false;
        NPCText.text = "";
        pressSpace.text = "";

        if (SoccerBallKick.completed)
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
                    NPCText.text = "Duuuuude. I am so booooooored.";
                    pressSpace.text = "Press Space...";
                    break;
                case 1:
                    NPCText.text = "There is literally nothing to do around here. Like, ever. Everyone around here sucks.";
                    pressSpace.text = "Press Space...";
                    break;
                case 2:
                    NPCText.text = "All I can do is just sit here and hope somethig interesting will happen eventually...";
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
        if (SoccerBallKick.completed)
        {
            anim.SetTrigger("better");
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
            if (SoccerBallKick.completed == false)
            {
                theImg.enabled = true;
                interact = true;
            }
            else
            {
                theImg.enabled = true;
                NPCText.text = "Woah! That was exciting! Did you see the way that ball moved? Thanks for having fun with me!";
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
