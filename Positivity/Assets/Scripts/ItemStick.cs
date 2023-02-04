using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStick : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private MissionClass mission;

    private Vector3 offset = new();
    private GameObject collidedObject = null;
    private GameObject theOtherObject = null;
    private Rigidbody2D rb;
    private bool completed = false;
    private int currentIndex = 0;

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
        if (collision.gameObject == player && !completed)
        {
            theOtherObject = collision.gameObject;
            rb.bodyType = RigidbodyType2D.Kinematic;
            offset = transform.position - theOtherObject.transform.position;
        }
        if (collision.gameObject.name == mission.objectives[currentIndex].name)
        {
            currentIndex++;
            completed = currentIndex == mission.objectives.Length;
        }

        if (completed)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            theOtherObject = collision.gameObject;
            offset = transform.position - theOtherObject.transform.position;
        }
    }
}
