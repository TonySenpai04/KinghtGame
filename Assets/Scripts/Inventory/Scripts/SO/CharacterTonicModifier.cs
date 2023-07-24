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
    public BuffType TypeBuff;
    public override void AffectCharacter(GameObject character, float val)
    {
        switch (TypeBuff)
        {
            case BuffType.HP:
                if (UiHpPlayer.Instance.IsUse == false)
                {
                    UiItemTonicPage.Instance.itemTonic.SetData(UiHpPlayer.Instance.IconItem);
                    UiItemTonic Item = Instantiate(UiItemTonicPage.Instance.itemTonic, Vector3.zero, Quaternion.identity, UiItemTonicPage.Instance.transform);
                    UiHpPlayer.Instance.TextTime = Item.Txt;
                    UiHpPlayer.Instance.itemTonic = Item;
                    UiItemTonicPage.Instance.inventoryUiItems.Add(Item);
                }
                UiHpPlayer.Instance.time += val;
                HPController.Instance.ItemHP();
                break;
            case BuffType.MP:
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
            case BuffType.Dmg:
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
            case BuffType.Def:
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
          case BuffType.Exp:
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

        }
        
    }
     

public enum BuffType { HP,MP,Dmg,Def,Exp}
