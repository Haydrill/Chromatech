using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem deathExplosion;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            if (this.tag != "Player")
            {
                StartCoroutine(Wait());
            }
            else
            {
                PlayerDie();
            }
        }
        
    }

    void EnemyDie()
    {
        Destroy(gameObject);
    }

    void PlayerDie()
    {
        FindObjectOfType<EndGameMgr>().Died();
    }

    IEnumerator Wait()
    {
        if(deathExplosion != null)
        {
            deathExplosion.Play();
            yield return new WaitForSeconds(0.5f);
        }
        
        EnemyDie();
    }
}
