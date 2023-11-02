using System;
using UnityEngine;
using UnityEngine.UI;

public class ServicePanel : BaseWindow
{
    [SerializeField] private Slider _progressSlider;

    public event Action onClicked = () => { };

    public void Initialize(int missionCount)
    {
        _progressSlider.maxValue = missionCount;
        _progressSlider.value = 0;
    }

    public void UpdateProgressSlider(int currentMissionIndex)
    {
        _progressSlider.value = currentMissionIndex;
    }
    
    public void OnClick()
    {
        onClicked?.Invoke();
    }
}
