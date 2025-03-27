using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int hp = 1;
    
    public void TakeDamage(int damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

   
}
