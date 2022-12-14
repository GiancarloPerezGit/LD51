using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public Vector3 target;
    public float speed = 1.0f;
    public bool fire = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if (health == null) return;

        health.Damage(damage);
        Destroy(this.gameObject);
    }

    void Update()
    {
        if(fire)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
            if(Vector3.Distance(this.transform.position, target) < 0.1f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
