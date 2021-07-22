namespace GameLogic.States
{
    public class InitApplicationState : IState
    {
        private const string InitScene = "InitScene";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public InitApplicationState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(InitScene, onLoaded: SwitchState);
        }

        private void SwitchState()
        {
            _stateMachine.Enter<LoadingState>();
        }

        public void Exit()
        {
                
        }
        
        private void RegisterServices()
        {
            
        }
    }
}