using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    public class UIDirector : MonoBehaviour
    {
        [SerializeField] GameObject m_blurWidget;
        //[SerializeField] GameObject m_pauseMenu;

        private void Awake()
        {
            Debug.Assert(m_blurWidget != null, "Blur widget not set in UI Director");
            //Debug.Assert(m_pauseMenu != null, "Pause menu not set in UI Director");
        }

        void Start()
        {
            m_blurWidget.gameObject.SetActive(false);
            //m_pauseMenu.gameObject.SetActive(false);
        }

        public void ActivatePause()
        {
            m_blurWidget.gameObject.SetActive(true);
            //m_pauseMenu.gameObject.SetActive(true);

        }
        public void DeactivatePause()
        {
            m_blurWidget.gameObject.SetActive(false);
            //m_pauseMenu.gameObject.SetActive(false);

        }
    }
}
