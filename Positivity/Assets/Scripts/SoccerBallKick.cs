using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBallKick : MonoBehaviour
{
    public GameObject player;
    private static bool isKicked;
    private bool hasHitFace;
    private static GameObject ball;
    private static Vector3 playerFacePosition;
    private static Vector3 diff;
    private const float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject;
        isKicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKicked == false)
        {
            return;
        }

        if (hasHitFace == false)
        {
            //make it go toward the face.
            transform.position = Vector3.MoveTowards(transform.position, playerFacePosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, playerFacePosition) < 0.01f)
            {
                hasHitFace = true;
            }
            return;
        }

       transform.position = transform.position + diff;    
       

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public static void KickBall(Transform player)
    {
        if (isKicked)
        {
            return;
        }
        isKicked = true;
        diff = (ball.transform.position - player.position);
        diff.x = diff.x * 0.1f;
        diff.y = diff.y * 0.1f;

        playerFacePosition = player.position + new Vector3(0.0f, 0.4f, 0.0f);
    }
}
