using UnityEngine;

public class TrapAnim : MonoBehaviour
{
    [SerializeField] protected Animator m_Animator;
    [SerializeField] private float speedAnim;


    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
      
    }
   

    public void CheckDetecPlayer(bool IsDetecPlayer)
    {
        if (IsDetecPlayer)
        {
            m_Animator.SetBool("IsDected", true);
            m_Animator.SetBool("IsFire", true);
            m_Animator.SetFloat("FireSpeed", speedAnim);
        }
        else
        {
            m_Animator.SetBool("IsDected", false);
            m_Animator.SetBool("IsFire", false);
        }
    }
}
