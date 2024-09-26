using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform cameraAnchor; // El objeto dentro del personaje al que la c�mara se mantendr� anclada
    public float mouseSensitivity = 100f; // Sensibilidad del mouse para la rotaci�n
    public float verticalRotationLimit = 60f; // L�mite de rotaci�n vertical

    private float rotationY = 0f; // Rotaci�n vertical de la c�mara
    private float rotationX = 0f; // Rotaci�n horizontal de la c�mara

    void Start()
    {
        // Ocultar y bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Obtener el movimiento del mouse
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -verticalRotationLimit, verticalRotationLimit); // Limita la rotaci�n vertical

        // Crear una rotaci�n en base al mouse
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);

        // Aplicar la rotaci�n a la c�mara
        transform.position = cameraAnchor.position; // Mantener la posici�n de la c�mara fija con respecto al ancla
        transform.rotation = rotation; // Aplicar la rotaci�n de la c�mara
    }

}
