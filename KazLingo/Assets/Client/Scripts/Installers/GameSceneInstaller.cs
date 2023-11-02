using Client.Scripts.UI;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private WindowsManager _windowsManager;
    [SerializeField] private AudioController _audioController;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BackButton>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<GlobalSettings.Screen>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<WindowsManager>().FromInstance(_windowsManager).AsSingle();
        Container.BindInterfacesAndSelfTo<AudioController>().FromComponentInNewPrefab(_audioController).AsSingle();
    }
}