using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Components
{
    [RequireComponent(typeof(RawImage))]
    public class CameraRenderTargetDisplay : MonoBehaviour
    {
        [SerializeField] Camera m_camera;
        RawImage m_image;
        
        private void Awake()
        {
            m_image = GetComponent<RawImage>();
            Debug.Assert(m_camera != null, "Camera of CameraRenderTargetDisplay [" + gameObject.name + "] is not set");
        }

        void Start()
        {
            m_image.texture = m_camera.targetTexture;
        }
    }
}
