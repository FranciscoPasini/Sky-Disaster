using UnityEngine;
using System;

public class PlayerActions : MonoBehaviour
{
    public static event Action OnWin;
    public static event Action OnRescue;

    // Referencias a los objetos de cada power-up
    [SerializeField] private GameObject speedBoostObject;
    [SerializeField] private GameObject immunityObject;
    [SerializeField] private GameObject extraLifeObject;

    private PlayerManagment playerManagment;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerManagment = gameObject.GetComponent<PlayerManagment>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        // Power-up de velocidad activado con la tecla "V"
        if (Input.GetKeyDown(KeyCode.V) && speedBoostObject.activeSelf)
        {
            playerManagment.ActivateSpeedBoost();
            speedBoostObject.SetActive(false); // Desactiva el objeto de velocidad
        }

        // Power-up de inmunidad activado con la tecla "R"
        if (Input.GetKeyDown(KeyCode.R) && immunityObject.activeSelf)
        {
            playerHealth.ActivateImmunity(5f); // Inmunidad por 5 segundos
            immunityObject.SetActive(false); // Desactiva el objeto de inmunidad
        }

        // Power-up de vida extra activado con la tecla "P"
        if (Input.GetKeyDown(KeyCode.P) && extraLifeObject.activeSelf)
        {
            playerHealth.ExtraLife();
            extraLifeObject.SetActive(false); // Desactiva el objeto de vida extra
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractuable interactuable = collision.GetComponent<IInteractuable>();

        if (interactuable != null)
        {
            interactuable.Interact();

            if (interactuable is IWinInteractable)
            {
                OnWin?.Invoke();
                playerManagment.LevelCompleted();
            }
            else if (interactuable is IDamageInteractable)
            {
                playerHealth.GetDamage();
            }
        }
    }

    public static void TriggerRescue()
    {
        OnRescue?.Invoke();
    }
}
