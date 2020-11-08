using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f;

    public float lifeDuration = 2f;

    private float lifeTimer;
    private bool didBulletCollideWithObject;

    void Start()
    {
        lifeTimer = lifeDuration;
        didBulletCollideWithObject = false;
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
            if (hit.collider.name == "Target(Clone)")
            {
                targetHit(hit);
            }
            didBulletCollideWithObject = true;
        }

        lifeTimer -= Time.deltaTime;
        bool destroyBullet = didBulletCollideWithObject || lifeTimer <= 0f;
        if(destroyBullet)
        {
            Destroy(gameObject);
        }
    }

    private void targetHit(RaycastHit hit)
    {
        Destroy(hit.collider.gameObject);
        GameScript script = GameObject.Find("GameController").GetComponent<GameScript>();
        script.IncrementNumberOfHits();

    }
}
