using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BenDialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text NPCText;
    [SerializeField] private Image theImg;
    [SerializeField] private GameObject heart;
    [SerializeField] private TMP_Text pressSpace;
    [SerializeField] private GameObject theNPC;
    [SerializeField] private GameObject theNPC2;
    [SerializeField] private GameObject thePlayer;

    [SerializeField] private Animator anim;
    [SerializeField] private Animator anim2;
    public ItemStick stickyScript;

    private Rigidbody2D rb;

    bool interact = false;
    int spacesPressed = 0;
    int secondsPassed = 1;


    // Start is called before the first frame update
    void Start()
    {
        heart.SetActive(false);
        theImg.enabled = false;
        NPCText.text = "";
        pressSpace.text = "";

        if (GamePersistTasks.Tasks["Ben"].GetCurrentStep()?.IsComplete ?? true)
        {
            //Set Ben to better
            anim.SetTrigger("better");
            anim2.SetTrigger("better");
            heart.SetActive(true);
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
                if (GamePersistTasks.Tasks["Ben"].GetCurrentStep()?.IsComplete ?? true)
                {
                    return;
                }
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
        Debug.Log(collission.name);
        if (GamePersistTasks.Tasks["Ben"].IsComplete)
        {
            theImg.enabled = true;
            NPCText.text = "True love at last! Thank you!";
            return;
        }
        if (collission.gameObject == theNPC)
        {
            if (!stickyScript.completed)
            {
                //Show text box
                theImg.enabled = true;
                interact = true;
            }
            else
            {
                rb = theNPC2.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                theImg.enabled = true;
                NPCText.text = "True love at last! Thank you!";
                anim.SetTrigger("better");
                anim2.SetTrigger("better");
                heart.SetActive(true);
                GamePersistTasks.Tasks["Ben"].GetCurrentStep()?.Complete();
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
