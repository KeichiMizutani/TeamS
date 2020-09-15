using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelScript : MonoBehaviour
{
    public Color32[] colors = new Color32[3];

    [SerializeField]
    private Renderer targetRenderer;

    public int colorNum;
    [System.NonSerialized]
    public bool Selectable;
    [System.NonSerialized] public bool panelDisappear;


    private void Start()
    {
        colors[0] = new Color32(255, 127, 127, 255);
        colors[1] = new Color32(255, 255, 127, 255);
        colors[2] = new Color32(127, 191, 255, 255);

        colorNum = Random.Range(0, 3);

        targetRenderer = this.GetComponent<Renderer>();
        targetRenderer.material.SetColor("_BaseColor", colors[colorNum]);
        Selectable = false;
        panelDisappear = false;

        PanelScaleUP(true);
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
            transform.DOLocalMove(new Vector3(transform.position.x, 0.3f, transform.position.z), 0.2f);
            Selectable = true;
        }
        else
        {
            transform.DOLocalMove(new Vector3(transform.position.x, 0, transform.position.z), 0.2f);
            Selectable = false;
        }
    }

    public void PanelScaleUP(bool up)
    {
        if (up)
        {
            transform.DOScale(new Vector3(1, 1, 1), 0.8f);
        }
        else
        {
            transform.DOScale(new Vector3(0, 0, 0), 0.8f);
        }
    }
}
