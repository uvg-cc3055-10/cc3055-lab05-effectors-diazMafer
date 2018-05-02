/*
 * @Author: Maria Fernanda Lope
 * @Version: 2/05/2018
 * Script que modela las funciones del personaje principal sus movimientos y detecta cuando este colisiona
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour {


    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;
    private float speed = 5f;
    private float jumpForce = 250f;
    private bool facingRight = true;
    public GameObject feet;
    public LayerMask layerMask;
 


	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
	

	void Update () {
        float move = Input.GetAxis("Horizontal");
        if (move != 0) {
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            facingRight = move > 0;
        }

        anim.SetFloat("Speed", Mathf.Abs(move));

        sr.flipX = !facingRight;
        //se modifico el script para que este solo pueda saltar cuando esta tocando el piso 
        if (Input.GetButtonDown("Jump")) {
            RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);
            if (raycast.collider != null)
            {
                rb2d.AddForce(Vector2.up * jumpForce);
            }
        }
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //se detecta la colision con la pesa para que se pueda reiniciar la escena
        if (collision.gameObject.name.Equals("Weight"))
        {
            SceneManager.LoadScene("Dungeon2");
        }
    }
}
