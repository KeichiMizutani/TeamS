using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    GameObject plane;

    public int length;
    public int width;
    public float distance;

    void Start()
    {
        for(int dz = 0; dz < length; dz++)
        {
            for (int dx = 0; dx < width; dx++)
            {
                //Instantiate(plane, new Vector3(i * distance, 0, j), transform.rotation);
                if(dz % 2 == 0)
                {
                    Instantiate(plane, new Vector3(dx * distance, 0, dz * distance * Mathf.Sin(Mathf.PI / 3)), transform.rotation);
                } else
                {
                    Instantiate(plane, new Vector3(dx * distance + distance / 2, 0, dz * distance * Mathf.Sin(Mathf.PI / 3)), transform.rotation);
                }
            }
        }
    }

    
    void Update()
    {
        
    }
}
