using System;
using Client.Scripts.Data;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void Open()
        {
            SceneManager.LoadScene("GameScene");
        }
        
        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}