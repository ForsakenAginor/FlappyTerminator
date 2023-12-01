using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : Screen
{
    public delegate void ButtonClickedDelegate();

    public event ButtonClickedDelegate RestartButtonClicked;

    protected override void OnButtonClick()
    {
        if (RestartButtonClicked != null)
            RestartButtonClicked();
    }
}
