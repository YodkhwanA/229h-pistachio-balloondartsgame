using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int hp = 1;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            BalloonSpawner spawner = FindObjectOfType<BalloonSpawner>();
            if (spawner != null)
            {
                spawner.BalloonDestroyed();
            }

            Destroy(this.gameObject);
        }
    }
}


