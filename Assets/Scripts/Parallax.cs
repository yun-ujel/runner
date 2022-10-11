using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject cam;
    Renderer rend;

    float StartPos;
    [SerializeField] private float speed;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartPos = transform.position.x;
    }

    void Update()
    {
        float offset = (transform.position.x - StartPos) * speed;

        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
    }
}
