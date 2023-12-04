using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : Screen
{
    public event Action StartButtonClicked;

    protected override void OnButtonClick()
    {
        StartButtonClicked?.Invoke();
    }
}
