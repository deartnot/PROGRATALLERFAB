using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform cameraAnchor; // El objeto dentro del personaje al que la cámara se mantendrá anclada
    public float mouseSensitivity = 100f; // Sensibilidad del mouse para la rotación
    public float verticalRotationLimit = 60f; // Límite de rotación vertical

    private float rotationY = 0f; // Rotación vertical de la cámara
    private float rotationX = 0f; // Rotación horizontal de la cámara

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
        rotationY = Mathf.Clamp(rotationY, -verticalRotationLimit, verticalRotationLimit); // Limita la rotación vertical

        // Crear una rotación en base al mouse
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);

        // Aplicar la rotación a la cámara
        transform.position = cameraAnchor.position; // Mantener la posición de la cámara fija con respecto al ancla
        transform.rotation = rotation; // Aplicar la rotación de la cámara
    }

}
