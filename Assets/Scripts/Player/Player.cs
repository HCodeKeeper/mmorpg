using System;
using Engine;
using Items.Weapon;
using UnityEngine;
using World;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private GameObject weapon;
        private Weapon weaponScript;
        private GameObject target;
        private Character targetScript;
        void Start()
        {
            //SetWeapon(Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/TestWeapon")));
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Hit();
            }
        }

        public void Hit()
        {
            if (weaponScript != null)
            {
                if (targetScript != null)
                {
                    weaponScript.Hit(targetScript);
                }
            }
        }

        public void SetWeapon(GameObject weapon)
        {
            if (weapon.CompareTag("Weapon"))
            {
                this.weapon = weapon;
                weaponScript = this.weapon.GetComponent<Weapon>();
            }
        }
        
        
        public void SetTarget(GameObject target)
        {
            this.target = target;
            targetScript = this.target.GetComponent<Character>();
        }

        public GameObject GetTarget()
        {
            return target;
        }
    }
}
