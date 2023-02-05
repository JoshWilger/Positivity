using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCarriedItems : MonoBehaviour
{
    public GameObject player;
    public GameObject wateringCan;
    public GameObject tommysToy;
    public GameObject character;
    public static string[] carriedItems = { };
    // Start is called before the first frame update
    void Start()
    {
        if ((carriedItems?.Length ?? 0) > 0)
        {
            for (int i = 0; i < carriedItems.Length; i++)
            {
                Debug.Log($"Carried item: {carriedItems[i] }");
                if (carriedItems[i] == "Watering Can")
                {
                    if (wateringCan != null)
                    {
                        wateringCan.gameObject.SetActive(true);
                        wateringCan.transform.localPosition = Vector3.zero;
                        wateringCan.transform.position = player.transform.position + new Vector3(1f, 0f, 0f);
                    }
                }

                if (carriedItems[i] == "Tommy's Toy")
                {
                    if (tommysToy != null)
                    {
                        tommysToy.gameObject.SetActive(true);
                        tommysToy.transform.localPosition = Vector3.zero;
                        tommysToy.transform.position = player.transform.position + new Vector3(1f, 0f, 0f);
                    }
                }
                if (carriedItems[i] == "Character" || carriedItems[i] == "Character Variant")
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
}

