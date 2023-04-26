using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public float distanceScore;



    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + Mathf.Max(distanceScore, 0f).ToString();
    }
}
