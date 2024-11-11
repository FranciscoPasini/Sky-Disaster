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
        if (Input.GetKeyDown(KeyCode.Q) && speedBoostObject.activeSelf)
        {
            playerManagment.ActivateSpeedBoost();
            speedBoostObject.SetActive(false); // Desactiva el objeto de velocidad
        }

        if (Input.GetKeyDown(KeyCode.E) && immunityObject.activeSelf)
        {
            playerHealth.ActivateImmunity(3f); // Inmunidad por 3 segundos
            immunityObject.SetActive(false); // Desactiva el objeto de inmunidad
        }

        if (Input.GetKeyDown(KeyCode.R) && extraLifeObject.activeSelf)
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
