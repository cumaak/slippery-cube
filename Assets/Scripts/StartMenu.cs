using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject CountUI;
    public GameObject ScoreUI;

    void Start()
    {
        Time.timeScale = 0f;
    }

    
    public void Start_btn()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().ButtonSound();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        CountUI.SetActive(true);
        ScoreUI.SetActive(true);
    }
}
