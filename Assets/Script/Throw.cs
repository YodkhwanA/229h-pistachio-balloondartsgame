using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{
    public float speed;
    public float cdTime;
    public float mass;
    public float force = 0f;

    
    private bool isChargingUp = true;



    void Start()
    {

    }
    void Update()
    {
        Charging();
    }
    void Charging()

    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (isChargingUp )
            {
                force = Mathf.Min(force + 5f * Time.deltaTime, 100);

                if (force >= 100)
                {
                
                    isChargingUp = false;
                }
                else
                    force = Mathf.Max(force - 5f * Time.deltaTime, 0);
                if (force <= 0)
                {
                    
                    isChargingUp = true;
                }
                 if (!isChargingUp)
                {
                    shoot();
                }

                Debug.Log("¡´»ØèÁ¤éÒ§ÍÂÙè!");
            }
           



        }//isCharge = true;
         //force++;
         //if (!isCharge && force >= 100)
         //{
         //    force--;
         //    if (force == 0)
         //    {
         //        return;
         //    }
         //}
         void shoot()
        {
            Debug.Log(force);
        }
    }
}
