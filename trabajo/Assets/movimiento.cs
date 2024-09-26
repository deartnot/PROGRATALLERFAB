using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Velocidad de movimiento editable desde el Inspector
    public string targetTag = "Target"; // El tag del objeto al que queremos movernos
    public float stopDistance = 0.1f; // Distancia mínima para detener el movimiento (editable desde el Inspector)

    private CharacterController controller; // El Character Controller del jugador
    private Transform target; // El objetivo al que el jugador se moverá
    private bool isMoving = false; // Estado para saber si el jugador está en movimiento

    void Start()
    {
        // Obtener el componente CharacterController que está adjunto al jugador
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Verificar si se hizo clic con el mouse
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(targetTag))
                {
                    target = hit.collider.transform; // Establecer el objetivo al que el jugador se moverá
                    isMoving = true; // Activar el movimiento
                }
            }
        }

        if (isMoving && target != null)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // Calcular la dirección hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 move = direction * moveSpeed * Time.deltaTime;

        // Mover al jugador en la dirección del objetivo
        controller.Move(move);

        // Verificar si el jugador ha llegado al objetivo
        if (Vector3.Distance(transform.position, target.position) < stopDistance)
        {
            isMoving = false; // Detener el movimiento al alcanzar el objetivo
            target = null; // Limpiar el objetivo
        }
    }
}
