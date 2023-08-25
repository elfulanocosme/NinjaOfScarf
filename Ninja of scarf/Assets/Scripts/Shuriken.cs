using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public bool estaVolando = true;
    public float magnitudTorque = 100f;
    public float fuerzaArrojarShuriken = 10f;
    public Vector2 direccion;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estaVolando == false )
        {
            return;
        }
        rb.AddForce(fuerzaArrojarShuriken * direccion, ForceMode2D.Impulse);

        // torque - rotacion
        rb.AddTorque(magnitudTorque, ForceMode2D.Impulse);
        rb.AddTorque(magnitudTorque / 3, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        // lo que tiene que haces cuando colisiona 
        estaVolando = false;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

    }


}
