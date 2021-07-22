using GameLogic.States;
using UnityEngine;

namespace GameLogic
{
    public class InitApplicationPoint : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        [SerializeField] private LoadingCanvasFade loadingCanvas;
        private void Awake()
        {
            _game = new Game(this, loadingCanvas);
            _game.StateMachine.Enter<InitApplicationState>();
            DontDestroyOnLoad(this);
        }
    }
}