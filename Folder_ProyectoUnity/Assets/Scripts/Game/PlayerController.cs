using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    //Componentes
    private Rigidbody _compRigidbody;
    [Header("Referencias")]
    [SerializeField] private PlayerInventory inventory;
    [Header("Control de la camara")]
    private Vector2 directionXZ;
    private float directionY;
    [SerializeField] float speed;
    [SerializeField] private RobotCard current;
    public PlayerInventory Inventory
    {
        get
        {
            return inventory;
        }
        set
        {
            inventory = value;
        }
    }
    public RobotCard Current
    {
        get
        {
            return current;
        }
        set
        {
            current = value;
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        _compRigidbody = GetComponent<Rigidbody>();
    }
    public void GetDirectionXZ(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        directionXZ = new Vector2(direction.x * speed, direction.y * speed);
    }
    public void GetDirectionY(InputAction.CallbackContext context)
    {
        float direction = context.ReadValue<float>();
        directionY = direction * speed;
    }
    private void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector3(directionXZ.x, directionY, directionXZ.y);
    }
}
