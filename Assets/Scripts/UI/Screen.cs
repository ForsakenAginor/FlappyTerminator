using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button StartButton;

    protected Image ButtonImage;

    private void Awake()
    {
        ButtonImage = StartButton.GetComponent<Image>();    
    }

    private void OnEnable()
    {
        StartButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        StartButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Open()
    {
        StartButton.interactable = true;
        ButtonImage.raycastTarget = true;
        CanvasGroup.alpha = 1;
    }

    public void Close()
    {
        StartButton.interactable = false;
        ButtonImage.raycastTarget = false;
        CanvasGroup.alpha = 0;
    }   

    protected abstract void OnButtonClick();
}
