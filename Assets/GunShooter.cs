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

    public void OnHand(InputAction.CallbackContext context)
    {

        Debug.Log("waza hand");
    }
    public void OnMove(InputAction.CallbackContext context)
    {

        Debug.Log("waza joystick");
    }
    public void OnPrimary(InputAction.CallbackContext context)
    {

        Debug.Log("waza primary");
    }
    public void OnSecundary(InputAction.CallbackContext context)
    {

        Debug.Log("waza secondary");
    }
    public void OnMenu(InputAction.CallbackContext context)
    {

        Debug.Log("waza secondary");
    }
}