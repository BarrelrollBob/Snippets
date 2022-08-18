using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    internal class Boss
    {
        private string? _name;
        private int _healthPoints;
        private int _damage;
        private int _money;
        private int _attackSelector;

        public string Name { get => _name; set => _name = value; }
        public int HealthPoints { get => _healthPoints; set => _healthPoints = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public int Money { get => _money; set => _money = value; }
        public int AttackSelector { get => _attackSelector; }

        public Boss()
        {
            Name = "Olbaid";
            HealthPoints = 9999;
            Damage = 40;
        }

        public bool IsDead()
        {
            if (_healthPoints <= 0) return true;
            else return false;
        }

        public int TakeDamage(int damage)
        {
            return _healthPoints -= damage;
        }
        public int LightAttack()
        {
            return Damage;
        }

        public int HeavyAttack()
        {
            return Damage * 2;
        }

        public void GetBossAttack()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 4);
            
            if (randomNumber <= 2)
            {
                GameSystem.AddToCombatLog("Olbaid is going to hit you with a light attack!");
                _attackSelector = 1;
            }
            if (randomNumber > 2)
            {
                GameSystem.AddToCombatLog("Olbaid is going to hit you with a heavy attack!");
                _attackSelector = 2;
            }
        }
    }
}
