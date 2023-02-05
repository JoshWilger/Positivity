using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePersistTasks : MonoBehaviour
{
    public static Dictionary<string, GameTask> Tasks { get; set; } = new Dictionary<string, GameTask>(System.StringComparer.InvariantCultureIgnoreCase);


    public static void NewGame()
    {
        Tasks.Clear();
        var margretTask = new GameTask("Margret");
        var margretStep1 = new GameStep(margretTask, "Fill Can", "Watering Can", "Pond");
        var margretStep2 = new GameStep(margretTask, "Water Flower", "Watering Can", "Flower");
        var margretStep3 = new GameStep(margretTask, "Give Flower", "Flower", "Margret");
        margretTask.Steps.Add(margretStep1.Name, margretStep1);
        margretTask.Steps.Add(margretStep2.Name, margretStep2);
        margretTask.Steps.Add(margretStep3.Name, margretStep3);
        Tasks.Add(margretTask.Name, margretTask);


        var allenTask = new GameTask("Allen");
        var allenStep1 = new GameStep(allenTask, "Kick SoccerBall", "SoccerBall", "");
        allenTask.Steps.Add(allenStep1.Name, allenStep1);
        Tasks.Add(allenTask.Name, allenTask);

        
        var carlyBenTask = new GameTask("Carly");
        var carlyBenStep1 = new GameStep(carlyBenTask, "Love", "Carly", "Ben");
        carlyBenTask.Steps.Add(carlyBenStep1.Name, carlyBenStep1);
        Tasks.Add(carlyBenTask.Name, carlyBenTask);
        //Same Task but if we go to Ben check with him too...
        Tasks.Add("Ben", carlyBenTask);


        var tommyTask = new GameTask("Tommy");
        var tommyStep1 = new GameStep(tommyTask, "Toy", "Tommys Toy", "Tommy");
        tommyTask.Steps.Add(tommyStep1.Name, tommyStep1);
        Tasks.Add(tommyTask.Name, tommyTask);

    }

    public static void CheckComplete()
    {
        if (Tasks.Values.All(s => s.IsComplete) == false)
        {
            return;
        }
        SceneManager.LoadScene("Ending");
    }
}
