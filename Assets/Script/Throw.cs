using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{
    public float speed;
    public float cdTime;
    public float mass;
    public float force = 0f;
    
    public float chargeSpeed = 1f;
    //private bool onClick = false;


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
           
            if (Input.GetKey(KeyCode.Mouse1))  
                if (isChargingUp)  
                {
                    force += chargeSpeed * Time.deltaTime;  

                    
                    if (force >= 100f)
                    {
                        force = 100f;
                        isChargingUp = false; 
                    }
                }
                else  
                {
                    force -= chargeSpeed * Time.deltaTime;  

                    
                    if (force <= 0f)
                    {
                        force = 0f;
                        isChargingUp = true;  
                    }
                }

               
                Debug.Log("Force: " + force);
            }
            else
            {
                
                Debug.Log("Force (เมื่อปล่อยปุ่ม): " + force);







            }
            void shoot()
            {
                Debug.Log(force);
            }
        }
}
