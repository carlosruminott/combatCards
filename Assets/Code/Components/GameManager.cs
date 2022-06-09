using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private GameObject _game;
        [SerializeField] private UIDirector _ui;
        enum PauseState
        {
            Active,
            Paused
        }

        PauseState m_pauseState = PauseState.Active;

        public void Awake()
        {
            Debug.Assert(_game != null, "Game is not assigned in GameDirector");
            Debug.Assert(_ui != null, "UI is not assigned in GameDirector");
        }


        public void UserRequestedPause()
        {
            switch (m_pauseState)
            {
                case PauseState.Active:
                    //Parar el mundo
                    _game.SetActive(false);
                    //Activar el blurr
                    _ui.ActivatePause();
                    m_pauseState = PauseState.Paused;
                    break;
                case PauseState.Paused:
                    //Activar el mundo
                    _game.SetActive(true);
                    //desactivar el blurr
                    _ui.DeactivatePause();
                    m_pauseState = PauseState.Active;
                    break;
            }
        }
    }
}
