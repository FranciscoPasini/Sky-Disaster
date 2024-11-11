using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnDead;
    public static event Action OnGetDamage;

    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 3;
    private bool isInvincible = false;
    private PlayerManagment playerManagment;

    public int Health { get => health; private set => health = value; }

    private void Awake()
    {
        playerManagment = GetComponent<PlayerManagment>();
    }

    public void GetDamage()
    {
        // Daño solo si no es invencible
        if (playerManagment.CanDie && !isInvincible)
        {
            OnGetDamage?.Invoke();
            health -= 1;
        }
    }

    // Activa la inmunidad por un tiempo determinado
    public void ActivateImmunity(float duration)
    {
        if (!playerManagment.ImmunityUsed)
        {
            StartCoroutine(Immunity(duration));
            playerManagment.ImmunityUsed = true;
        }
    }

    private IEnumerator Immunity(float duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }

    // Da una vida extra si no se ha usado el power-up y si la salud es menor al máximo
    public void ExtraLife()
    {
        if (!playerManagment.ExtraLifeUsed && health < maxHealth)
        {
            health += 1;
            playerManagment.ExtraLifeUsed = true;
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
