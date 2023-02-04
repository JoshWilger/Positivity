using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorInteraction : MonoBehaviour
{
    //Property For The BlueHouse
    public Transform playerPosition;
    public Transform canPosition;
    private const float detectionRadius = 0.00001f;
    public LayerMask detectionLayer;

    // Start is called before the first frame update
    void Start()
    {
        //Retrieve Player Position
        string mainScenePlayerPosition = PlayerPrefs.GetString("MainScenePlayerPosition");
        if (string.IsNullOrWhiteSpace(mainScenePlayerPosition) == false)
        {
            var posValues = mainScenePlayerPosition.Split(',');
            playerPosition.position = new Vector3(float.Parse(posValues[0]), float.Parse(posValues[1]), float.Parse(posValues[2]));
        }
        string mainSceneCanPosition = PlayerPrefs.GetString("MainSceneCanPosition");
        if (string.IsNullOrWhiteSpace(mainSceneCanPosition) == false)
        {
            var posValues = mainSceneCanPosition.Split(',');
            canPosition.position = new Vector3(float.Parse(posValues[0]), float.Parse(posValues[1]), float.Parse(posValues[2]));
        }
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

        //Save Player Position
        PlayerPrefs.SetString("MainScenePlayerPosition", $"{playerPosition.position.x},{playerPosition.position.y},{playerPosition.position.z}");
        PlayerPrefs.SetString("MainSceneCanPosition", $"{canPosition.position.x},{canPosition.position.y},{canPosition.position.z}");
        switch (item.name)
        {
            case "BlueHouse":
                SceneManager.LoadScene("TommyHouse");
                break;
            case "GreenHouse":
                SceneManager.LoadScene("CarlyHouse");
                break;
            case "OrangeHouse":

                SceneManager.LoadScene("AllenHouse");
                break;
            case "PurpleHouse":
                SceneManager.LoadScene("MargretHouse");
                break;
            case "RedHouse":
                SceneManager.LoadScene("BenHouse");
                break;
        }
        
    }
}
