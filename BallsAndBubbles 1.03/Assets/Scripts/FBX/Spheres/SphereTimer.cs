using System.Collections;
using UnityEngine;
using TMPro;
using Game.Events;

public class SphereTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _time = 15;

    private void Start()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _time--;

            if (_time == 0)
            {
                EventAggregator.Post(this, new GameEndWithCurrentResultEvent { });
            }

            UpdateText();
        }       
    }

    private void UpdateText()
    {        
        _text.text = _time.ToString();       
    }
}
