using UnityEngine;
using World;

namespace Items.Weapon
{
    public interface Weapon
    {
        public void Hit(Character target);
    }
}