using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemStick : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] objectives;

    private Vector3 offset = new();
    private GameObject collidedObject = null;
    private GameObject theOtherObject = null;
    private Rigidbody2D rb;
    public bool completed = false;
    private bool pickedUp = false;
    private bool completedSound = false;
    private int currentIndex = 0;
    public AudioSource pickUpSound;
    public AudioSource emptySound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        collidedObject = theOtherObject; // do collision check, replace with collided object
        if (collidedObject != null && !completed)
        {
            transform.position = collidedObject.transform.position + offset;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (completed)
        {
            return;
        }
        if (collision.gameObject.name == player.name && !completed)
        {
            if(pickedUp == false)
            {
                pickedUp = true;
                pickUpSound.Play();

                bool exists = false;
                Debug.Log("collided with player");
                try
                {
                    exists = (PlayerCarriedItems.carriedItems?.Any(i => i == gameObject.name) ?? false);
                }
                catch { }
                if (exists == false)
                {
                    Debug.Log("Before Resize");
                    System.Array.Resize(ref PlayerCarriedItems.carriedItems, PlayerCarriedItems.carriedItems.Length + 1);
                    Debug.Log("Before Assigning");
                    PlayerCarriedItems.carriedItems[PlayerCarriedItems.carriedItems.Length - 1] = (gameObject.name);
                    Debug.Log($"Picked up {gameObject.name}");
                }
            }
            theOtherObject = collision.gameObject;
            rb.bodyType = RigidbodyType2D.Kinematic;
            offset = transform.position - theOtherObject.transform.position;
        }
        try
        {
            if (collision.gameObject == objectives[currentIndex])
            {
                currentIndex++;
                completed = currentIndex == objectives.Length;
                Debug.Log(completed);
            }
        }
        catch (IndexOutOfRangeException)
        { }

        if (completed)
        {
            Debug.Log("Completed");
            if (completedSound == false)
            {
                completedSound = true;
                emptySound.Play();
            }
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            theOtherObject = collision.gameObject;
            offset = transform.position - theOtherObject.transform.position;
        }
    }
}
