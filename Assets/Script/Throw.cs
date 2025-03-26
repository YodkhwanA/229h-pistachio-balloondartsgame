using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{
    public float speed;
    public float mass;
    public float force = 0f;
    public float newForce = 0f;
    public int chargeCount = 0;
    public Transform shootPoint;

    public float chargeSpeed = 1f;
    //private bool onClick = false;
    private bool isChargingUp = true;
    public GameObject ammoPrefab;



    void Start()
    {

    }
    void Update()
    {
       
        Charging();
        
    }
    void Charging()

    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            chargeCount++;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
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
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (chargeCount > 0)
            {
                newForce = force;
                shoot();
            
            }
            force = 0f;
            isChargingUp = true;
                Debug.Log("newforce" + newForce);

            }

        }
    void shoot()
    {
        if (chargeCount > 0)
        {
            GameObject ammo = Instantiate(ammoPrefab, shootPoint.position, transform.rotation);
            Rigidbody ammoRb = ammo.GetComponent<Rigidbody>();
            if (ammoRb != null)
            {

                ammoRb.AddForce(shootPoint.forward * newForce, ForceMode.Impulse);
            }
           chargeCount--;
        }
    }
}

