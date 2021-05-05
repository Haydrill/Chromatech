using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem deathExplosion;
    public AudioSource playerDamage;
    public HealthBar healthBar;

    private bool playerDied = false;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (this.tag == "Player" && !playerDied)
        {
            playerDamage.Play();
            healthBar.SetHealth((float)health / 100);
        }

        if (health <= 0)
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
        playerDied = true;
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
