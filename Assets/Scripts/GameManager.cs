using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public List<Bird> birds;
    public List<Pig> pig;
    public static GameManager _instance;
    private Vector3 originPos; //初始化的位置
    public GameObject win;
    public GameObject lose;
    public GameObject[] stars;

    private int starsNum = 0;

    private void Awake()
    {
        _instance = this;
        if (birds.Count > 0)
        {
            originPos = birds[0].transform.position;
        }
    }

    private void Start()
    {
        Initialized();
    }

    /// <summary>
    /// 初始化小鸟
    /// </summary>
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0) //第一只小鸟
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }

    /// <summary>
    /// 判定游戏逻辑
    /// </summary>
    public void NextBird()
    {
        if (pig.Count > 0)
        {
            if (birds.Count > 0)
            {
                Initialized();
            }
            else
            {
                lose.SetActive(true);//输了
            }
        }
        else
        {
            win.SetActive(true);//赢了
        }

    }

    public void ShowStars()
    {
        StartCoroutine("show");
    }

    IEnumerator show()
    {
        for (; starsNum < birds.Count + 1; starsNum++)
        {
            if (starsNum >= stars.Length)
            {
                break;
            }
            yield return new WaitForSeconds(0.2f);
            stars[starsNum].SetActive(true);
        }
        print(starsNum);
    }

    public void Replay()
    {
        //SaveData();
        SceneManager.LoadScene(2);
    }

    public void Home()
    {
        //SaveData();
        SceneManager.LoadScene(1);
    }
}
