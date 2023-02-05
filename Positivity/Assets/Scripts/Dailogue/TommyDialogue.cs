using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TommyDialogue : MonoBehaviour
{

    [SerializeField] private TMP_Text NPCText;
    [SerializeField] private Image theImg;
    [SerializeField] private TMP_Text pressSpace;
    [SerializeField] private GameObject theNPC;
    [SerializeField] private GameObject thePlayer;
    [SerializeField] private GameObject tommysToy;

    [SerializeField] private ItemStick stickScript;
    [SerializeField] private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        theImg.enabled = false;
        NPCText.text = "";
        pressSpace.text = "";

        if (GamePersistTasks.Tasks["Tommy"].GetCurrentStep()?.IsComplete ?? true)
        {
            Debug.Log("Tommy is better");
            anim.SetTrigger("better");
            tommysToy.transform.position = theNPC.transform.position + new Vector3(-1f, 0f);
            tommysToy.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Check if we are carrying Tommy's Toy");
            foreach (var item in PlayerCarriedItems.carriedItems)
            {
                Debug.Log($"Carrying {item}");
                if (item == "Tommy's Toy")
                {
                    tommysToy.gameObject.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if(stickScript.completed == false)
            {
                theImg.enabled = true;
                NPCText.text = "I lost my favorite toy dog! How will I ever be happy again!";
            }
            else
            {
                theImg.enabled = true;
                anim.SetTrigger("better");
                NPCText.text = "My toy dog! You found him! Thank you!!!";
                GamePersistTasks.Tasks["Tommy"].GetCurrentStep()?.Complete();
                tommysToy.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collission)
    {
        Deactivate();
    }
}
