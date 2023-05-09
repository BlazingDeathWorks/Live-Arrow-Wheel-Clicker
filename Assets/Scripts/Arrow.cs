using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private bool canRelease = false;
    private Rigidbody2D rb;
    private const string DEFAULT = "Default";
    private const string ARROW = "Arrow";
    private const string DISK = "Disk";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!canRelease) return;
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(DISK))
        {
            ScoreManager.Instance.IncreaseScore();
            Disk.Instance.AddArrow(this);
            gameObject.layer = LayerMask.NameToLayer(DEFAULT);
        }

        if (collision.gameObject.CompareTag(ARROW))
        {
            Destroy(gameObject);
            ScoreManager.Instance.Reset();
        }
    }

    internal void Release()
    {
        canRelease = true;
    }
}
