using System.Collections;
using UnityEngine;

public class BubbleBurstVFX : MonoBehaviour
{
    [SerializeField] private float _burstsInterval;

    private ParticleSystem _particle;

    private AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }

    private void OnValidate()
    {
        _burstsInterval = Mathf.Abs(_burstsInterval);
    }

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(WaitInterval());
    }

    private IEnumerator WaitInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(_burstsInterval);
            InitiateVFX();
        }      
    }

    private void InitiateVFX()
    {
        _particle.Play();
        AudioPlayer.PlaySound(Sounds.BubbleVFX);
    }
}
