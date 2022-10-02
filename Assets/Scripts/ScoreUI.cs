using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI Score_txt;
    public int Score;

    Manager manager;

    public TextMeshProUGUI BestScore_txt;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Cube").GetComponent<Manager>();
        Score = 0;
        Score_txt.text = "" + (int)Score;

        BestScore_txt.text = PlayerPrefs.GetInt("best-score", 0).ToString();
    }
    private void Update()
    {
        Score = manager.score_point;
        Score_txt.text = "" + (int)Score;

        if (Score > PlayerPrefs.GetInt("best-score"))
        {
            PlayerPrefs.SetInt("best-score", Score);
            BestScore_txt.text = Score.ToString();
        }
    }
}
