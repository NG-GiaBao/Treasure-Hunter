using UnityEngine;

public class TrapController : MonoBehaviour
{
    public TrapAnim m_TrapAnim;
    public TrapDetectedPlayer m_TrapDetectedPlayer;
    public TrapFlip m_TrapFlip;
    public TrapHeal m_TrapHeal;
    public Destroyed m_Destroyed;

    private void Awake()
    {
        m_TrapAnim = GetComponent<TrapAnim>();
        m_TrapDetectedPlayer = GetComponent<TrapDetectedPlayer>();
        m_TrapFlip = GetComponent<TrapFlip>();
        m_TrapHeal = GetComponent<TrapHeal>();
        m_Destroyed=GetComponent<Destroyed>();
    }

}
