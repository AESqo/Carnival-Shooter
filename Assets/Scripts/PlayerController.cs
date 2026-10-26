using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Transform firePoint;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;
    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }
    public void OnFire(InputValue value) {
        if (value.isPressed) {
            Shoot();
        }
    }
    private void Update() {
        transform.Translate(Vector3.right * moveInput.x * moveSpeed * Time.deltaTime);
    }
    private void Shoot() {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
    }
}
