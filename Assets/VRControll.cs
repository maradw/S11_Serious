using UnityEngine;
using UnityEngine.InputSystem;

public class VRControll : MonoBehaviour
{
    [Header("Disparo")]
    //public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 20f;
    private Vector2 moveInput;
    public float moveSpeed = 2f;
    //[SerializeField] GameObject test;
    [SerializeField] GameObject currentObject;

    //LayerMask layerMask = LayerMask.GetMask("floor");
    int raydistance = 3;



    public Transform vrCamera; // La cámara VR principal (usualmente CenterEyeAnchor o MainCamera)

    bool inHand;

    //public Transform environment;

    private void Update()
    {

        Vector3 forward = vrCamera.forward;
        forward.y = 0f; // Evitamos que mire hacia arriba o abajo
        forward.Normalize();

        Vector3 right = vrCamera.right;
        right.y = 0f;
        right.Normalize();

        // Dirección de movimiento basada en la entrada y en la cámara
        Vector3 direction = forward * moveInput.y + right * moveInput.x;

        // Mover al jugador (el GameObject padre del XR Rig)
        transform.position += direction * moveSpeed * Time.deltaTime;
        // Dirección basada en la mirada
        /*Vector3 forward = vrCamera.forward;
        forward.y = 0; // Eliminamos inclinación vertical
        forward.Normalize();

        Vector3 right = vrCamera.right;
        right.y = 0;
        right.Normalize();

         Movimiento relativo a la dirección de la cámara
        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;*/

        /*Vector3 camEuler = vrCamera.rotation.eulerAngles;
        environment.rotation = Quaternion.Euler(0, -camEuler.y, 0);*/
    }
    private void Start()
    {
        Debug.Log("a");
    }
    /*
     private void Update()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

        // Movemos el objeto en la dirección deseada (opcionalmente relativa al headset/cámara)
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);
    Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);


    Vector3 relativeDirection = vrCamera.TransformDirection(direction);
    relativeDirection.y = 0; // Evita que se mueva hacia arriba/abajo
    transform.position += relativeDirection* moveSpeed * Time.deltaTime;
    }*/

    public void OnShoot(InputAction.CallbackContext context)
    {
        GameObject bullet = Instantiate(currentObject, spawnPoint.position, spawnPoint.rotation);
         Rigidbody rb = bullet.GetComponent<Rigidbody>();
         rb.linearVelocity = spawnPoint.forward * bulletSpeed;
        Debug.Log(" trigger");
    }

    public void OnHand(InputAction.CallbackContext context)
    {
        /*inHand = !inHand;
        if (context.performed && inHand == false)
        {
            currentObject.transform.SetParent(spawnPoint.transform);
            if (spawnPoint != null)
            {
                inHand = true;
            }
        }
        else
        {
            currentObject.transform.SetParent(null);
            currentObject = null;
            if (spawnPoint == null)
            {
                inHand = false;
            }
        }*/

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
            //Debug.Log("Did not Hit");
        }

    }
}