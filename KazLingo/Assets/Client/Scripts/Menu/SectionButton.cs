using System;
using Client.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Client.Scripts
{
    public class SectionButton : MonoBehaviour
    {
        [SerializeField] private LessonData _lessonData;
        
        [SerializeField] private Image _ramaImage;
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _lessonText;

        [Header("Active"), Space(5)] 
        [SerializeField] private Color _ramaColorActive;
        [SerializeField] private Sprite _spriteActive;
        [SerializeField] private Color _textColorActive;

        [Header("DisActive"), Space(5)] 
        [SerializeField] private Color _ramaColorDisActive;
        [SerializeField] private Sprite _spriteDisActive;
        [SerializeField] private Color _textColorDisActive;

        public Action<LessonData> onLessonDataSelected = data => { };

        public void SetActivity()
        {
            _ramaImage.color = _ramaColorActive;
            _iconImage.sprite = _spriteActive;
            _lessonText.color = _textColorActive;
        }
        public void SetDisActivity()
        {
            _ramaImage.color = _ramaColorDisActive;
            _iconImage.sprite = _spriteDisActive;
            _lessonText.color = _textColorDisActive;
        }

        public void OnClick()
        {
            SceneManager.LoadScene("Polygon");
            onLessonDataSelected?.Invoke(_lessonData);
        }
    }
}