using System.Collections;
using UnityEngine;

public class PlayerManagment : MonoBehaviour
{
    public int AlliesRescues { get => alliesRescues; set => alliesRescues = value; }
    public bool CanDie { get => canDie; set => canDie = value; }

    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private float speedBoostMultiplier = 2f;

    private int alliesRescues;
    private int levelcompleted = 0;
    private bool canDie;
    private Animator animator;
    private Movement movement; // Referencia al script de movimiento
    private PlayerActions playerActions;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        movement = gameObject.GetComponent<Movement>();
        playerActions = gameObject.GetComponent<PlayerActions>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    void Start()
    {
        alliesRescues = 0;
        CanDie = true;
    }

    public void AllieSaved()
    {
        alliesRescues++;
    }

    public void LevelCompleted()
    {
        levelcompleted++;
    }

    // Espera 2 segundos luego puede morir y ya no estara muerto(Tiempo de Respawn)
    public void RespawnTime()
    {
        StartCoroutine(WaitForPlayerRespawn());
        transform.position = spawnPosition;
    }

    private IEnumerator WaitForPlayerRespawn()
    {
        CanDie = false;
        animator.SetBool("Dead", true);

        yield return new WaitForSeconds(2);

        CanDie = true;
        animator.SetBool("Dead", false);
    }
}
