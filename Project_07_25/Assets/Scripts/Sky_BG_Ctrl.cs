using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky_BG_Ctrl : MonoBehaviour
{
    [SerializeField] private float ScrollSpeed = 0.2f;
    private float Offset = 0.0f;

    private SpriteRenderer m_Render;

    private void Start()
    {
        m_Render = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Offset += Time.deltaTime * ScrollSpeed;
        if (10000.0f < Offset)
            Offset = Offset - 10000.0f;
        m_Render.material.mainTextureOffset = new Vector2(Offset, 0);
    }
}
