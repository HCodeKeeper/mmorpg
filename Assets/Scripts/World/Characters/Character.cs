using System;
using UnityEngine;

namespace World
{
    public abstract class Character : MonoBehaviour
    {
        public delegate void UpdateUnitframe();

        public event UpdateUnitframe StatUpdate;
        private string _name;
        private int _maxHp = -1;
        private int _hp = -1;
        public string Name
        {
            get
            {
                return _name;
            }
            protected set
            {
                bool isInit = _name == null;
                _name = value;
                if (!isInit)
                {
                    StatUpdate();
                }
            }
        }

        public int MaxHP
        {
            get
            {
                return _maxHp;
            }
            protected set
            {
                bool isInit = _maxHp == -1;
                _maxHp = value;
                if (!isInit)
                {
                    StatUpdate();
                }
            }
        }

        public int HP
        {
            get
            {
                return _hp;
            }
            protected set
            {
                bool isInit = _hp == -1;
                _hp = value;
                if (!isInit)
                {
                    StatUpdate();
                }
            }
        }

        public float GetRatio()
        {
            return (float)HP / MaxHP;
        }

        public void DecreaseHP(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Cant Decrease hp with negative numbers");
            }
            if (damage <= HP)
            {
                HP -= damage;
            }
        }

        protected void Kill()
        {
            if (HP == 0)
            {
                StatUpdate -= Kill;
                Destroy(gameObject);
            }
        }

        protected void Init()
        {
            StatUpdate += Kill;
        }
    }
}