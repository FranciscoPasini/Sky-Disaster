using UnityEngine;

public class Immunity : MonoBehaviour, IPowerUp
{
    public void Activate()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.ActivateImmunity(5f);
        }
    }
}