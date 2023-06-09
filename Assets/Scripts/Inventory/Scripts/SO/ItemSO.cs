using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventory.Model
{
    public abstract  class ItemSO : ScriptableObject
    {
        [field: SerializeField]
        public bool IsStackable { get; set; }
        [SerializeField]
        public int ID => GetInstanceID();

        [field: SerializeField]
        public int MaxStackSize { get; set; } = 1;

        [field: SerializeField]
        public string Name { get; set; }

        [field: SerializeField]
        [field: TextArea]
        public string Description { get; set; }
        [field: SerializeField]
         public Sprite ItemImage { get; set; }
        [field: SerializeField]
        public Sprite BackGround { get; set; }
        [field: SerializeField] public int DropChange;
        [field: SerializeField] public int index;
        [field: SerializeField] public float Price;
        [field: SerializeField] public Type type;
        [field: SerializeField] public List<ItemParameter> DefaultParametersList { get; set; }
        
    }
    [Serializable]
    public struct ItemParameter : IEquatable<ItemParameter>
    {
        public ItemParameterSO itemParameter;
        public float value;

        public bool Equals(ItemParameter other)
        {
            return other.itemParameter == itemParameter;
        }
    }
   
}
 public enum Type { Gold, Diamond }

