using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPC : MonoBehaviour
{
    private CapsuleCollider cap;
    public float velocidade = 10;
    private Quaternion rotOriginal;
    private float contRot = 0;
    public AudioSource somXp;
    public AudioSource somNPC;
    public AudioSource somPilula;

    void Start()
    {
        cap = GetComponent<CapsuleCollider>();
        rotOriginal = transform.localRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "npc")
        {
            somNPC.Play();
            scriptVida.score -= 1;
        }

        if (collision.gameObject.tag == "xp")
        {
            somXp.Play();
            scriptVida.score += 1;
            var x = Random.Range(-20, 57);
            var z = Random.Range(-24, 72);

            collision.gameObject.transform.position = new Vector3(x, 2.5f, z);

        }

        if (collision.gameObject.tag == "pilula")
        {
            somPilula.Play();
            scriptPlacar.score += 1;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "portal")
        {
            this.transform.position = new Vector3(56, 3, 10);
        }

        if (collision.gameObject.tag == "portal2")
        {
            this.transform.position = new Vector3(-19, 3, 10);
        }


        if (scriptVida.score == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }

        if (scriptPlacar.score == 30)
        {
            SceneManager.LoadScene(1);
        }

    }

    void Update()
    {
        float moveLado = Input.GetAxis("Horizontal");
        float moveFrente = Input.GetAxis("Vertical");

        cap.transform.Translate(new Vector3(moveLado * velocidade, 0, moveFrente * velocidade));

        float rotLado = Input.GetAxis("Mouse X") *2;
        contRot += rotLado;

        Quaternion lado = Quaternion.AngleAxis(contRot, Vector3.up);

        transform.localRotation = rotOriginal * lado;

    }
}
