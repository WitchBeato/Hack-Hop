using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Powerup")]
public class GoodTools : ScriptableObject
{
    public int ID;
    public String toolName;
    public Sprite sprite;
    public String toolExplanation;

}
