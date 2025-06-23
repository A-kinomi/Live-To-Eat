using UnityEngine;
using System.Collections;

public class GetDamage : MonoBehaviour
{
    [SerializeField] int flashByDamage = 3;
    SpriteRenderer catSprite;

    private void Start()
    {
        //catSprite = GetComponent<SpriteRenderer>();
        //catSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(Flash());
        }
    }

    IEnumerator Flash()
    {
        catSprite = GetComponentInChildren<SpriteRenderer>();
        int flashNumber = flashByDamage;

        while (flashNumber > 0)
        {
            catSprite.material.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(0.1f);
            catSprite.material.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
            flashNumber--;
        }
    }
}
