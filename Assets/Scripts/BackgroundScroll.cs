using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    SpriteRenderer sRenderer;
    [SerializeField] float scrollSpeed = 1;
    float offset = 0;

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;
        sRenderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
