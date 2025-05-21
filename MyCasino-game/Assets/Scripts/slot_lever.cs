using UnityEngine;

public class slot_lever : MonoBehaviour
{
    public slot_machinecounting slotMachineScript;
    public player_movement player;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private bool isActivated = false;
    private bool isReturning = false;

    private float rotationSpeed = 200f; // Grad pro Sekunde
    private float delayBeforeReturn = 0.1f;
    private float returnTimer = 0f;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (isActivated && !isReturning)
        {
            // Drehe nach vorne (aktivieren)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
            {
                transform.rotation = targetRotation;
                isReturning = true;
                returnTimer = 0f;
            }
        }

        if (isReturning)
        {
            returnTimer += Time.deltaTime;
            if (returnTimer >= delayBeforeReturn)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, startRotation, rotationSpeed * Time.deltaTime);

                if (Quaternion.Angle(transform.rotation, startRotation) < 0.5f)
                {
                    transform.rotation = startRotation;
                    isActivated = false;
                    isReturning = false;
                }
            }
        }
    }

    public void ActivateLever()
    {
        if (isActivated)
        {
            return;
        }

        if (player.geld > 1)
        { 
            slotMachineScript.activateRoll = true;

            // Zielrotation = 55° mehr auf X-Achse (Animation starten)
            targetRotation = Quaternion.Euler(transform.eulerAngles.x + 55f, transform.eulerAngles.y, transform.eulerAngles.z);
            isActivated = true;
            isReturning = false;
        }
        else
        {
            // Zielrotation = 35° mehr auf X-Achse (Animation starten)
            targetRotation = Quaternion.Euler(transform.eulerAngles.x + 35f, transform.eulerAngles.y, transform.eulerAngles.z);
            isActivated = true;
            isReturning = false;
        }
    }
}
