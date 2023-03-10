using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoccerBallKick : MonoBehaviour
{
    public GameObject player;
    public GameObject house;
    public GameObject allen;
    public static bool completed = false;
    public static bool isKicked;
    private bool hasHitFace;
    private static GameObject ball;
    private static GameObject allenStatic;
    private static Vector3 playerFacePosition;
    private static Vector3 diff;
    private const float kickSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject;
        allenStatic = allen;
        isKicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKicked == false)
        {
            return;
        }

        if (diff.x < 0)
        {
            ball.transform.Rotate(Vector3.forward, 1000f * Time.deltaTime);
        }
        else
        {

            ball.transform.Rotate(Vector3.forward, -1000f * Time.deltaTime);
        }
        if (hasHitFace == false)
        {
            //make it go toward the face.
            var currentPlayerPosition = new Vector3(allen.transform.position.x, playerFacePosition.y, playerFacePosition.z);
            transform.position = Vector3.MoveTowards(transform.position, currentPlayerPosition, kickSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentPlayerPosition) < 0.01f)
            {
                hasHitFace = true;
            }
            return;
        }
        if (house.GetComponent<Renderer>().bounds.Contains(ball.transform.position) == false)
        {
            completed = true;
            isKicked = false;
            //SceneManager.LoadScene("MainScene");
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
        diff = (ball.transform.position - allenStatic.transform.position);
        diff.x = diff.x * 0.1f;
        diff.y = diff.y * 0.1f;
        

        playerFacePosition = allenStatic.transform.position + new Vector3(0.0f, 0.4f, 0.0f);
    }
}
