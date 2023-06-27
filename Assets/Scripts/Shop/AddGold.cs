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
             HpEnemy.Instance.Enemy.GoldDrop=Random.Range(HpEnemy.Instance.Enemy.MinGoldDrop, HpEnemy.Instance.Enemy.MaxGoldDrop);
            Gold_Diamond.instance.Gold += HpEnemy.Instance.Enemy.GoldDrop;
                
            ShowGold();
            Destroy(gameObject,1f);
        }      
    }
    void ShowGold()
    {
        var TextGold = Instantiate(FloatingText, transform.position, Quaternion.identity,transform);
        TextGold.GetComponent<TextMesh>().text ="+"+ HpEnemy.Instance.Enemy.GoldDrop;
    }
    
   
}
