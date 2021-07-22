using UnityEngine;

namespace GameLogic.States
{
    public class LoadingState : IState
    {
        private const string Game = "Game";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCanvasFade _loadingCanvas;

        public LoadingState(GameStateMachine stateMachine, SceneLoader sceneLoader,
            LoadingCanvasFade loadingCanvas)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCanvas = loadingCanvas;
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        public void Enter()
        {
            _loadingCanvas.Show();
            _sceneLoader.Load(Game, OnLoaded);
        }

        public void Exit()
        {
            _loadingCanvas.Hide();
        }
    }
}