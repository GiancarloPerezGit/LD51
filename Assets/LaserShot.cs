using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public int laserDmg = 9;
    public float laserlifetime = 2.0f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 

        if(timer > laserlifetime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Health>();
        if(enemy == null) return;
        enemy.Damage(laserDmg);
        Debug.Log("Enemy got hit bruv!");
    }
}
