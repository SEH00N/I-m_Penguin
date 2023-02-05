using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public abstract class Projectile : MonoBehaviour
{
    public string targetTag;
    public float lifeTime;
    public float speed;

    private void Start()
    {
        StartCoroutine(Life());
    }

    private void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            TakeDamage(collision.GetComponent<IDamageable>());
        }

        Destroy(gameObject);//풀로 변경
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private IEnumerator Life()
    {
        yield return new WaitForSeconds(lifeTime);

        Debug.Log("Destroy Projectile");
        Destroy(gameObject);//풀로 변경
    }

    protected abstract void TakeDamage(IDamageable target);
}