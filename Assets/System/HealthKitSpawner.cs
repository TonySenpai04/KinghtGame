using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKitSpawner : MonoBehaviour
{
    public GameObject healthKitPrefab;
    private float timer;
    // Start is called before the first frame update

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 11)
        {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(healthKitPrefab, spawnPosition, Quaternion.identity);
            timer = 0;
        }
    }
}
