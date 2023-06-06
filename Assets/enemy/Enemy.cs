using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    LevelSystem playerLevel;
    private float timer;
    private float shootInterval;


    public int enemyLevel;
    public float enemyXp;
    public float XpMultiplier;
    public int numberOfHits = 3;
    public TextMeshProUGUI text;
    public GameObject explosion;
    public GameObject spriteGO;
    public GameObject bullet;
    private AudioSource source;
    public AudioClip shootSound;
    public AudioClip DeathSound;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = player.GetComponent<LevelSystem>();
        enemyLevel = Random.Range(1, playerLevel.level + 2);

        //Scale Enemy XP ----- don't use this if you want to set enemy levels manually.
        enemyXp = Mathf.Round(enemyLevel * 6 * XpMultiplier);
       
        text.text = "<color=red>Level: " + enemyLevel + "</color> \n XP: " + enemyXp;

       //Set Text Colour to Orange
        if (enemyLevel == playerLevel.level) 
            text.text = "<color=orange>Level: " + enemyLevel + "</color> \n XP: " + enemyXp;
        
            //This if statement is just used to update the Example UI to reflect the
            //multiplier in the PlayerLevel Class.
        if (enemyLevel < playerLevel.level)
        {
            float multiplier = 1 + (playerLevel.level - enemyLevel) * 0.1f;
              //Set Text Colour to green/
            text.text = "<color=green>Level: " + enemyLevel + "</color> \n XP: " + Mathf.Round(enemyXp * multiplier);
        }
        //
      //  spriteGO.GetComponent<SpriteRenderer>().color = Color.green;
        shootInterval = 4 + Random.Range(1, 7);
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position,1f);
        Vector3 playerPos = player.transform.position;
        playerPos.x = playerPos.x - transform.position.x;
        playerPos.y = playerPos.y - transform.position.y;

        float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
       spriteGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        timer += Time.deltaTime;

        if (timer >shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }
    public void TakeDamage()
    {
            //numberOfHits--;
            //switch (numberOfHits)
            //{
            //    case 2:
            //        spriteGO.GetComponent<SpriteRenderer>().color = new Color(255,165,0);
            //        break;
            //    case 1:
            //        spriteGO.GetComponent<SpriteRenderer>().color = Color.red;
            //        break;
            //}
            //if (numberOfHits <= 0) 
            //{
                OnDead();
           // }        
    }
    private void Shoot() 
    {
        GameObject clone = Instantiate(bullet, transform.position, spriteGO.transform.rotation);
        source.PlayOneShot(shootSound);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            collision.transform.GetComponent<HPController>().TakeDamage(20);
            OnDead();
        }
    }

    public void OnDead() 
    {
        GameObject clone = Instantiate(explosion, transform.position, spriteGO.transform.rotation);
        spriteGO.SetActive(false);
        GetComponent<CircleCollider2D>().enabled = false;
        //GetComponent<Rigidbody2D>().simulated = false;
        playerLevel.GainExperienceScalable(enemyXp, enemyLevel);
        source.PlayOneShot(DeathSound);
        Destroy(gameObject,DeathSound.length);
    }
    
}
