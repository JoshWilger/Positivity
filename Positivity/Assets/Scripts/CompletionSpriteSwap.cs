using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionSpriteSwap : MonoBehaviour
{
    [SerializeField] private ItemStick stickScript;
    [SerializeField] private Sprite newSprite;
    public string stepName = "";

    private SpriteRenderer render;
    private bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();

        var step = GamePersistTasks.Tasks["Margret"].GetStep("Flower");
        if (step.IsComplete)
        {
            render.sprite = newSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stickScript.completed && !done)
        {
            var step = GamePersistTasks.Tasks["Margret"].GetCurrentStep("Watering Can");
            if (step?.Name == stepName)
            {
                step.Complete();
            }
            done = true;
            render.sprite = newSprite;
        }
    }
}
