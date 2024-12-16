using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    public GameObject speedBoostObject;
    public GameObject immunityObject;
    public GameObject extraLifeObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && speedBoostObject.activeSelf)
        {
            speedBoostObject.GetComponent<IPowerUp>().Activate();
            speedBoostObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && immunityObject.activeSelf)
        {
            immunityObject.GetComponent<IPowerUp>().Activate();
            immunityObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R) && extraLifeObject.activeSelf)
        {
            extraLifeObject.GetComponent<IPowerUp>().Activate();
            extraLifeObject.SetActive(false);
        }
    }
}
