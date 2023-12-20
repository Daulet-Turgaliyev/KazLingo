using System;
using UnityEngine;

namespace Client.Scripts.Missions
{
    [Serializable]
    public struct WordInfo
    {
        [field: SerializeField] public string[] Kazakh;
        [field: SerializeField] public string[] Russian;

        public WordInfo(string[] kazakh, string[] russian)
        {
            Kazakh = kazakh;
            Russian = russian;
        }
    }
}