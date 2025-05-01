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

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(botonPorDefecto);
        }
        Activau();
    }

    public void Activau()
    {
        var gamepad = Gamepad.current;
        var keyboard = Keyboard.current;

        if ((gamepad != null && gamepad.leftStick.ReadValue() != Vector2.zero))
        {
            if( InterfazControl != null && InterfazTeclado != null)
            {
                InterfazControl.SetActive(true);
                InterfazTeclado.SetActive(false);
            }
            
            PlayerPrefs.SetString("UI", "Control");

        }
        if (keyboard != null && (
            keyboard.upArrowKey.isPressed ||
            keyboard.downArrowKey.isPressed ||
            keyboard.leftArrowKey.isPressed ||
            keyboard.rightArrowKey.isPressed ||
            keyboard.wKey.isPressed ||
            keyboard.aKey.isPressed ||
            keyboard.sKey.isPressed ||
            keyboard.dKey.isPressed))
        {
            if (InterfazControl != null && InterfazTeclado != null)
            {
                InterfazControl.SetActive(false);
                InterfazTeclado.SetActive(true);
            }
            
            PlayerPrefs.SetString("UI", "Teclado");
        }

    }
}
