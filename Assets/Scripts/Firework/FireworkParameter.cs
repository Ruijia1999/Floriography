using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkParameter : ScriptableObject
{
    public ProjectileColor color;
    public ProjectileBuff buff;
}
public enum ProjectileColor
{
    None = 0,
    Red,
    Orange,
    Yellow,
    Green,
    Cyan,
    Blue,
    Purple
};


[Flags]
public enum ProjectileBuff
{
    None = 0,
    PikaPika = 1 << 0,
    Trail = 1 << 1,
    Gravity = 1 << 2,
    Gradient = 1 << 3
}