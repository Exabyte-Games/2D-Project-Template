namespace Game.Managers
{
    using Game.Utilities;
    using System;

    public class GameManager : Singleton<GameManager>
    {
        public static event Action<GameState> OnBeforeStateChange;
        public static event Action<GameState> OnAfterStateChange;

        public GameState State { get; private set; }

        private void Start() => ChangeState(GameState.Starting);

        public void ChangeState(GameState newState)
        {
            OnBeforeStateChange?.Invoke(newState);

            State = newState;
            switch (newState)
            {
                case GameState.Starting:
                    HandleStarting();
                    break;
                case GameState.Running:
                    HandleRunning();
                    break;
                case GameState.Win:
                    HandleWin();
                    break;
                case GameState.Lose:
                    HandleLose();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        }

        private void HandleStarting()
        {
            ChangeState(GameState.Running);
        }

        private void HandleRunning() { }

        private void HandleWin() { }

        private void HandleLose() { }

        /// <summary>
        /// Example game states, will need to change for the game's requirements
        /// </summary>
        [Serializable]
        public enum GameState
        {
            Starting,
            Running,
            Win,
            Lose,
        }
    }
}
