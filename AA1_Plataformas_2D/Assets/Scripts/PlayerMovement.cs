using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public Animator animator;

    [Header("Movimiento")]

    private float movimientoHorizontal = 0f;

    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)][SerializeField] private float SuavizadoDeMovimiento;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;

    [Header("Salto")]

    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    [SerializeField] private bool saltando = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxis("Horizontal") * velocidadDeMovimiento;



        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            saltando = true;
        }

    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        //mover
        Mover(movimientoHorizontal * Time.fixedDeltaTime, saltando);
        saltando = false;
    }

    private void Mover(float moviendo, bool saltando)
    {
        Vector3 velocidadObjetivo = new Vector2(moviendo, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, SuavizadoDeMovimiento);

        if (moviendo > 0 && !mirandoDerecha)
        {
            //girar
            Girar();
        }
        else if (moviendo < 0 && mirandoDerecha)
        {
            //girar
            Girar();
        }
        if (enSuelo && saltando)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
        //animator.SetBool("isJumping", enSuelo);
        animator.SetBool("isMoving", moviendo != 0);
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}

