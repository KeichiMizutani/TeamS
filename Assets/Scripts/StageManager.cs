using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    GameObject plane;

    public int length;
    public int width;
    void Start()
    {
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                Instantiate(plane, new Vector3(i, 0, j), transform.rotation);
            }
        }
    }

    
    void Update()
    {
        
    }
}
