using UnityEngine;

public class TargetSpawner : MonoBehaviour {
    [SerializeField] private GameObject baseTargetPrefab;
    [SerializeField] private Transform spawnPoint;
    public GameObject ConstructFastSmallTarget() {
        return new TargetBuilder(baseTargetPrefab, spawnPoint.position)
            .SetSpeed(8f)
            .SetPoints(50)
            .SetScale(new Vector3(1.5f, 1.5f, 1f))
            .SetColor(Color.red)
            .Build();
    }
    public GameObject ConstructSlowLargeTarget() {
        return new TargetBuilder(baseTargetPrefab, spawnPoint.position)
            .SetSpeed(3f)
            .SetPoints(10)
            .SetScale(new Vector3(2.5f, 2.5f, 1f))
            .SetColor(Color.green)
            .Build();
    }
}
