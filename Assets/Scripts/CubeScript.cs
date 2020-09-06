using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Color32[] colors = new Color32[4];

    [SerializeField]
    private Renderer targetRenderer;

    int colorNum;

    private void Start()
    {
        colors[0] = new Color32(255, 100, 100, 255);
        colors[1] = new Color32(255, 255, 100, 255);
        colors[2] = new Color32(100, 255, 100, 255);
        colors[3] = new Color32(100, 100, 255, 255);

        colorNum = Random.Range(0, 4);

        targetRenderer = this.GetComponent<Renderer>();
        targetRenderer.material.SetColor("_BaseColor", colors[colorNum]);

    }
}
