using System;
using System.Diagnostics;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        int _currentHealth;
        int _currentAttack;
        int _currentDefense;
        int _currentSpeed;
        int _maxHealth;

        StatusEffect _currentStatus;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            CurrentHealth = baseHealth;
            _maxHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            _currentAttack = baseAttack;
            _currentDefense = baseDefense;
            _currentSpeed = baseSpeed;
            _currentStatus = null;
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if (value < 0)
                {
                    _currentHealth = 0;
                }
                else
                {
                    _currentHealth = value;
                }
            }
        }
        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                    
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get => _currentAttack;
            set => _currentAttack = value;
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get => _currentDefense;
            set => _currentDefense = value;
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get => _currentSpeed;
            set => _currentSpeed = value;
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment
        {
            get;
            set;
        }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus
        {
            get => _currentStatus;
            set
            {
                
            }
        }

        public bool IsAlive => _currentHealth > 0;
        public int CheckResistance(Skill attacker, Skill receiver)
        {
            if (TypeResolver.GetFactor(attacker.Type, receiver.Type) == 0.8f)
            {
                return attacker.Power = (int)(attacker.Power * 0.8f);
            }
            else if (TypeResolver.GetFactor(attacker.Type, receiver.Type) == 1.2f)
            {
                return attacker.Power = (int)(attacker.Power * 1.2f);
            }
            else
            {
                return attacker.Power;
            }
        }

        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            
            CurrentHealth = _currentHealth - (s.Power - _currentDefense);
        }

        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment != null)
            {
                CurrentEquipment = newEquipment;
                _maxHealth = newEquipment._bonusHealth + _maxHealth;
                _currentAttack = newEquipment._bonusAttack + _currentAttack;
                _currentDefense = newEquipment._bonusDefense + _currentDefense;
                _currentSpeed = newEquipment._bonusSpeed + _currentSpeed;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            CurrentEquipment = null;
            MaxHealth = _baseHealth;
            Attack = _baseAttack;
            Defense = _baseDefense;
            Speed = _baseSpeed;
        }
    }
}
