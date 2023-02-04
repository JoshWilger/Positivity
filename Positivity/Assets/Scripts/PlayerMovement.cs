using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpAmount;

    private Rigidbody2D rb;
    private Collider2D coll;
    private float dirX;
    private float dirY;
    public AudioSource JumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        //dirY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y + jumpAmount);
            JumpSound.Play();
        }
    }
}
