using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePane : MonoBehaviour {

    private Animator anim;
    public GameObject button;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Retry()
    {

        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    /// <summary>
    /// 点击了pause按钮
    /// </summary>
    public void Pause()
    {
        //1、播放pause动画  
        anim.SetBool("isPause", true);
        button.SetActive(false);

        if (GameManager._instance.birds.Count > 0)
        {
            if (GameManager._instance.birds[0].isReleased == false)
            { //没有飞出
                GameManager._instance.birds[0].canMove = false;
            }
        }
    }

    public void Home()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
