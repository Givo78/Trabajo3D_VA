using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f; 
    public float rotationSpeed = 250;

    public Animator animator;

    private float x, y;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        transform.Translate(0,0,y * Time.deltaTime * moveSpeed);


       animator.SetFloat("VelX", x);
       animator.SetFloat("VelY", y);

    }
}
