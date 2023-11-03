using System;
using UnityEngine;
using UnityEngine.UI;

public class ServicePanel : BaseWindow
{
    [SerializeField] private Slider _progressSlider;
    private int missionCount;
    public event Action onClicked = () => { };

    public void Initialize(int missionCount)
    {
        this.missionCount = missionCount;
        _progressSlider.maxValue = missionCount;
        _progressSlider.value = 0;
    }

    public void UpdateProgressSlider(int falseMission)
    {
        int trueMission= missionCount - falseMission;
        Debug.Log($"{missionCount} - {falseMission} = {trueMission}");
        if (trueMission > _progressSlider.value)
        {
            _progressSlider.value = trueMission;
        }
    }
    
    public void OnClick()
    {
        onClicked?.Invoke();
    }
}
