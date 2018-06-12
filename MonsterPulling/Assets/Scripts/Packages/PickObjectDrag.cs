using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjectDrag : MonoBehaviour {

    private Color defaulColor;

    private void Start()
    {
        defaulColor = GetComponent<Renderer>().material.color;
    }
    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", defaulColor);
    }
}
