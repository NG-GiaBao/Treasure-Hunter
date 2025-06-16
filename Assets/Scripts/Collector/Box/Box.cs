using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Box : MonoBehaviour
{
    [SerializeField] private bool m_HasDiamond = false;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Rigidbody2D m_DiamondRb;
    [SerializeField] private RigidbodyType2D m_TypeRb;
    [SerializeField] private float scatterRadius = 1f;
    [SerializeField] private float scatterDuration = 1f;
    [SerializeField] private float height = 1f;
    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_DiamondRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        StartCoroutine(ITimeSetTypeRb());
    }

    public void ChangeStateOfBoxes()
    {
        m_HasDiamond = true;
    }
    public bool GetStateOfBoxes()
    {
        return m_HasDiamond;
    }

    public void OpenBox()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Diamond"))
            {
                child.gameObject.SetActive(true);
                Vector3 startPos = child.transform.position;
                Vector2 randomX = Random.insideUnitCircle * scatterRadius;
                Vector3 endPos = new(startPos.x + randomX.x, startPos.y, startPos.z);
                child.transform.DOJump(
                     endPos,            // target vị trí (x chạy đến, y quay về startPos.y)
                     height,            // độ cao nhảy
                     1,                 // nhảy 1 lần
                     scatterDuration    // tổng thời gian
                 ).SetEase(Ease.OutQuad);
                break;
            }
        }

        if (TryGetComponent<BoxCollider2D>(out var boxCollider2D)) boxCollider2D.isTrigger = true;
    }

    public void ChangeAnimationBox()
    {
        m_Animator.SetTrigger("Hit");
    }
    private IEnumerator ITimeSetTypeRb()
    {
        yield return new WaitForSeconds(1f);
        m_DiamondRb.bodyType = m_TypeRb;
    }
}
