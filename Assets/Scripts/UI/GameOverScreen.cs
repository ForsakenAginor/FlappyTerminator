using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : Screen
{
    public event Action RestartButtonClicked;

    protected override void OnButtonClick()
    {
        if (RestartButtonClicked != null)
            RestartButtonClicked();
    }
}
