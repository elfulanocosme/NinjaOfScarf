using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Player : MonoBehaviour
{
    public GameObject shurikenPrefab;
    public float velocidad = 2f;
    public Rigidbody2D rb;
    public Transform mouse;
    public Transform brazo;

    public SpriteRenderer brazoRenderer;

    public Vector3 targetRotation;

    public Animator animEspada;

    public Animator animFxEspada;

    public Animator playerAnimator;
   
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();

        //detectar mouse y posicionar mira
        mouse.position = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            -Camera.main.transform.position.z));

        if (Input.GetMouseButtonDown(1))
        {
            Arrojarshuriken();
        }
        MoverBrazo();
        if (Input.GetMouseButtonDown(0))
        {
            animEspada.SetTrigger("Espadazo");
            animFxEspada.SetTrigger("Destello");

        }
        
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(inputMovimiento * velocidad, rb.velocity.y);
    }

    public void Arrojarshuriken()
    {
        GameObject nuevoShuriken = Instantiate(shurikenPrefab, transform.position, Quaternion.identity);

        Vector2 direccion = (mouse.position - transform.position).normalized; //como un vector unitario (1)

        nuevoShuriken.GetComponent<Shuriken>().direccion = direccion; 
    }
    public void MoverBrazo()
    {
        targetRotation = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
        brazo.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (angle > 90 || angle < -90)
        {
            brazoRenderer.flipY = true;

        }
        else
        {
            brazoRenderer.flipY = false;
        }
    }
}

