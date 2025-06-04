using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private bool m_HasDiamond = false;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Rigidbody2D m_DiamondRb;
    [SerializeField] private RigidbodyType2D m_TypeRb;
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
                break;
            }
        }

        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        if (boxCollider2D != null) boxCollider2D.isTrigger = true;
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
