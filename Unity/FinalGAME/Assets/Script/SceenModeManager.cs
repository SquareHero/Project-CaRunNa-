﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenModeManager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartOnclick()
    {

        SceneManager.LoadScene("GameScene");

    }
}
