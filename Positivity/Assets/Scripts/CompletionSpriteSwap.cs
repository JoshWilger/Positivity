using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionSpriteSwap : MonoBehaviour
{
    [SerializeField] private ItemStick stickScript;
    [SerializeField] private Sprite newSprite;

    private SpriteRenderer render;
    private bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stickScript.completed && !done)
        {
            done = true;
            render.sprite = newSprite;
        }
    }
}
