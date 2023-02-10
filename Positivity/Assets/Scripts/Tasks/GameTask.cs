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

    public bool CheckComplete()
    {
        bool allComplete = true;
        foreach (var step in Steps.Values)
        {
            if (step.IsComplete == false)
            {
                Debug.Log($" Task {Name} Step {Name} is not complete");
                allComplete = false;
            }
        }
        
        return allComplete;

    }

    public GameStep GetCurrentStep(string item = "")
    {
        if (CheckComplete())
        {
            return null;
        }

        var step = Steps.Values.FirstOrDefault(s => s.IsComplete == false);
        if (step is null)
        {
            return null;
        }
        if (step.Item1.ToUpper() != item.ToUpper() && step.Item2.ToUpper() != item.ToUpper() && item != "")
        {
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
