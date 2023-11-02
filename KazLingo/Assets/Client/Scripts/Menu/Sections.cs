using System;
using Client.Scripts.Data;
using UnityEngine;

namespace Client.Scripts
{
    public class Sections : MonoBehaviour
    {
        [SerializeField] private AdditionalInformationPanel _additionalInformation;

        public void Start()
        {
            SectionButton[] sectionButtons = GetComponentsInChildren<SectionButton>();
            foreach (var btn in sectionButtons)
            {
                btn.onLessonDataSelected += Open;
            }
        }

        private void Open(LessonData lessonData)
        {
            _additionalInformation.gameObject.SetActive(true);
            _additionalInformation.Initialize(lessonData);
        }
    }
}