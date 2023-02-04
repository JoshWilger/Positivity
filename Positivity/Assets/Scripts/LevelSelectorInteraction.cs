using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorInteraction : MonoBehaviour
{
    //Property For The BlueHouse

    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                SceneManager.LoadScene("GroundArea");
            }
        }
    }
    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.W);
    }
    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    }
}
