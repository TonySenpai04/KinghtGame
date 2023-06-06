using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 _velocity;
    public EnemyBullet(float x, float y) 
    {
        _velocity.x = x;
        _velocity.y = y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.right * 10);
        Destroy(this.gameObject, 4f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<HPController>().TakeDamage(10);
            Destroy(gameObject);
        }
        
    }
}