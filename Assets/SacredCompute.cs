using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacredCompute : MonoBehaviour
{
    private Texture2D generatedTexture;

    [SerializeField] private MeshRenderer applyToRenderer;

    [Header("Texture Options")]
    public int textureWidth;
    public int textureHeight;

    [Header("Geometry Options")]
    public int circleRadius;

    public float borderWidth = 1f;


    private void Awake()
    {
        generatedTexture = new Texture2D(textureWidth, textureHeight);
        applyToRenderer.material.mainTexture = generatedTexture;

        UpdateTexture();
    }

    private void Update()
    {
        UpdateTexture();
    }

    private void UpdateTexture()
    {
        generatedTexture.Reinitialize(1, 1);
        generatedTexture.SetPixel(0, 0, Color.white);
        generatedTexture.Reinitialize(textureWidth, textureHeight);
        Vector2Int center = new Vector2Int(textureWidth / 2, textureHeight / 2);
        RenderShapeUtils.DrawHollowCircle(ref generatedTexture, Color.red, center.x, center.y, circleRadius, borderWidth);
        generatedTexture.Apply();
    }
}
