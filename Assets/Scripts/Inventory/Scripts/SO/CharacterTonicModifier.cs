using Inventory;
using Inventory.Model;
using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class CharacterBloodTonic : CharacterStatModifierSO
{
    public TypeBuff TypeBuff;
    public override void AffectCharacter(GameObject character, float val)
    {
        switch (TypeBuff)
        {
            case TypeBuff.HP:
                if (UiHpPlayer.Instance.IsUse == false)
                {
                    UiItemTonicPage.Instance.itemTonic.SetData(UiHpPlayer.Instance.IconItem);
                    UiItemTonic Item = Instantiate(UiItemTonicPage.Instance.itemTonic, Vector3.zero, Quaternion.identity, UiItemTonicPage.Instance.transform);
                    UiHpPlayer.Instance.TextTime = Item.Txt;
                    UiHpPlayer.Instance.itemTonic = Item;
                    UiItemTonicPage.Instance.inventoryUiItems.Add(Item);
                }
                UiHpPlayer.Instance.time += val;
                HPController.instance.ItemHP();
                break;
            case TypeBuff.MP:
                if (UiMpPlayer.Instance.IsUse == false)
                {
                    UiItemTonicPage.Instance.itemTonic.SetData(UiMpPlayer.Instance.IconItem);
                    UiItemTonic Item = Instantiate(UiItemTonicPage.Instance.itemTonic, Vector3.zero, Quaternion.identity, UiItemTonicPage.Instance.transform);
                    UiMpPlayer.Instance.TextTime = Item.Txt;
                    UiMpPlayer.Instance.itemTonic = Item;
                    UiItemTonicPage.Instance.inventoryUiItems.Add(UiMpPlayer.Instance.itemTonic);

                }
                UiMpPlayer.Instance.time += val;
                MPController.Instance.ItemMP();
                break;
            case TypeBuff.Dmg:
                if (UiDamagePlayer.Instance.IsUse == false)
                {
                    UiItemTonicPage.Instance.itemTonic.SetData(UiDamagePlayer.Instance.IconItem);
                    UiItemTonic Item = Instantiate(UiItemTonicPage.Instance.itemTonic, Vector3.zero, Quaternion.identity, UiItemTonicPage.Instance.transform);
                    UiDamagePlayer.Instance.TextTime = Item.Txt;
                    UiDamagePlayer.Instance.itemTonic = Item;
                    UiItemTonicPage.Instance.inventoryUiItems.Add(UiDamagePlayer.Instance.itemTonic);

                }
                UiDamagePlayer.Instance.time += val;
                AttackFunction.Instance.ItemDmg();
                break;
            case TypeBuff.Def:
                if (UIDefense.Instance.IsUse == false)
                {
                    UiItemTonicPage.Instance.itemTonic.SetData(UIDefense.Instance.IconItem);
                    UiItemTonic Item = Instantiate(UiItemTonicPage.Instance.itemTonic, Vector3.zero, Quaternion.identity, UiItemTonicPage.Instance.transform);
                    UIDefense.Instance.TextTime = Item.Txt;
                    UIDefense.Instance.itemTonic = Item;
                    UiItemTonicPage.Instance.inventoryUiItems.Add(UIDefense.Instance.itemTonic);

                }
                UIDefense.Instance.time += val;
                DefencePlayer.Instance.ItemDef();
                break;
          case TypeBuff.Exp:
                if (LevelUI.Instance.IsUse == false)
                {
                    UiItemTonicPage.Instance.itemTonic.SetData(LevelUI.Instance.IconItem);
                    UiItemTonic Item = Instantiate(UiItemTonicPage.Instance.itemTonic, Vector3.zero, Quaternion.identity, UiItemTonicPage.Instance.transform);
                    LevelUI.Instance.TextTime = Item.Txt;
                    LevelUI.Instance.itemTonic = Item;
                    UiItemTonicPage.Instance.inventoryUiItems.Add(LevelUI.Instance.itemTonic);

                }
                LevelUI.Instance.time += val;
                LevelSystem.Instance.ItemExp();
                break;
        }

        //if (TypeBuff == TypeBuff.HP)
        //{
        //    if (UiHpPlayer.Instance.IsUse == false)
        //    {
        //        UiItemTonicPage.Instance.itemTonic.SetData(UiHpPlayer.Instance.IconItem);
        //        UiItemTonic Item = Instantiate(UiItemTonicPage.Instance.itemTonic, Vector3.zero, Quaternion.identity, UiItemTonicPage.Instance.transform);
        //        UiHpPlayer.Instance.TextTime = Item.Txt;
        //        UiHpPlayer.Instance.itemTonic = Item;
        //        UiItemTonicPage.Instance.inventoryUiItems.Add(Item);
        //    }
        //    UiHpPlayer.Instance.time += val;
        //    HPController.instance.ItemHP();
        //}
        //else if(TypeBuff == TypeBuff.MP)
        //{
        //    if (UiMpPlayer.Instance.IsUse == false)
        //    {
        //        UiItemTonicPage.Instance.itemTonic.SetData(UiMpPlayer.Instance.IconItem);
        //        UiItemTonic Item = Instantiate(UiItemTonicPage.Instance.itemTonic, Vector3.zero, Quaternion.identity, UiItemTonicPage.Instance.transform);
        //        UiMpPlayer.Instance.TextTime = Item.Txt;
        //        UiMpPlayer.Instance.itemTonic = Item;
        //        UiItemTonicPage.Instance.inventoryUiItems.Add(UiMpPlayer.Instance.itemTonic);
               
        //    }
        //    UiMpPlayer.Instance.time += val;
        //    MPController.Instance.ItemMP();
        //}else if ()
        //{

        }
        
    }
     

public enum TypeBuff { HP,MP,Dmg,Def,Exp}
