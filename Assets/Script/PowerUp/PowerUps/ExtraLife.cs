using UnityEngine;

public class ExtraLife : MonoBehaviour, IPowerUp
{
    public void Activate()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddLife();
        }
    }
}
