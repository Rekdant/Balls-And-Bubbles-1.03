using System;
using System.Collections.Generic;
using UnityEngine;

public enum VFXType
{
    GreenSphereExplosion,
    RedSphereExplosion,
    YellowSphereExplosion,
    BlueSphereExplosion,
    WhiteSphereExplosion,
    BlackSphereExplosion,
    MulticoloredSphereExplosion,
    GreenSphereVFX,
    RedSphereVFX,
    YellowSphereVFX,
    BlueSphereVFX,
    WhiteSphereVFX,
    BlackSphereVFX,
    MulticoloredSphereVFX,
    PlusOne,
    Teleportation
}

public class VFXPlayer : MonoBehaviour
{
    [SerializeField] private List<EffectVFXdata> _effectVFXdatas = new List<EffectVFXdata>();

    private GameObjectsFolder _folders
    {
        get { return ServiceLocator.Resolve<GameObjectsFolder>(); }
    }

    private void Awake()
    {
        ServiceLocator.Register(this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<VFXPlayer>();
    }

    public void Play(VFXType vfxType, Vector2 position)
    {
        var vfx = GetVFX(vfxType);
        Instantiate(vfx, position, transform.rotation, _folders.Get(Folder.VFX));
    }

    private GameObject GetVFX(VFXType vfxType)
    {
        var vfx = _effectVFXdatas.Find(vfxData => vfxData.Type == vfxType);
        return vfx?.VFX;
    }
}

[Serializable]
public class EffectVFXdata
{
    public VFXType Type;
    public GameObject VFX;
}