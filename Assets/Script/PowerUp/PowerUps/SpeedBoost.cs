using UnityEngine;

public class SpeedBoost : MonoBehaviour, IPowerUp
{
    public float speedMultiplier = 3f;
    public float boostDuration = 5f;

    public void Activate()
    {
        Movement movement = FindObjectOfType<Movement>();
        if (movement != null)
        {
            movement.BoostSpeed(speedMultiplier, boostDuration);
        }
    }
}