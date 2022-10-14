using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    GameObject scoreMan;
    float StartPos;
    scoreManager manager;
    [SerializeField] private float distanceMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        scoreMan = GameObject.Find("ScoreManager");
        StartPos = transform.position.x;
        manager = scoreMan.GetComponent<scoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        manager.distanceScore = Mathf.CeilToInt((transform.position.x - StartPos) * distanceMultiplier);
    }
}
