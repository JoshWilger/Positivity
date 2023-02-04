using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorInteraction : MonoBehaviour
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
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput <= 0)
        {
            return;
        }
        
         Debug.Log(item.name);
        switch (item.name)
        {
            case "BlueHouse":
                SceneManager.LoadScene("GroundArea");
                break;
            case "GreenHouse":
                SceneManager.LoadScene("GroundArea");
                break;
            case "OrangeHouse":
                SceneManager.LoadScene("GroundArea");
                break;
            case "PurpleHouse":
                SceneManager.LoadScene("GroundArea");
                break;
            case "RedHouse":
                SceneManager.LoadScene("GroundArea");
                break;
        }
        
    }
}
