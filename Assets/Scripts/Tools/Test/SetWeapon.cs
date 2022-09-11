using System;
using Items.Weapon;
using UnityEngine;

namespace Tools.Test
{
    public class SetWeapon : MonoBehaviour
    {
        public Player.Player PlayerScript;
        public GameObject Weapon;

        private void Start()
        {
            PlayerScript.SetWeapon(Weapon);
        }
    }
}