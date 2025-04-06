using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] colors;

        void Start()
    {
        if (colors.Length == 0)
        {
            Debug.LogWarning("Crei uma ou mias cores na Lista");
            return;

        }

        //Color c = colors[1];   
        Color c = colors[Random.Range(0, colors.Length -1)];
        GetComponent<Renderer>().material.color = c;

    }

   
}
