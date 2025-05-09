using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static UnityEngine.InputSystem.InputAction;

public class PlayerScript : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 input;
    private float Speed = 5f;
    private float timer = 0.5f;
    private float delayShoot = 0.25f;
    [SerializeField] private GameObject BalaPrefab;
    [SerializeField] private GameObject Spawn1;
    [SerializeField] private GameObject Spawn2;
    [SerializeField] private GameObject panelMuerte;
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private TextMeshProUGUI scoreText;
    private bool isShooting = false;
    private int vida = 100;
    public UnityEngine.UI.Image VidaUI;
    [SerializeField] private Sprite Barra100;
    [SerializeField] private Sprite Barra80;
    [SerializeField] private Sprite Barra60;
    [SerializeField] private Sprite Barra40;
    [SerializeField] private Sprite Barra20;
    [SerializeField] private Sprite Barra0;
    private bool power = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        playerInput = GetComponent<PlayerInput>();
        ActualizarVida();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        if (isShooting && timer > delayShoot)
        {
            GameObject bala1 =  Instantiate(BalaPrefab, Spawn1.transform.position, Quaternion.identity);
            GameObject bala2 = Instantiate(BalaPrefab, Spawn2.transform.position, Quaternion.identity);
            LABALAScript bala1S = bala1.GetComponent<LABALAScript>();
            LABALAScript bala2S = bala2.GetComponent<LABALAScript>();
            if (power)
            {
                bala1S.SpeedUp(); bala2S.SpeedUp();
            }
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

    public void ActualizarVida()
    {
        switch (vida)
        {
            case 0:
                VidaUI.sprite = Barra0;
                break;
            case 20:
                VidaUI.sprite = Barra20;
                break;
            case 40:
                VidaUI.sprite = Barra40;
                break;
            case 60:
                VidaUI.sprite = Barra60;
                break;
            case 80:
                VidaUI.sprite = Barra80;
                break;
            case 100:
                VidaUI.sprite = Barra100;
                break;
            default:
                VidaUI.sprite = Barra0;
                break;

        }
        
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

    public void PauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Pausa();
        }
    }

    public void Pausa()
    {
        if (panelPausa.activeSelf == false)
        {
            Time.timeScale = 0;
            panelPausa.SetActive(true);
        }
        else if (panelPausa.activeSelf == true)
        {
            Time.timeScale = 1;
            panelPausa.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShoot") || collision.CompareTag("Enemy"))
        {
            vida -= 20;
            ActualizarVida();
            Destroy(collision.gameObject);
            if(vida <= 0)
            {
                print("muelto");
                panelMuerte.SetActive(true);
                Destroy(this.gameObject);
            }
        }
        if (collision.CompareTag("PowerUp"))
        {
            StartCoroutine(PowerUp());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator PowerUp()
    {
        delayShoot = delayShoot / 2;
        power = true;
        yield return new WaitForSeconds(8f);
        delayShoot = delayShoot * 2;
        power = false;
    }
}
