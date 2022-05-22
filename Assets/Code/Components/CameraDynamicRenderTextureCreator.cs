using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    [RequireComponent(typeof(Camera))]
    public class CameraDynamicRenderTextureCreator : MonoBehaviour
    {
        RenderTexture m_renderTexture;
        private void Awake()
        {
            Camera camera = GetComponent<Camera>();
            m_renderTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
            camera.targetTexture = m_renderTexture;
        }
    }
}
