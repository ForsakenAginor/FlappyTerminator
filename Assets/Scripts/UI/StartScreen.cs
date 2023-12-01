using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : Screen
{
    public delegate void ButtonClickedDelegate();

    public event ButtonClickedDelegate StartButtonClicked;

    protected override void OnButtonClick()
    {
        StartButtonClicked?.Invoke();
    }
}
