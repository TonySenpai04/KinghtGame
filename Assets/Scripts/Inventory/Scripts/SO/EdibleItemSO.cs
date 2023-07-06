using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventory.Model
{
    [CreateAssetMenu]
    public class EdibleItemSO : ItemSO, IDestroyableItem, IItemAction
    {
      //  [field: SerializeField] public int DropChange;
        // Start is called before the first frame update
        [SerializeField]
        public List<ModifierData> modifiersData = new List<ModifierData>();
        public string ActionName => "Consume";
        [field:SerializeField]
        public AudioClip actionSFX { get; private set; }
        
        public bool PerformAction(GameObject character, List<ItemParameter> itemState=null)
        {
            foreach (ModifierData data in modifiersData)
            {
                data.statModifier.AffectCharacter(character, data.value);
            }
            return true;
        }
        public bool PerformActionRemove(GameObject character, List<ItemParameter> itemState = null)
        {
            foreach (ModifierData data in modifiersData)
            {
                data.statModifier.AffectCharacter(character, data.value*-1);
            }
            return true;
        }

    }
 
    public interface IDestroyableItem
    {

    }

    public interface IItemAction
    {
        public string ActionName { get; }
        [field: SerializeField]
        public AudioClip actionSFX { get; }
        bool PerformAction(GameObject character, List<ItemParameter> itemState );
        bool PerformActionRemove(GameObject character, List<ItemParameter> itemState);
    }

    [Serializable]
    public class ModifierData
    {
        public CharacterStatModifierSO statModifier;
        public float value;
    }
}

