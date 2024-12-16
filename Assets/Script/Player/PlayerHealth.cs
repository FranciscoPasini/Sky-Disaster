using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool CanReceiveDamage { get; set; } = true;
    public static event Action OnDead;
    public static event Action OnGetDamage;
    [SerializeField] private int health;
    PlayerManagment playerManagment;
    private bool isImmune = false;
    private int maxLife = 3;

    public int Health { get => health; private set => health = value; }
    private void Awake()
    {
        playerManagment = GetComponent<PlayerManagment>();
    }

    public void GetDamage()
    {
        if (playerManagment.CanDie && !isImmune)
        {
            health--;
            OnGetDamage?.Invoke();
            Debug.Log("Damage received. Health remaining: " + health);
        }
        else if (isImmune)
        {
            Debug.Log("Player is immune, no damage caused.");
        }
    }

    public void ActivateImmunity(float duration)
    {
        StartCoroutine(ImmunityRoutine(duration));
    }

    private IEnumerator ImmunityRoutine(float duration)
    {
        isImmune = true;
        yield return new WaitForSeconds(duration);
        isImmune = false;
    }

    public void AddLife(int extraLife = 1)
    {
        if (Health >= maxLife)
        {
            return;
        }
        Health += extraLife;
        Debug.Log($"Life added. Current health: {Health}");
    }

    private void Update()
    {
        if (health <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
