using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class master : MonoBehaviour
{
    GameObject player;
    GameObject cam;

    CameraController cc;
    Move pmc;

    private void Awake()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("MC");

        cc = cam.GetComponent<CameraController>();
        pmc = player.GetComponent<Move>();
    }

    private void Update()
    {
        if (player.transform.position.y < -20)
        {
            Restart();
        }
    }

    private void Restart()
    {
        cc.onStart();
        pmc.onStart();
    }
}
