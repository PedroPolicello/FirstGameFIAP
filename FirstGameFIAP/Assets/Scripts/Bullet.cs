using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float bulletLifeTime = 1f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
