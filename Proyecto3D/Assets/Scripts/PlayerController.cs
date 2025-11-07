using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento

    void Update()
    {
        // Obtener entrada del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Crear un vector de movimiento
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Mover al personaje
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
