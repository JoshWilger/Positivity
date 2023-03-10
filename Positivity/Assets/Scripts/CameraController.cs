using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private EdgeCollider2D terrain;

    private float cameraWidth;
    private float cameraHeight;


    private void Start()
    {
        cameraWidth = Camera.main.orthographicSize * Screen.width / Screen.height + 0.1f;
        cameraHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, terrain.bounds.min.x + cameraWidth, terrain.bounds.max.x - cameraWidth),
            Mathf.Clamp(player.position.y, terrain.bounds.min.y + cameraHeight, terrain.bounds.max.y - cameraHeight), transform.position.z);
    }
}
