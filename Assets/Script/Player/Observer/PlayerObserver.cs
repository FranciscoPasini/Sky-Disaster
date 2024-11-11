using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    PlayerManagment playerManagment;
    [SerializeField] private GameObject speedBoostObject;
    [SerializeField] private GameObject immunityObject;
    [SerializeField] private GameObject extraLifeObject;

    private void Awake()
    {
        playerManagment = GetComponent<PlayerManagment>();
    }

    void Start()
    {
        PlayerHealth.OnGetDamage += playerManagment.RespawnTime;
        PlayerHealth.OnDead += OnLose;

        PlayerActions.OnWin += OnWin;
        PlayerActions.OnRescue += AllieRescue;
    }

    void OnDisable()
    {
        PlayerHealth.OnGetDamage -= playerManagment.RespawnTime;
        PlayerHealth.OnDead -= OnLose;

        PlayerActions.OnWin -= OnWin;
        PlayerActions.OnRescue -= AllieRescue;
    }

    private void OnLose()
    {
        GameManager.instance.Lose();
        StopAllCoroutines();

        Destroy(gameObject);
    }

    private void OnWin()
    {
        GameManager.instance.Win();
        StopAllCoroutines();
    }

    private void AllieRescue()
    {
        playerManagment.AllieSaved();
    }

    // Método para resetear los power-ups cuando el jugador pase por el observador
    public void ResetPowerUps()
    {
        if (speedBoostObject != null) speedBoostObject.SetActive(true);
        if (immunityObject != null) immunityObject.SetActive(true);
        if (extraLifeObject != null) extraLifeObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ResetPowerUps(); // Llama al método para resetear los power-ups
        }
    }
}
