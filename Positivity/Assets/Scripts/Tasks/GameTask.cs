using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameTask : MonoBehaviour
{
    public GameTask(string name)
    {
        _Name = name;
    }
    private string _Name;
    public string Name { get { return _Name; } }
    public Dictionary<string, GameStep> Steps { get; set; } = new Dictionary<string, GameStep>(System.StringComparer.InvariantCultureIgnoreCase);
    private bool _IsComplete;
    public bool IsComplete { get { return _IsComplete; } }

    public void CheckComplete()
    {
        if (Steps.Values.All(s => s.IsComplete) == false)
        {
            return;
        }
        _IsComplete = true;
        GamePersistTasks.CheckComplete();

    }

    public GameStep GetCurrentStep(string item = "")
    {
        if (IsComplete)
        {
            Debug.Log("task is complete");

            return null;
        }

        var step = Steps.Values.FirstOrDefault(s => s.IsComplete == false);
        if (step is null)
        {
            Debug.Log("all complete");

            return null;
        }
        if (step.Item1.ToUpper() != item.ToUpper() && step.Item2.ToUpper() != item.ToUpper() && item != "")
        {
            Debug.Log("doesnt fetch step");

            return null;
        }
        return step;
    }

    public GameStep GetStep(string item)
    {
        
        var step = Steps.Values.FirstOrDefault(s => s.Item1.ToUpper() == item.ToUpper() || s.Item2.ToUpper() == item.ToUpper());
        if (step is null)
        {            
            return null;
        }        
        return step;
    }


    public bool StepsForItemComplete(string item)
    {
        foreach (var step in Steps.Values)
        {
            if (step.Item1.ToUpper() == item.ToUpper() || step.Item2.ToUpper() == item.ToUpper())
            {
                if (step.IsComplete == false)
                {
                    return false;
                }
            }
            
        }
        return true;
    }

}
