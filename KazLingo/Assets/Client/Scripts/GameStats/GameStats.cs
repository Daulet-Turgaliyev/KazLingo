using UnityEngine;

namespace Client.Scripts.GameStats
{
    public sealed class GameStats: IAutoInjectable
    {
        private int _allMissions;
        private int _trueMissions;
        private int _falseMissions;
        private int _points;
        private float _startTime;
        private float _endTime;
        private float _timeExpired;
        
        
        public void Initialize(float startTime, int missionCount)
        {
            _startTime = startTime;
            _allMissions = missionCount;
        }

        public void AddTruePoint(int points)
        {
            _trueMissions++;
            _points += points;
        }

        public void AddFalsePoint(int points)
        {
            _falseMissions++;
            int removedPoints = points / 2;
            _points -= Mathf.FloorToInt(removedPoints);
        }

        public void Stop(float endTime)
        {
            _endTime = endTime;
            
            _timeExpired = _endTime - _startTime;
        }

        public Result GetResult()
        {
            Result result = new Result(_points, _allMissions, _trueMissions, _timeExpired);
            return result;
        }
    }

    public struct Result
    {
        public readonly int Points;
        public readonly string Accuracy;
        public readonly float AccuracyFloat;
        public readonly string Time;

        public Result(int points, int allMissions, int trueMissions, float timeInSecond) : this()
        {
            Points = Mathf.Clamp(points, 40, int.MaxValue);
            Accuracy = GetFormattedAccuracy(allMissions, trueMissions);
            AccuracyFloat = GetAccuracy(allMissions, trueMissions);
            Time = GetFormattedTime(timeInSecond);
        }

        private string GetFormattedTime(float timeInSecond)
        {
            int minutes = (int)timeInSecond / 60;
            int seconds = (int)timeInSecond % 60;
            
            string formattedTime = $"{minutes:00}:{seconds:00}";
            return formattedTime;
        }
        
        private string GetFormattedAccuracy(int allMissions, int trueMissions)
        {
            if (trueMissions == 0)
            {
                return 0.ToString("F2") + " %";
            }
            double accuracy = (double) trueMissions / allMissions * 100.0;
            float accuracyFloat = Mathf.Clamp((float)accuracy, 0f, float.MaxValue);
            return accuracyFloat.ToString("F2") + " %";
        }
        private float GetAccuracy(float allMissions, int trueMissions)
        {
            if (trueMissions == 0)
            {
                return 0f;
            }
            double accuracy = (double)trueMissions / allMissions * 100.0;
            float accuracyFloat = Mathf.Clamp((float)accuracy, 0f, float.MaxValue);
            return accuracyFloat;
        }
    }
}