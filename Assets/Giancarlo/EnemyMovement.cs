using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.005f;
    public float distanceToBlow = 0.1f;
    // Start is called before the first frame update
    private bool spawnMove = false;
    private Vector3 target;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnMove == false || target == null) return;

        transform.position = Vector3.MoveTowards(this.transform.position, target, speed);
        if (Vector3.Distance(this.transform.position, target) < distanceToBlow)
        {
            Debug.Log("dead af");
            FindObjectOfType<PlayerHealth>().Damage(GetComponent<EnemyDamage>().damage);
            
            Destroy(this.gameObject);
        }
    }

    public void Move( Vector3 targetToGo)
    {
        target = targetToGo;
        spawnMove = true;
    }
}
