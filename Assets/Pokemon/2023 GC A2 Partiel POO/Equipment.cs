
namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Défintion simple d'un équipement apportant des boost de stats
    /// </summary>
    public class Equipment
    {
        public int _bonusHealth;
        public int _bonusAttack;
        public int _bonusDefense;
        public int _bonusSpeed;

        public Equipment(int bonusHealth, int bonusAttack, int bonusDefense, int bonusSpeed)
        {
            _bonusHealth = bonusHealth;
            _bonusAttack = bonusAttack;
            _bonusDefense = bonusDefense;
            _bonusSpeed = bonusSpeed;
        }

        public int BonusHealth
        {
            get => _bonusHealth;
        }
        public int BonusAttack
        {
            get => _bonusAttack;
        }
        public int BonusDefense
        {
            get => _bonusDefense;
        }
        public int BonusSpeed
        {
            get => _bonusSpeed; 
        }

    }
}
