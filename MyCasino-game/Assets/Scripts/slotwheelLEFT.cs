using UnityEngine;
using System.Collections;

public class slotwheelLEFT : MonoBehaviour
{
    private int rotation;
    public slot_machinecounting machine;
    private bool isSpinning = false;



    // Update is called once per frame
    void Update()
    {
        if (machine.rotationstartleft && !isSpinning)
        {
            isSpinning = true;
            machine.rotationstartleft = false;
            StartCoroutine(drehung());
        }
    }
    private IEnumerator drehung()
    {
        float angle = -45f;
        if (rotation != 0)
        {
            while (rotation != 8)
            {
                Quaternion startRotation = transform.rotation;
                Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, angle );

                float elapsed = 0f;
                float duration = 0.1f;

                while (elapsed < duration)
                {
                    transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
                    elapsed += Time.deltaTime;
                    yield return null;
                }

                transform.rotation = endRotation;
                yield return new WaitForSeconds(0.01f); // kleine Pause zwischen Schritten
                rotation += 1;
            }
            rotation = 0;
        }
        rotation += machine.slotwheelLeft + 24;
        for (int i = 0; i < rotation; i++)
        {
            // um 45 Grad drehen
            
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, angle);

            float elapsed = 0f;
            float duration = 0.1f;

            while (elapsed < duration)
            {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.rotation = endRotation;
            yield return new WaitForSeconds(0.05f); // kleine Pause zwischen Schritten
        }
        rotation -= 24;
        isSpinning = false;
        machine.rotationstartleft = false;
    }
}
