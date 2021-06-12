using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAsync : MonoBehaviour {

    void Start() {
        Invoke("Load",2);
    }

    void Load() {
            SceneManager.LoadSceneAsync(1);
        }
    }

