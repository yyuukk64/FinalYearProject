using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float bounceForce = 5f;
    public GameObject deathExplosion;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            Instantiate(deathExplosion, other.transform.position, other.transform.rotation);
            rb.velocity = new Vector3(rb.velocity.x, bounceForce, 0f);
        }
    }
}
