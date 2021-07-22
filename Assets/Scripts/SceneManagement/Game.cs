using GameLogic.States;

namespace GameLogic
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCanvasFade loadingCanvas)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCanvas);
        }
    }
}