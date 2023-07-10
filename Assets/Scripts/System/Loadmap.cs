using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadmap : MonoBehaviour
{
    public static Loadmap instance;
    [SerializeField] protected Transform targetdoor;
    protected Transform player;
    public int requiredLevel;
    public bool isLoad;
    [SerializeField] private GameObject PanelRequiredLevel;
    public TextMeshProUGUI TxtRequiredLevel;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        isLoad = false;
        player = GameObject.Find("player").transform;
    }
    private void Update()
    {
            player = GameObject.Find("player").transform;
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") )
        {
            
                isLoad = true;
            if (player.GetComponent<LevelSystem>().level >= requiredLevel)
            {
                player.transform.position = new Vector2(targetdoor.transform.position.x, targetdoor.transform.position.y);
                Vector3 pos = CameraFollowPlayer.instance.transform.position;
                if (player.transform.position.x < 0)
                {
                    pos.x = -2.7f;
                    pos.y = player.position.y;
                    CameraFollowPlayer.instance.transform.position = pos;
                }
                else
                {
                    pos.x = 51f;
                    pos.y = player.position.y;
                    CameraFollowPlayer.instance.transform.position = pos;
                }
            }
            else
            {
                
                    ShowPanel(Color.black, "Need Level " + requiredLevel + " To Pass The Map");
                
            }
        }
       
        
    }
    IEnumerator SetEnabled()
    {
        yield return new WaitForSeconds(3);
        PanelRequiredLevel.gameObject.SetActive(false);
    }
    void ShowPanel(Color color, string Text)
    {
        TxtRequiredLevel.text = Text;
        TxtRequiredLevel.color = color;
        PanelRequiredLevel.gameObject.SetActive(true);
        StartCoroutine(SetEnabled());
    }

}
