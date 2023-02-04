using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoccerBallKick : MonoBehaviour
{
    public GameObject player;
    public GameObject house;
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
        if (house.GetComponent<Renderer>().bounds.Contains(ball.transform.position) == false)
        {
            SceneManager.LoadScene("MainScene");
        }
        transform.position = transform.position + diff;    
       

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
