using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBallKick : MonoBehaviour
{
    private static bool isKicked;
    private static GameObject ball;
    private static Vector3 diff;
    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKicked)
        {
            transform.position = transform.position + diff; // new Vector3(-0.1f, 0, 0);
        }
    }
    public static void KickBall(Transform player)
    {
        isKicked = true;
        diff = (ball.transform.position - player.position);
        diff.x = diff.x * 0.1f;
        diff.y = diff.y * 0.1f;
      
    }
}
