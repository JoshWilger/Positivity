using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpAmount;
    [SerializeField] private BoxCollider boxTrigger;

    private Rigidbody2D rb;
    private Collider2D coll;
    private float dirX;
    private float dirY;
    public AudioSource JumpSound;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        //dirY = Input.GetAxis("Vertical");
        if(dirX < 0)
        {
            anim.SetBool("walking", true);
            gameObject.transform.localScale = new Vector3(-2, 2, 3);
        }
        else if(dirX > 0){
            anim.SetBool("walking", true);
            gameObject.transform.localScale = new Vector3(2, 2, 3);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(dirX * moveSpeed, jumpAmount);
            JumpSound.Play();
        }
    }
}
