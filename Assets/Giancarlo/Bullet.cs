using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public Vector3 target;
    public float speed = 0.01f;
    public bool fire = false;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Health>().Damage(damage);
        Destroy(this.gameObject);
    }

    void Update()
    {
        if(fire)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target, speed);
            if(Vector3.Distance(this.transform.position, target) < 0.1f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
