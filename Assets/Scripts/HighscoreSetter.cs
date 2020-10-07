using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreSetter : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    void Start()
    {
        highScoreText.text = "Highest Wave Reached: " + PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
