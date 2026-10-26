using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 10f;
    private float lifetime = 1f;
    private float timer;
    private void OnEnable() {
        timer = lifetime;
    }
    private void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0) {
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Target")) {
            Target target = collision.GetComponent<Target>();
            if (target != null) {
                target.TakeDamage();
            }
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
}
