using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class FireworkController : MonoBehaviour
{
    public Transform trs;
    public static FireworkController Instance;
    Dictionary<string, FireworkParameter> _allFireworkProperties;
    public FireworkBase _headFirework;
    FireworkBase _curFirework;

    public ColorPalette singlePalette;
    public ColorPalette gradientPalette;
    public ColorPalette pTrailPalette;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        _allFireworkProperties = new Dictionary<string, FireworkParameter>();
        _headFirework = null;
        _curFirework = null;
        string jsonStr = File.ReadAllText("C:/Users/rjhua/Desktop/DialogAsset/FireworkEnum.json");
        FireworkParameterJson json = JsonUtility.FromJson<FireworkParameterJson>(jsonStr);
        foreach(var firework in json.infodic)
        {
            FireworkParameter pamrater = new(firework.color, firework.buff);
            _allFireworkProperties.Add(firework.name, pamrater);
        }
        
        
        return;
    }

    void SetParameters(FireworkParameter parameter, VisualEffect vfx)
    {
        
        vfx.SetBool("PikaPika_ON/OFF",parameter.buff.HasFlag(ProjectileBuff.PikaPika));
        vfx.SetBool("Gravity_ON/OFF",parameter.buff.HasFlag(ProjectileBuff.Gravity));
        vfx.SetBool("Trail_ON/OFF",parameter.buff.HasFlag(ProjectileBuff.Trail));
        vfx.SetBool("ColorPattern_Single/Gradient", !parameter.buff.HasFlag(ProjectileBuff.Gradient));

        Gradient newGradient;
        if (singlePalette != null)
        {
            newGradient = singlePalette.GetGradient(parameter.color);
            if (newGradient != null)
            {
                vfx.SetGradient("Single_Color", newGradient);
            }
        }
        if (gradientPalette != null)
        {
            newGradient = gradientPalette.GetGradient(parameter.color);
            if (newGradient != null)
            {
                vfx.SetGradient("Gradient_Color", newGradient);
            }
        }
        if (pTrailPalette != null)
        {
            newGradient = pTrailPalette.GetGradient(parameter.color);
            if (newGradient != null)
            {
                vfx.SetGradient("PTrialColorGradient", newGradient);
            }
        }
    }

    public void AddFirework(string name)
    {
        Vector3 position = CameraController.Instance.fireworkSetCamera.ScreenToWorldPoint(Input.mousePosition);
        position.y = 0;
        GameObject firework = Resources.Load<GameObject>("Firework/" + name);
        firework = Instantiate(firework, position, Quaternion.identity, trs);
        if (_headFirework == null)
        {
            _headFirework = firework.GetComponent<FireworkBase>();
            _curFirework = _headFirework;
        }
        else
        {
            _curFirework.nextFirework = firework.GetComponent<FireworkBase>();
            _curFirework = _curFirework.nextFirework;
        }
    }
    public IEnumerator PlayFirework()
    {
        _curFirework = _headFirework;
        while (_curFirework != null)
        {
            yield return InitialVFX(_curFirework);
            _curFirework = _curFirework.nextFirework;
        }
    }

    IEnumerator InitialVFX(FireworkBase firework)
    {
        GameObject fvx = firework.transform.Find("VFX").gameObject;
        SetParameters(_allFireworkProperties[firework.s_name], fvx.GetComponent<VisualEffect>());
        fvx.SetActive(true);
        yield return new WaitForSeconds(1);
    }
}