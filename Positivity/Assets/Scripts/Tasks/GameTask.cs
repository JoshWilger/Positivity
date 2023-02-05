using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameTask : MonoBehaviour
{
    public GameTask(string Name)
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

    }

    public GameStep GetCurrentStep(string item = "")
    {
        if (IsComplete)
        {
            return null;
        }

        var step = Steps.Values.First(s => s.IsComplete == false);
        if (step.Item1.ToUpper() != item.ToUpper() && step.Item2.ToUpper() != item.ToUpper())
        {
            return null;
        }
        return step;
    }
    
}
