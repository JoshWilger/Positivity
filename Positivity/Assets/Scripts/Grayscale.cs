using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grayscale : MonoBehaviour
{
    [SerializeField] private MissionClass mission;
    [SerializeField] private SpriteRenderer render;

    private Color originalColor;
    private bool completed = false;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = render.color;

        Color newColor = new Color(0.3f, 0.4f, 0.6f);
        render.color = newColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (completed)
        {
            return;
        }
        if (collision.gameObject.name == mission.objectives[currentIndex].name)
        {
            currentIndex++;
            completed = currentIndex == mission.objectives.Length;
        }
        if (completed)
        {
            render.color = originalColor;
        }
    }
}
