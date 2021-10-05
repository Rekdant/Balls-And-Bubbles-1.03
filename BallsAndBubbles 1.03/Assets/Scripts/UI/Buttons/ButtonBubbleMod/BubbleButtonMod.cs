using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum BubbleButtonType
{
    Block,
    Swap,
    Mix
}

public class BubbleButtonMod : MonoBehaviour
{
    [SerializeField] private BubbleButtonType _bubbleButtonMod;
    [SerializeField] private float _replacementTime;
    [SerializeField] private List<Button> _buttons;

    private BubbleButtonsSwap _bubbleButtonsSwap;
    private BubbleButtonBlock _bubbleButtonBlock;
    private Button _buttonSwapOne;
    private Button _buttonSwapTwo;
    private Button _buttonBlock;

    private Button RandomButton
    {
        get { return _buttons[Random.Range(0, _buttons.Count)]; }
    }

    private void OnValidate()
    {
        _replacementTime = Mathf.Abs(_replacementTime);
    }

    private void Awake()
    {
        _bubbleButtonsSwap = new BubbleButtonsSwap();
        _bubbleButtonBlock = new BubbleButtonBlock();
    }

    private void Start()
    {
        switch (_bubbleButtonMod)
        {
            case BubbleButtonType.Swap:
                StartCoroutine(SwapButtons());
                break;
            case BubbleButtonType.Block:
                StartCoroutine(BlockButton());
                break;
            case BubbleButtonType.Mix:
                StartCoroutine(MixMods());
                break;
        }
    }

    private IEnumerator BlockButton()
    {
        while (true)
        {
            _buttonBlock = RandomButton;
            
            _bubbleButtonBlock.Init(_buttonBlock);
            yield return new WaitForSeconds(_replacementTime);
            _bubbleButtonBlock.DeInit(_buttonBlock);
        }        
    }

    private IEnumerator SwapButtons()
    {
        while (true)
        {
            _buttonSwapOne = RandomButton;
            _buttonSwapTwo = RandomButton;

            while (_buttonSwapOne == _buttonSwapTwo)
            {
                _buttonSwapTwo = RandomButton;
            }

            _bubbleButtonsSwap.Init(_buttonSwapOne, _buttonSwapTwo);
            yield return new WaitForSeconds(_replacementTime);
            _bubbleButtonsSwap.DeInit(_buttonSwapOne, _buttonSwapTwo);
        }
    }

    private IEnumerator MixMods()
    {
        while (true)
        {
            _buttonSwapOne = RandomButton;
            _buttonSwapTwo = RandomButton;
            _buttonBlock = RandomButton;

            while (_buttonSwapOne == _buttonSwapTwo)
            {
                _buttonSwapTwo = RandomButton;
            }

            while (_buttonBlock == _buttonSwapOne || _buttonBlock == _buttonSwapTwo)
            {
                _buttonBlock = RandomButton;
            }

            _bubbleButtonBlock.Init(_buttonBlock);
            _bubbleButtonsSwap.Init(_buttonSwapOne, _buttonSwapTwo);
            yield return new WaitForSeconds(_replacementTime);
            _bubbleButtonBlock.DeInit(_buttonBlock);
            _bubbleButtonsSwap.DeInit(_buttonSwapOne, _buttonSwapTwo);
        }      
    }
}
