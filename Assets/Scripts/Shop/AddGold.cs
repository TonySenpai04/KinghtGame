using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGold : MonoBehaviour
{
    public GameObject FloatingText;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
             HpEnemy.hp.Enemy.GoldDrop=Random.Range(HpEnemy.hp.Enemy.MinGoldDrop, HpEnemy.hp.Enemy.MaxGoldDrop);
            Gold_Diamond.instance.Gold += HpEnemy.hp.Enemy.GoldDrop;
                
            ShowGold();
            Destroy(gameObject,1f);
        }      
    }
    void ShowGold()
    {
        var TextGold = Instantiate(FloatingText, transform.position, Quaternion.identity,transform);
        TextGold.GetComponent<TextMesh>().text ="+"+ HpEnemy.hp.Enemy.GoldDrop;
    }
    
   
}
