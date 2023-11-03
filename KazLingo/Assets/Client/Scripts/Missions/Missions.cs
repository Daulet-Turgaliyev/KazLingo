using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Client.Scripts.Missions
{
    public class Missions
    {
        private int _currentMissionIndex; 
        
        private readonly List<AMission> _allMissions = new List<AMission>();
        public IReadOnlyList<AMission> GetAllMissions => _allMissions;
        
        private readonly List<AMission> _trueMissions = new List<AMission>();
        public IReadOnlyList<AMission> GetTrueMissions => _trueMissions;


        private readonly List<AMission> _falseMission = new List<AMission>();

        public int TrueMissionCount => _trueMissions.Count;


        public int GetMissionCount => _allMissions.Count;
        public AMission GetCurrentMission => _allMissions[_currentMissionIndex];

        private bool _isFalseMissionActive;
        public bool GetFalseMissionActive => _isFalseMissionActive;

        [Inject] private WindowsManager _windowsManager;

        public void AddMission(AMission mission)
        {
            _allMissions.Add(mission);
        }
        public void AddTrueMission(AMission mission)
        {
            if (_trueMissions.Contains(mission) == false)
            {
                _trueMissions.Add(mission);
            }
        }
        public void AddFalseMission(AMission mission)
        {
            if (_falseMission.Contains(mission) == false)
            {
                _falseMission.Add(mission);
            }
        }

        public void LoadFalseMissions()
        {
            _currentMissionIndex = 0;
            DisableLastMission();
            _allMissions.Clear();
            foreach (var mission in _falseMission)
            {
                _allMissions.Add(mission);
            }
            _falseMission.Clear();
            ActiveFirstMission();
        }
        
        public void ActiveFirstMission()
        {
            _allMissions[0].gameObject.SetActive(true);
        }

        public void DisableLastMission()
        {
            _allMissions[^1].gameObject.SetActive(false);
        }
        
        public void DisableAllMissions()
        {
            foreach (var mission in _allMissions)
            {
                mission.gameObject.SetActive(false);
            }
        }

        public bool HasNextMission()
        {
            if (_currentMissionIndex < GetMissionCount - 1)
            {
                return true;
            }

            return false;
        }
        
        public bool HasFalseMissions()
        {
            if (_falseMission.Count > 0)
            {
                if (_isFalseMissionActive == false)
                {
                    _windowsManager.OpenWindow<FalseMissionWindow>();
                }
                
                _isFalseMissionActive = true;
                return true;
            }

            return false;
        }
        
        
        public void ActiveNextMission()
        {
            if (HasNextMission() == true)
            {
                _allMissions[_currentMissionIndex].gameObject.SetActive(false);
                _currentMissionIndex++;
                _allMissions[_currentMissionIndex].gameObject.SetActive(true);
            }
        }
    }
}