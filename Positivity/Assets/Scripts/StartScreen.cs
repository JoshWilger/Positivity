using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        //Default Player Position for later
        PlayerPrefs.SetString("MainScenePlayerPosition", $"21.37,0.86,0");
        PlayerPrefs.SetString("MainSceneCanPosition", $"2,1,0");
    }

    public void PlayButton_Clicked()
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene("MainScene");
    }
}