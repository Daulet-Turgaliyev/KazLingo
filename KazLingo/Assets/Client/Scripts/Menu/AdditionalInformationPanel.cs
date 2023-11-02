using System;
using Client.Scripts.Data;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Client.Scripts
{
    public class AdditionalInformationPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _descriptionText;

        public void Initialize(LessonData lessonData)
        {
            _titleText.text = lessonData.Tittle;
            _descriptionText.text = lessonData.Description;
        }
        
        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}