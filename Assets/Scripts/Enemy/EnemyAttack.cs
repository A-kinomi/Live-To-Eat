using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject energyBar;
    EnergyBar energyBarScript;

    [SerializeField] float damage = 50f;
    bool isPlayerDamaged = false;

    void Start()
    {
        energyBarScript = energyBar.GetComponent<EnergyBar>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isPlayerDamaged)
        {
            isPlayerDamaged = true;
            energyBarScript.currentEnergy = energyBarScript.currentEnergy - damage;
            StartCoroutine(PreventFromDamage());
        }
    }

    IEnumerator PreventFromDamage()
    {
        yield return new WaitForSeconds(0.5f); //change the time if neccesary
        isPlayerDamaged = false;
    }
}
