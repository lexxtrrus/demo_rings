﻿using UnityEngine;

namespace GameLogic.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public GameLoopState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Exit()
        {
            
        }

        public void Enter()
        {
            var character = Object.Instantiate(Resources.Load("Prefabs/Character") as GameObject);
        }
    }
}