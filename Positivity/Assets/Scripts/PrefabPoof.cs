using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPoof : MonoBehaviour
{
    [SerializeField] private ItemStick stickScript;
    [SerializeField] private GameObject prefabToPoof;

    private bool done = false;

    // Update is called once per frame
    void Update()
    {
        if (stickScript.completed && !done)
        {
            done = true;
            prefabToPoof.SetActive(true);
        }
    }
}
