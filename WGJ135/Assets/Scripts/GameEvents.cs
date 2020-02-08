public static class GameEvents
{ 
        public static System.Action GameOver;
        public static System.Action PlayerDamage;
        public static System.Action PlayerHeal;

        public static void OnGameOver()
        {
                GameOver?.Invoke();
        }

        public static void OnPlayerDamage()
        {
                PlayerDamage?.Invoke();
        }

        public static void OnPlayerHeal()
        {
                PlayerHeal?.Invoke();
        }
}
