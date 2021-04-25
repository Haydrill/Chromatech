using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem deathExplosion;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0 && tag != "Player")
        {
            StartCoroutine(Wait());
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator Wait()
    {
        deathExplosion.Play();
        yield return new WaitForSeconds(0.5f);
        Die();
    }
}
