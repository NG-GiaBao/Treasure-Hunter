using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCameraBase m_VirtualCamera;

    private void Awake()
    {
        m_VirtualCamera=GetComponent<CinemachineVirtualCameraBase>();
    }
    private void Start()
    {
        m_VirtualCamera.Follow = NewPlayerManager.Instance.transform;
    }
}
