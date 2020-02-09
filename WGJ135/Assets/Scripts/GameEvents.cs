public static class GameEvents
{ 
        public static System.Action GameOver;
        
        public static System.Action PlayerDamage;
        public static System.Action PlayerHeal;
        public static System.Action PlayerShoot;
        
        public static System.Action PurpleStar;
        public static System.Action YellowStar;
        public static System.Action RedStar;
        public static System.Action BlueStar;

        public static System.Action BlueCannon;
        public static System.Action RedCannon;
        public static System.Action YellowCannon;
        public static System.Action PurpleCannon;
        
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

        public static void OnPlayerShoot()
        {
                PlayerShoot?.Invoke();
        }
        
        public static void OnPurpleStar()
        {
                PurpleStar?.Invoke();
        }

        public static void OnYellowStar()
        {
                YellowStar?.Invoke();
        }

        public static void OnRedStar()
        {
                RedStar?.Invoke();
        }

        public static void OnBlueStar()
        {
                BlueStar?.Invoke();
        }
        
        public static void OnRedCannon()
        {
                RedCannon?.Invoke();
        }
        
        public static void OnBlueCannon()
        {
                BlueCannon?.Invoke();
        }
        
        public static void OnYellowCannon()
        {
                YellowCannon?.Invoke();
        }
        
        public static void OnPurpleCannon()
        {
                PurpleCannon?.Invoke();
        }
        
        
}
