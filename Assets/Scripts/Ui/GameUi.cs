using Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class GameUi : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textResultGame;
        [SerializeField] private Button _homeButton;
        private GameStateMachine _gameStateMachine;

        public void Initialize(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _homeButton.onClick.AddListener(GoHome);
        }

        public void Construct(string text)
        {
            _textResultGame.text = text;
        }
        public void Open()
        {
            gameObject.SetActive(true);
        }
        private void GoHome()
        {
            _gameStateMachine.Enter<MenuState>();
        }
    }
}
