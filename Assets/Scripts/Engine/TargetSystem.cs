using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Engine
{
    public class TargetSystem : MonoBehaviour
    {
        private HashSet<string> characterTags = new HashSet<string>();
        public Player.Player player;
        public UnitFrameLocator UnitFrameLocator;

        private void Awake()
        {
            characterTags.Add("Enemy");
            characterTags.Add("NPC");
            characterTags.Add("Interactable");
        }

        public void HandleTarget(RaycastHit hitData)
        {
            GameObject target = GetCharacter(hitData);
            if (target != null)
            {
                if (IsSelected(target))
                {
                    
                }
                else
                {
                    player.SetTarget(target);
                    UnitFrameLocator.Locate(player.GetTarget());
                }
            }
        }
        

        public bool IsSelected(GameObject target)
        {
            return player.GetTarget() == target;
        }
        
        public GameObject GetCharacter(RaycastHit hitData)
        {
            GameObject character = hitData.transform.gameObject;
            if (character != null && characterTags.Contains(character.tag))
            {
                return character;
            }

            return null;
        }
    }
}