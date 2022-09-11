using UnityEngine;
using World;

namespace Items.Weapon.Fists
{
    public class TestFists :  MonoBehaviour, Weapon
    {
        public void Hit(Character target)
        {
            target.DecreaseHP(1);
        }
    }
}