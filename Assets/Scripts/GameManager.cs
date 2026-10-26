using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private TargetSpawner targetSpawner;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float minYPosition = -2f;
    [SerializeField] private float maxYPosition = 4f;
    private float spawnTimer;
    private void Update() {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval) {
            SpawnRandomTarget();
            spawnTimer = 0f;
        }
    }
    private void SpawnRandomTarget() {
        if (targetSpawner == null) return;
        GameObject target;
        if (Random.value > 0.5f) {
            target = targetSpawner.ConstructFastSmallTarget();
        }
        else {
            target = targetSpawner.ConstructSlowLargeTarget();
        }
        float randomY = Random.Range(minYPosition, maxYPosition);
        target.transform.position = new Vector3(target.transform.position.x, randomY, target.transform.position.z);
    }
}
