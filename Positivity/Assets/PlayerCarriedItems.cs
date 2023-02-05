using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCarriedItems : MonoBehaviour
{
    public GameObject player;
    public GameObject wateringCan;
    public GameObject character;
    public static string[] carriedItems = { };
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerCarriedItems Start");
        if ((carriedItems?.Length ?? 0) > 0)
        {
            Debug.Log($"carriedItems.Length {carriedItems.Length}");
            for (int i = 0; i < carriedItems.Length; i++)
            {
                Debug.Log(carriedItems[i]);
                if (carriedItems[i] == "Watering Can")
                {
                    if (wateringCan != null)
                    {
                        wateringCan.gameObject.SetActive(true);
                        wateringCan.transform.localPosition = Vector3.zero;
                        wateringCan.transform.position = player.transform.position + new Vector3(-0.6f, 0f, 0f);
                    }
                }
                else if (carriedItems[i] == "Character" || carriedItems[i] == "Character Variant")
                {
                    if (character != null)
                    {
                        character.gameObject.SetActive(true);
                        character.transform.localPosition = Vector3.zero;
                        character.transform.position = player.transform.position + new Vector3(0f, 3f, 0f);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
