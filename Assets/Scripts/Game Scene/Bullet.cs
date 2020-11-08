using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f;

    public float lifeDuration = 2f;

    private float lifeTimer;

    void Start()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 initialPosition = transform.position;

        transform.position += transform.forward * speed * Time.deltaTime;
        Vector3 endPosition = transform.position;


        if (Physics.SphereCast(initialPosition, .2f, transform.forward, out hit, Vector3.Distance(initialPosition, endPosition)))
        {
            if (hit.collider.name == "Target")
            {
                Debug.Log("Target Hit");
                Destroy(hit.collider.gameObject);
            }
        }

        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Target")
        {
            Debug.Log("Target Hit");
        }
    }
}
