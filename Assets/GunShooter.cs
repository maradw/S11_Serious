using UnityEngine;
using UnityEngine.InputSystem;

public class GunShooter : MonoBehaviour
{
    [Header("Disparo")]
    //public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 20f;

    private void Start()
    {
        Debug.Log("a");
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        /*GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
         Rigidbody rb = bullet.GetComponent<Rigidbody>();
         rb.linearVelocity = spawnPoint.forward * bulletSpeed;*/
        Debug.Log("waza trigger");
    }
}