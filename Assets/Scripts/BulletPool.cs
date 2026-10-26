using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {
    public static BulletPool Instance { get; private set; }
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 10;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        InitializePool();
    }
    private void InitializePool() {
        for (int i = 0; i < poolSize; i++) {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }
    public GameObject GetBullet() {
        if (pool.Count > 0) {
            GameObject bullet = pool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        GameObject newBullet = Instantiate(bulletPrefab, transform);
        return newBullet;
    }
    public void ReturnBullet(GameObject bullet) {
        bullet.SetActive(false);
        bullet.transform.SetParent(transform);
        pool.Enqueue(bullet);
    }
}
