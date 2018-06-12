using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category { food, tools, medicines };
[System.Serializable]
public class Package   {

    public float weight;
    public float cost;
    public Category category;
    public Sprite previewPackage;


}
