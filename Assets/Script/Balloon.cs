using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int hp = 1;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            // ค้นหา BalloonSpawner และแจ้งว่าลูกโป่งถูกทำลาย
            BalloonSpawner spawner = FindObjectOfType<BalloonSpawner>();
            if (spawner != null)
            {
                spawner.BalloonDestroyed();
            }

            Destroy(this.gameObject);
        }
    }
}


