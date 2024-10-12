using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeMovimiento : MonoBehaviour
{
    // Velocidad de movimiento
    public float velocidad = 5f;

    //Fuerza de salto
    public float fuerzaSalto = 10f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;
    private bool enSuelo;

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
        /* =================== MOVIMIENTO PERSONAJE =========================== */
            float moverObjeto = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moverObjeto * velocidad, rb.velocity.y);

            // Ajustar la escala según la dirección del movimiento
            if (moverObjeto > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (moverObjeto < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        /* ===================================================================== */

        /* =================== SALTO PERSONAJE =========================== */
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
            enSuelo = hit.collider != null;
            if(enSuelo && Input.GetKeyDown(KeyCode.Space)){
                rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            }
        /* ===================================================================== */


        /* =================== ANIMACION PERSONAJE =========================== */

            // Solo si se quiere hacer animaciones
            /* if (moverObjeto != 0)
            {
                anim.SetBool("estaCorriendo", true);
            }
            else
            {
                anim.SetBool("estaCorriendo", false);
            } */
        /* ===================================================================== */

    }

    // Dibujar el raycast en el editor para el salto
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}
