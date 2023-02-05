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

    [SerializeField] private MissionClass mission;
    [SerializeField] private ItemStick stickScript;

    bool holdingDog = false;


    // Start is called before the first frame update
    void Start()
    {
        theImg.enabled = false;
        NPCText.text = "";
        pressSpace.text = "";
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
            if (stickScript.completed == false)
            {
                theImg.enabled = true;
                NPCText.text = "I lost my favorite toy dog! How will I ever be happy again!";
            }
            else
            {
                theImg.enabled = true;
                NPCText.text = "My toy dog! You found him! Thank you!!!";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collission)
    {
        Deactivate();
    }
}
