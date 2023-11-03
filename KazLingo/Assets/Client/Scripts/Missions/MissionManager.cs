using System.Threading.Tasks;
using Client.Scripts.Data;
using Client.Scripts.GameStats;
using Client.Scripts.Missions;
using Client.Scripts.UI;
using UnityEngine;
using Zenject;

public class MissionManager : MonoBehaviour
{
    private WindowsManager _windowsManager;
    private AudioController _audioController;
    private ServicePanel _servicePanel;
    private ResultPanel _resultPanel;

    private Missions _missions;
    private GameStats _gameStats;
    
    [SerializeField] private LessonData _lesson;
    
    private MissionBaseData[] _missionsData;
    
    [Inject]
    private void Constructor(WindowsManager windowsManager, AudioController audioController, DiContainer diContainer)
    {
        _windowsManager = windowsManager;
        _audioController = audioController;
        _gameStats = new GameStats();
        _missions = new Missions();
        
        diContainer.Inject(_missions);
    }
    
    private void Start()
    {
        Initialize(_lesson);
    }

    private async void Initialize(LessonData lessonData)
    {
        _windowsManager.OpenWindow<LoadingWindow>();
        _missionsData = _lesson.Missions;
        
        foreach (var mission in _missionsData)
        {
            AMission newMission = CreateMission(mission);
            _missions.AddMission(newMission);
        }

        _resultPanel = _windowsManager.OpenWindow<ResultPanel>();
        _resultPanel.onClicked += NextLevel;
        
        _servicePanel = _windowsManager.OpenWindow<ServicePanel>();
        _servicePanel.Initialize(_missions.GetMissionCount);
        _servicePanel.onClicked += CheckAnswer;
        
        _missions.DisableAllMissions();
        
        _missions.ActiveFirstMission();
        
        _resultPanel.Close();
        
        _windowsManager.OpenWindow<StartGameWindow>().Initialize(_gameStats, lessonData.LessonName, lessonData.Description, lessonData.Missions.Length);
        await Task.Delay(1000);
        _windowsManager.CloseWindow<LoadingWindow>();
    }

    private AMission CreateMission(MissionBaseData missionBaseData)
    {
        switch (missionBaseData)
        {
            case DragWordData dragWordData:
                DragWordMission dragWordMission = Instantiate(dragWordData.DragWordMission, transform);
                dragWordMission.Initialize(dragWordData);
                return dragWordMission;
            case InputImageData inputImageData:
                InputImageMission inputImage = Instantiate(inputImageData.InputImageMission, transform);
                inputImage.Initialize(inputImageData);
                return inputImage;
            case InputSoundData inputSoundData:
                InputSoundMission inputSoundMission = Instantiate(inputSoundData.InputSoundMission, transform);
                inputSoundMission.Initialize(inputSoundData);
                return inputSoundMission;
            case InputTextData inputTextData:
                InputTextMission inputTextMission = Instantiate(inputTextData.InputTextMission, transform);
                inputTextMission.Initialize(inputTextData);
                return inputTextMission;
            case InputWordData inputWordData:
                InputWordMission inputWordMission = Instantiate(inputWordData.InputWordMission, transform);
                inputWordMission.Initialize(inputWordData);
                return inputWordMission;
            case PutTogetherSentenceData putTogetherSentenceData:
                PutTogetherSentenceMission putTogetherSentenceMission = Instantiate(putTogetherSentenceData.PutTogetherSentenceMission, transform);
                putTogetherSentenceMission.Initialize(putTogetherSentenceData);
                return putTogetherSentenceMission;
        }

        return null;
    }

    private void CheckAnswer()
    {
        if (_missions.GetCurrentMission.CheckAnswer() == true)
        {
            _audioController.PlayTrueSound();
            _resultPanel.SetTrue(_missions.GetCurrentMission.MissionBaseData);
            if (_missions.GetFalseMissionActive == false)
            {
                _missions.AddTrueMission(_missions.GetCurrentMission);
                _gameStats.AddTruePoint(_missions.GetCurrentMission.MissionBaseData.Points);
                _servicePanel.UpdateProgressSlider(_missions.GetTrueMissions.Count);
            }
        }
        else
        {
            _audioController.PlayFalseSound();
            _resultPanel.SetFalse(_missions.GetCurrentMission.MissionBaseData);
            _missions.AddFalseMission(_missions.GetCurrentMission);
            
            if (_missions.GetFalseMissionActive == false)
            {
                _gameStats.AddFalsePoint(_missions.GetCurrentMission.MissionBaseData.Points);
            }
        }
    }

    private void NextLevel()
    {
        _resultPanel.Close();
        
        if (_missions.HasNextMission())
        {
            _missions.ActiveNextMission();
        }
        else if (_missions.HasFalseMissions())
        {
            _missions.LoadFalseMissions();
            foreach (var mission in _missions.GetAllMissions)
            {
                mission.ResetMission();
            }
        }
        else
        {
            _missions.DisableLastMission();
            _gameStats.Stop(Time.time);
            _windowsManager.OpenWindow<GameOverWindow>().Initialize(_gameStats);
        }
    }

    private void OnDestroy()
    {
        _servicePanel.onClicked -= CheckAnswer;
        _resultPanel.onClicked -= NextLevel;
    }
}