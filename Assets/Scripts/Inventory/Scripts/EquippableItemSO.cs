using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class EquippableItemSO : ItemSO, IDestroyableItem, IItemAction
    {

        public string ActionName => "Use";
        [field: SerializeField]
        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject character,List<ItemParameter> itemState=null)
        {
            AgentWeapon weaponSystem = character.GetComponent<AgentWeapon>();
            if (weaponSystem != null)
            {
                weaponSystem.SetWeapon(this, itemState == null ?
                    DefaultParametersList : itemState);
                return true;
            }
            return false;
        }
        public interface IDestroyableItem
        {

        }

        public interface IItemAction
        {
            public string ActionName { get; }
            [field: SerializeField]
            public AudioClip actionSFX { get; }
            bool PerformAction(GameObject character, List<ItemParameter> itemState);
        }
        [Serializable]
        public class ModifierData
        {
            public CharacterStatModifierSO statModifier;
            public float value;
        }


    }
}
