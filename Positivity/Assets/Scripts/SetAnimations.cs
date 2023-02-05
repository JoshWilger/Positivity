using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SetAnimations : MonoBehaviour
{

    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;
    public PlayableDirector timeline;


    // Start is called before the first frame update
    void Start()
    {
        anim1.SetTrigger("better");
        anim2.SetTrigger("better");
        anim3.SetTrigger("better");
        anim4.SetTrigger("better");
        anim5.SetTrigger("better");
    }

    void Update()
    {
        if(timeline.time >= 51)
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}
