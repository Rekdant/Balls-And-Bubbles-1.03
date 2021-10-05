using UnityEngine;
using Game.Events;

public class BlackSphereVFX : SphereVFX
{
    private const int MinChance = 0;
    private const int MaxChance = 100;

    [SerializeField] private int _destroyChance;

    private int _randomNumber
    {
        get { return Random.Range(MinChance, MaxChance); }
    }

    private void OnValidate()
    {
        _destroyChance = Mathf.Abs(_destroyChance);
        _destroyChance = Mathf.Clamp(_destroyChance, MinChance, MaxChance);
    }

    private void Start()
    {        
        DestroyRandomSpheres();
        Destroy(gameObject);
    }

    private void DestroyRandomSpheres()
    {
        Sphere[] _spheres = FindObjectsOfType<Sphere>();

        if (_spheres.Length > 0)
        {
            foreach (var sphere in _spheres)
            {
                if (_randomNumber < _destroyChance)
                {
                    sphere.InitializeDestroy(0, true, false, false);
                    VFXPlayer.Play(VFXType.BlackSphereExplosion, sphere.transform.position);
                }
            }
        }
        
        AudioPlayer.PlaySound(Sounds.BlackSphereVFX);
    }
}
