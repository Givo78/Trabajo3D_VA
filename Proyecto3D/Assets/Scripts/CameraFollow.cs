using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;
    public LayerMask paredMask; // asigna aquí las capas donde están las paredes

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // Dirección desde el objetivo hacia la posición deseada
        Vector3 dir = desiredPosition - target.position;
        float dist = dir.magnitude;

        // Ajuste para no atravesar paredes
        if (Physics.Raycast(target.position, dir.normalized, out RaycastHit hit, dist, paredMask))
        {
            // Colisiona con algo con tag "Pared"
            if (hit.collider.CompareTag("Pared"))
            {
                // Coloca la cámara justo delante de la pared
                desiredPosition = hit.point - dir.normalized * 0.3f; 
            }
        }

        // Movimiento suave
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
