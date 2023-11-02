using UnityEngine;

namespace Client.Scripts.Data
{
    [CreateAssetMenu(fileName = "Mission", menuName = "Create Mission/New Mission", order = 0)]
    public class MissionData : ScriptableObject
    {
        [field: SerializeField] public MissionBaseData[] Missions { get; private set; }
    }
}