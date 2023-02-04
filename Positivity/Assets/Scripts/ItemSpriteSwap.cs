using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteSwap : MonoBehaviour
{
    [SerializeField] private GameObject objective;
    [SerializeField] private Sprite newSprite;

    private SpriteRenderer render;

    public AudioSource fillSound;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == objective)
        {
            fillSound.Play();
            render.sprite = newSprite;
        }
    }
}
