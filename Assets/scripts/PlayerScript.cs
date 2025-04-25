using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.InputSystem.InputAction;

public class PlayerScript : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 input;
    private float Speed = 5f;
    private float timer = 0.5f;
    private float delayShoot = 0.5f;
    [SerializeField] private GameObject BalaPrefab;
    [SerializeField] private GameObject Spawn1;
    [SerializeField] private GameObject Spawn2;
    private bool isShooting = false;
    private int vida = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (isShooting && timer > delayShoot)
        {
            Instantiate(BalaPrefab, Spawn1.transform.position, Quaternion.identity);
            Instantiate(BalaPrefab, Spawn2.transform.position, Quaternion.identity);
            print("shooted xd");
            timer = 0;
        }
        input = playerInput.actions["move"].ReadValue<Vector2>();
        movement(input);
    }

    public void movement(Vector2 input)
    {
        float SpeedX = input.x * Speed;
        float SpeedY = input.y * Speed;
        Vector3 movimiento = new Vector3(SpeedX, SpeedY, 0) * Time.deltaTime;
        transform.position += movimiento;
        float XCLamped = Mathf.Clamp(transform.position.x, -8.26f,8.26f);
        float YCLamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(XCLamped, YCLamped, 0);
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isShooting = true;
        }
        else if (context.canceled)
        {
            isShooting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShoot") || collision.CompareTag("Enemy"))
        {
            vida -= 20;
            Destroy(collision);
            if(vida <= 0)
            {
                print("muelto");
                Destroy(this.gameObject);
            }
        }
    }
}
