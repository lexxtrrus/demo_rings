using System;
using System.Collections.Generic;

namespace GameLogic.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCanvasFade loadingCanvas)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(InitApplicationState)] = new InitApplicationState(this, sceneLoader),
                [typeof(LoadingState)] = new LoadingState(this, sceneLoader, loadingCanvas),
                [typeof(GameLoopState)] = new GameLoopState(this, sceneLoader),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }
        
        private TState GetState<TState>() where TState : class, IState => _states[typeof(TState)] as TState;
    }
}