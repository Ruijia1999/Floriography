using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Palette", menuName = "ScriptableObjects/ColorPalette", order = 1)]
public class ColorPalette : ScriptableObject
{

    public List<ColorPaletteUnit> data;
    
    public Gradient GetGradient(ProjectileColor colorIndex)
    {
        foreach (ColorPaletteUnit unit in data)
        {
            if (unit.index == colorIndex)
            {
                return unit.gradient;
            }
        }
        return null;
    }
    
    [Serializable]
    public struct ColorPaletteUnit
    {
        public ProjectileColor index;
        
        [GradientUsage(true)]
        public Gradient gradient;
    }
}
