public static class GameEvents
{ 
        public static System.Action GameOver;

        public static void OnGameOver()
        {
                GameOver?.Invoke();
        }
}
