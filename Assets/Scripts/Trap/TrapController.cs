using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public TrapAnim m_TrapAnim;
    public TrapDetectedPlayer m_TrapDetectedPlayer;
    public TrapFlip m_TrapFlip;

    private void Awake()
    {
        m_TrapAnim = GetComponent<TrapAnim>();
        m_TrapDetectedPlayer = GetComponent<TrapDetectedPlayer>();
        m_TrapFlip = GetComponent<TrapFlip>();  
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
