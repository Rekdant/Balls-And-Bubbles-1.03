using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BubbleButtonsSwap
{ 
    private Button _buttonOne;
    private Button _buttonTwo;

    public void Init(Button buttonOne, Button buttonTwo)
    {
        _buttonOne = buttonOne;
        _buttonTwo = buttonTwo;

        SetColor(Color.yellow);
        SetInteractivity(false);
        Exchange();
    }


    public void DeInit(Button buttonOne, Button buttonTwo)
    {
        _buttonOne = buttonOne;
        _buttonTwo = buttonTwo;

        SetColor(Color.white);
        SetInteractivity(true);
        Exchange();
    }

    private void SetColor(Color color)
    {
        _buttonOne.GetComponent<Image>().color = color;
        _buttonTwo.GetComponent<Image>().color = color;
    }

    private void SetInteractivity(bool isInteractive)
    {
        _buttonOne.interactable = isInteractive;
        _buttonTwo.interactable = isInteractive;
    }

    private void Exchange()
    {
        Vector3 tempPosition;
        Quaternion tempRotation;

        tempPosition = _buttonOne.transform.position;
        tempRotation = _buttonOne.transform.rotation;

        _buttonOne.transform.position = _buttonTwo.transform.position;
        _buttonOne.transform.rotation = _buttonTwo.transform.rotation;

        _buttonTwo.transform.position = tempPosition;
        _buttonTwo.transform.rotation = tempRotation;
    }
}
