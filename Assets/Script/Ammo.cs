using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int attackP = 1;
    void OnTriggerEnter(Collider other)
    {
        var health = other.gameObject.GetComponent<Balloon>();
        if (health != null)
            health.TakeDamage(attackP);
        Destroy(gameObject);
    }
}
