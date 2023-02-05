using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStep : MonoBehaviour
{
    public GameStep(GameTask parentTask, string name, string item1, string item2)
    {
        _ParentTask = parentTask;
        _Name = name;
        _Item1 = item1;
        _Item2 = item2;
    }
    private string _Name;
    public string Name { get { return _Name; } }
    private GameTask _ParentTask;
    public GameTask ParentTask { get;  }
    private string _Item1;
    public string Item1 { get { return _Item1; } }
    private string _Item2;
    public string Item2 { get { return _Item2; } }    
    private bool _IsComplete;
    public bool IsComplete { get { return _IsComplete; } }
    public void Complete()
    {
        _IsComplete = true;
    }
}
