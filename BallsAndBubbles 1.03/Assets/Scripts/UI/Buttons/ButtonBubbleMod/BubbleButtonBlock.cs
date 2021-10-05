using UnityEngine;
using UnityEngine.UI;

public class BubbleButtonBlock 
{
    private Button _button;

    public void Init(Button button)
    {
        _button = button;

        SetColor(Color.red);
        SetInteractivity(false);
        SetActivityEventTrigger(false);      
    }

    public void DeInit(Button button)
    {
        _button = button;

        SetColor(Color.white);
        SetInteractivity(true);
        SetActivityEventTrigger(true);
    }

    private void SetColor(Color color)
    {
        _button.GetComponent<Image>().color = color;
    }

    private void SetInteractivity(bool isInteractive)
    {
        _button.interactable = isInteractive;
    }

    private void SetActivityEventTrigger(bool isActive)
    {
        _button.GetComponent<BubbleButton>().enabled = isActive;
    }
}
