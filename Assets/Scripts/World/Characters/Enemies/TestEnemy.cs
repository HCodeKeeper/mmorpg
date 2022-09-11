using System;

namespace World.Enemies
{
    public class TestEnemy : Character
    {
        private void Start()
        {
            Name = "Enemy lvl1";
            MaxHP = 10;
            HP = MaxHP;
            Init();
        }
    }
}