using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderBase : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Slider _slider;

    private void Awake()
    {
        Init();
        RespondSliderDragging();
    }

    private void Init()
    {
        _slider = GetComponent<Slider>();
    }

    private void RespondSliderDragging()
    {
        _slider.onValueChanged.AddListener(OnSliderChangeValueHandler);
    }

    protected abstract void OnSliderChangeValueHandler(float value);

    protected void SaveValue(string PlayerPrefsKey, float value, int decimalPlaces = 0)
    {
        PlayerPrefs.SetFloat(PlayerPrefsKey, (float)Math.Round(value, decimalPlaces));
    }

    protected void SetValue(float value, int decimalPlaces = 0)
    {
        _slider.value = (float)Math.Round(value, decimalPlaces);
        _text.text = _slider.value.ToString();
    }

    protected void SetStartingValue(string PlayerPrefsKey, float defaultValue)
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKey))
        {
            _slider.value = PlayerPrefs.GetFloat(PlayerPrefsKey);
        }
        else
        {
            _slider.value = defaultValue;
        }

        _text.text = _slider.value.ToString();
    }   
}
