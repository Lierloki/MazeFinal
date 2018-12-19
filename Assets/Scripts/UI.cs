using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    private GameObject StartMenu;
    private GameObject GUI;

    void Start()
    {
        StartMenu = GameObject.FindGameObjectWithTag("StartMenu");
        GUI = GameObject.FindGameObjectWithTag("GUI");
        //GUI.SetActive(false);
        Time.timeScale = 0.0f;
    }
    public void ClickPlay()
    {
        Time.timeScale = 1.0f;
        StartMenu.SetActive(false);
        GUI.SetActive(true);
    }
}
