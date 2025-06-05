using UnityEngine;
using UnityEngine.InputSystem;

public class GunShooter : MonoBehaviour
{
    [Header("Disparo")]
    //public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 20f;
    private Vector2 moveInput;
    public float moveSpeed = 2f;
    [SerializeField] GameObject test;
    public Transform vrCamera;

    //LayerMask layerMask = LayerMask.GetMask("floor");
    int raydistance = 3;
    private void Start()
    {
        Debug.Log("a");
    }
    private void Update()
    {
        /*Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

        // Movemos el objeto en la dirección deseada (opcionalmente relativa al headset/cámara)
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);*/
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);


        Vector3 relativeDirection = vrCamera.TransformDirection(direction);
    relativeDirection.y = 0; // Evita que se mueva hacia arriba/abajo
    transform.position += relativeDirection * moveSpeed * Time.deltaTime;
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
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"waza joystick: {moveInput}");
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
    void FixedUpdate()
    {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raydistance, 3))

        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20, Color.white);
            Debug.Log("Did not Hit");
        }

    }
}