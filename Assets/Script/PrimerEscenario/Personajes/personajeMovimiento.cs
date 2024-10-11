using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeMovimiento : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    // Solo si se quiere hacer animaciones
    /* private Animator anim; */

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Solo si se quiere hacer animaciones
        /* anim = GetComponent<Animator>(); */
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Ajustar la escala según la dirección del movimiento
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Solo si se quiere hacer animaciones
        /* if (moveInput != 0)
        {
            anim.SetBool("estaCorriendo", true);
        }
        else
        {
            anim.SetBool("estaCorriendo", false);
        } */
    }
}
