
using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f;
    public TextMeshProUGUI countdownText;

    private bool isCounting = false;

    void Start()
    {
        if (countdownText != null)
        {
            StartCoroutine(StartCountdown());
        }


        IEnumerator StartCountdown()
        {
            isCounting = true;

            while (countdownTime > 0)
            {
                countdownText.text = "Time: " + countdownTime.ToString("0");
                yield return new WaitForSeconds(1f);
                countdownTime--;
            }

            countdownText.text = "Time: 0";
            isCounting = false;


        }
    }
}
