using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour {

    public int starsNum = 0;
    private  bool isSelect = false;

    public GameObject locks;
    public GameObject stars;

    public GameObject panel;
    public GameObject map;
    public Text starsText;

    public int startNum = 1;
    public int endNum = 3;


    private void Start()
    {

        if (PlayerPrefs.GetInt("totalNum", 0) >= starsNum) {

            isSelect = true;

        }

        if (isSelect) {
            locks.SetActive(false);
            stars.SetActive(true);

            int counts = 0; 
            for (int i = startNum; i <= endNum; i++) {
                counts += PlayerPrefs.GetInt("level"+i.ToString(),0);
            }
            starsText.text = counts.ToString() + "/60";
        }
    }

    public void Selected()
    {
        if (isSelect) {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }

    public void panelSelect() {
        panel.SetActive(false);
        map.SetActive(true);
    }
}
