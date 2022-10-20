using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class FireworkController : MonoBehaviour
{
    // Start is called before the first frame update
    public VisualEffect vfx;
    //public ColorPalette singlePalette;
    //public ColorPalette gradientPalette;
    //public ColorPalette pTrailPalette;
    void Start()
    {
        if(vfx == null)vfx = GetComponent<VisualEffect>();
        if (vfx != null)
        {
            string json = PlayerPrefs.GetString("CurrentProjectile", "{\"color\":5,\"buff\":7}");
            var parameter = ScriptableObject.CreateInstance<FireworkParameter>();
            JsonUtility.FromJsonOverwrite(json, parameter);
            Debug.Log($"Color:{parameter.color}, Buff: {parameter.buff}");
            SetParameters(parameter);
        }
    }

    void SetParameters(FireworkParameter parameter)
    {
        vfx.SetBool("PikaPika_ON/OFF",parameter.buff.HasFlag(ProjectileBuff.PikaPika));
        vfx.SetBool("Gravity_ON/OFF",parameter.buff.HasFlag(ProjectileBuff.Gravity));
        vfx.SetBool("Trail_ON/OFF",parameter.buff.HasFlag(ProjectileBuff.Trail));
        vfx.SetBool("ColorPattern_Single/Gradient", !parameter.buff.HasFlag(ProjectileBuff.Gradient));

        // Gradient gradient = vfx.GetGradient(
        //     parameter.buff.HasFlag(ProjectileBuff.Gradient) ? "Gradient_Color" :"Single_Color" );
        //
        // GradientColorKey[] colorKeys = new GradientColorKey[gradient.colorKeys.Length];
        // GradientAlphaKey[] alphaKeys = new GradientAlphaKey[gradient.alphaKeys.Length];
        //
        // for (var i = 0; i < alphaKeys.Length; i++)
        // {
        //     alphaKeys[i].alpha = gradient.alphaKeys[i].alpha;
        //     alphaKeys[i].time = gradient.alphaKeys[i].time;
        // }
        //
        // for (var i = 0; i < colorKeys.Length; i++)
        // {
        //     if (parameter.buff.HasFlag(ProjectileBuff.Gradient) ? i != 1 : i == 0)
        //     {
        //         colorKeys[i].color = gradient.colorKeys[i].color;
        //     }
        //     else colorKeys[i].color = Palette.GetColor(parameter.color) * 256;
        //
        //     colorKeys[i].time = gradient.colorKeys[i].time;
        // }
        
        Gradient newGradient;
        // newGradient.SetKeys(colorKeys,alphaKeys);
        // vfx.SetGradient(
        //     parameter.buff.HasFlag(ProjectileBuff.Gradient) ? "Gradient_Color" :"Single_Color", 
        //     newGradient);
        //if (singlePalette != null)
        //{
        //    newGradient = singlePalette.GetGradient(parameter.color);
        //    if (newGradient != null)
        //    {
        //        vfx.SetGradient("Single_Color", newGradient);
        //    }
        //}
        //if (gradientPalette != null)
        //{
        //    newGradient = gradientPalette.GetGradient(parameter.color);
        //    if (newGradient != null)
        //    {
        //        vfx.SetGradient("Gradient_Color", newGradient);
        //    }
        //}
        //if (pTrailPalette != null) {
        //    newGradient = pTrailPalette.GetGradient(parameter.color);
        //    if (newGradient != null) 
        //    {
        //        vfx.SetGradient("PTrialColorGradient", newGradient);
        //    }
        //}
    }

    public void TestReloadLab() {
        SceneManager.LoadScene("Lab");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
