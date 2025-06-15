using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVfx : MonoBehaviour
{
    [SerializeField] private GameObject m_BloodVFX;
    // Start is called before the first frame update

    public void ActiveBloodVFX(Transform m_PosBlood)
    {
        GameObject bloodVFX = Instantiate(m_BloodVFX, m_PosBlood.position, Quaternion.identity);
        Destroy(bloodVFX,2f);
    }
}
