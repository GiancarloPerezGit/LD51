using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 0.01f;
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
        if (Vector3.Distance(this.transform.position, target) < 0.1f)
        {
            Debug.Log("dead af");
            Destroy(this.gameObject);
        }
    }

    public void Move( Vector3 targetToGo)
    {
        target = targetToGo;
        spawnMove = true;
    }
}
