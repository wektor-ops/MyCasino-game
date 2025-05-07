using UnityEngine;

public class camera : MonoBehaviour
{
    public float mouseSensitivity = 150f;
    public Transform playerBody; // z. B. der Spieler (für horizontales Drehen)

    float xRotation = 0f;

    void Start()
    {
        // Mauszeiger verstecken und sperren
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mausbewegung einlesen
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertikale Rotation (nach oben/unten)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Begrenzung des Blickwinkels

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontale Rotation (nach links/rechts)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
