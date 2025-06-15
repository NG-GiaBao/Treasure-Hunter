using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
      rb.velocity = new (rb.velocity.x*speed, rb.velocity.y);
        //StartCoroutine(TimeDelay());
    }
    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(2f);
        // Optionally, you can add any action to perform after the delay
        Debug.Log("Delay completed.");
        transform.DOMoveX(targetPos.position.x, 5f)
           .SetEase(Ease.InOutSine)
           .OnComplete(() =>
           {
               // Optionally, you can add any action to perform after the movement is complete
               Debug.Log("Ship has moved to the target position.");
           });
    }
}
