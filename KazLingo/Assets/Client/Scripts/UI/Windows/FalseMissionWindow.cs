using Client.Scripts.UI;
using Zenject;

public class FalseMissionWindow : BaseWindow
{
        [Inject] private AudioController _audioController;
        private void Start()
        {
                _audioController.PlayFalsePanelSound();
        }

        public void Continue()
        {
                Destroy(gameObject);
        }
}
