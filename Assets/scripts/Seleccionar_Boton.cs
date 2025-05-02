using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Seleccionar_Boton : MonoBehaviour
{
    [SerializeField] private GameObject botonPorDefecto;
    [SerializeField] private GameObject InterfazControl;
    [SerializeField] private GameObject InterfazTeclado;
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(botonPorDefecto);
        if(PlayerPrefs.GetString("UI") == "Control" && InterfazControl != null)
        {
            InterfazControl.SetActive(true);
            InterfazTeclado.SetActive(false);
        }
        else if (PlayerPrefs.GetString("UI") == "Teclado" && InterfazTeclado != null)
        {
            InterfazTeclado.SetActive(true);
            InterfazControl.SetActive(false);
        }
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(botonPorDefecto);
        }
    }

    public void GuardarUI(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            var dispositivo = context.control.device;

            if (dispositivo is Gamepad)
            {
                InterfazControl.SetActive(true);
                InterfazTeclado.SetActive(false);
                PlayerPrefs.SetString("UI", "Control");
            }
            else if (dispositivo is Keyboard)
            {
                InterfazControl.SetActive(false);
                InterfazTeclado.SetActive(true);
                PlayerPrefs.SetString("UI", "Teclado");
            }
            
        }
    }

}
