using UnityEngine;

public class Target : MonoBehaviour {
    public float Speed { get; set; }
    public int PointValue { get; set; }
    public Vector3 Size { get; set; }
    public void Initialize(float speed, int pointValue, Vector3 size, Color color) {
        this.Speed = speed;
        this.PointValue = pointValue;
        this.Size = size;
        
        transform.localScale = size;
        GetComponent<SpriteRenderer>().color = color;
    }
    private void Update() {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);       
        if (transform.position.x > 15f || transform.position.x < -15f) {
            Destroy(gameObject);
        }
    }
    public void TakeDamage() {
        ScoreManager.Instance.NotifyTargetHit(PointValue);
        Destroy(gameObject);
    }
}
