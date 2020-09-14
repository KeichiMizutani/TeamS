using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public Color32[] colors = new Color32[3];

    [SerializeField]
    private Renderer targetRenderer;

    public int colorNum;
    [System.NonSerialized]
    public bool Selectable;

    private void Start()
    {
        colors[0] = new Color32(255, 127, 127, 255);
        colors[1] = new Color32(255, 255, 127, 255);
        colors[2] = new Color32(127, 191, 255, 255);

        colorNum = Random.Range(0, 3);

        targetRenderer = this.GetComponent<Renderer>();
        targetRenderer.material.SetColor("_BaseColor", colors[colorNum]);
        Selectable = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            colorNum++;
            if(colorNum > 2)
            {
                colorNum = 0;
            }
            targetRenderer.material.SetColor("_BaseColor", colors[colorNum]);
        }
    }

    public void PanelUP(bool up)
    {
        if (up)
        {
            transform.position += Vector3.up * 0.3f;
            Selectable = true;
        }
        else
        {
            transform.position += Vector3.down * 0.3f;
            Selectable = false;
        }
    }
}
