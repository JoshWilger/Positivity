using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBallDetection : MonoBehaviour
{
    //Property For The BlueHouse

    public Transform playerPosition;
    private const float detectionRadius = 0.00001f;
    public LayerMask detectionLayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var item = Physics2D.OverlapCircle(playerPosition.position, detectionRadius, detectionLayer);
        if (item == null)
        {
            return;
        }

        Debug.Log(item.name);
        switch (item.name)
        {
            case "SoccerBall":
                SoccerBallKick.KickBall(playerPosition);
                GamePersistTasks.Tasks["Allen"].GetCurrentStep()?.Complete();
                break;
        }

    }
}
