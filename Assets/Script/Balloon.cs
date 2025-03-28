using NUnit.Framework;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int hp = 1;
    public AudioClip popSfx;
    public AudioSource BalloonAudio;

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
            BalloonAudio.PlayOneShot(popSfx);
            Destroy(gameObject, popSfx.length);

        }

    }
}


