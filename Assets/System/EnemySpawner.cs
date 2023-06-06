using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timeInBetweenWaves = 10;
    private float timer;
    public GameObject enemyPrefab;
    public float numToSpawn;

    private void Start()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            float angle = Random.Range(0, Mathf.PI * 2);
            Vector2 pos2d = new Vector2(Mathf.Sin(angle) * 1000, Mathf.Cos(angle) * 1000);
            Instantiate(enemyPrefab, new Vector3(pos2d.x, pos2d.y, 0), Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeInBetweenWaves) 
        {
            for (int i = 0; i < numToSpawn; i++)
            {
                float angle = Random.Range(0, Mathf.PI * 2);
                Vector2 pos2d = new Vector2(Mathf.Sin(angle) * 1000, Mathf.Cos(angle) * 1000);
                Instantiate(enemyPrefab, new Vector3(pos2d.x, pos2d.y, 0), Quaternion.identity);
            }
            timer = 0;
        }
    }
}
