using System.Collections.Generic;

namespace Client.Scripts.Missions
{
    public class Missions
    {
        private int _currentLevelIndex;
        public int GetCurrentLevelIndex => _currentLevelIndex;

        private readonly List<AMission> _missionsInGame = new List<AMission>();

        public int GetMissionCount => _missionsInGame.Count;
        public AMission GetCurrentMission => _missionsInGame[_currentLevelIndex];

        public void AddMission(AMission mission)
        {
            _missionsInGame.Add(mission);
        }

        public void ActiveFirstMission()
        {
            _missionsInGame[0].gameObject.SetActive(true);
        }
        
        public void DisableAllMissions()
        {
            foreach (var mission in _missionsInGame)
            {
                mission.gameObject.SetActive(false);
            }
        }

        public bool HasNextMission()
        {
            if (_currentLevelIndex < GetMissionCount - 1)
            {
                return true;
            }

            return false;
        }

        public void ActiveNextMission()
        {
            if (HasNextMission() == true)
            {
                _missionsInGame[_currentLevelIndex].gameObject.SetActive(false);
                _currentLevelIndex++;
                _missionsInGame[_currentLevelIndex].gameObject.SetActive(true);
            }
        }
    }
}