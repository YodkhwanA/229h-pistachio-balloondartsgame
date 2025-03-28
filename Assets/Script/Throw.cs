using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{
    public float force = 0f;
    public int chargeCount = 0;

    public Transform shootPoint;

    public float chargeSpeed = 25f;
    private bool isChargingUp = true;
    public GameObject ammoPrefab;
    public ChargeSlider chargeSlider;
    public AudioClip throwSfx;
    public AudioSource PlayerAudio;

    public LineRenderer trajectoryLine;

    void Start()
    {
        if (trajectoryLine == null)
        {

            trajectoryLine = GetComponent<LineRenderer>();

        }
        trajectoryLine.startWidth = 0.02f;
        trajectoryLine.endWidth = 0.02f;
        if (chargeSlider != null)
        {
            chargeSlider.SetSliderValue(force);
        }

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
            if (chargeSlider != null)
            {
                chargeSlider.SetSliderValue(force);
            }


            if (chargeCount > 0)
            {
                ShowTrajectory(force);
            }
        }
        // เมื่อปล่อยคลิกขวา
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (chargeCount > 0)
            {
                shoot();
            }

            force = 0f;
            isChargingUp = true;


            trajectoryLine.positionCount = 0;
            if (chargeSlider != null)
            {
                chargeSlider.SetSliderValue(force);
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
                    ammoRb.useGravity = true;
                    ammoRb.AddForce(shootPoint.forward * force, ForceMode.Impulse);
                }
                PlayerAudio.PlayOneShot(throwSfx);
                chargeCount--;
            }
        }

        void ShowTrajectory(float force)
        {
            Vector3 startPosition = shootPoint.position;
            Vector3 startVelocity = shootPoint.forward * force;

            int numPoints = 30;
            float timeStep = 0.1f;

            Vector3[] points = new Vector3[numPoints];
            for (int i = 0; i < numPoints; i++)
            {
                float time = i * timeStep;
                Vector3 displacement = startVelocity * time + 0.5f * Physics.gravity * time * time;
                points[i] = startPosition + displacement;
            }


            trajectoryLine.positionCount = numPoints;
            trajectoryLine.SetPositions(points);
        }
    }
}
