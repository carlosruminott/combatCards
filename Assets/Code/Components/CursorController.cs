using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Game.Logic;
using Game.Components.Abilities;

// tutorial: https://www.youtube.com/watch?v=JID7YaHAtKA

namespace Game.Components
{
    public class CursorController : MonoBehaviour
    {
        private Camera _camera;
        private PlayerInputActions _controls;

        private void Awake()
        {
            _camera = Camera.main;
            _controls = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Start()
        {
            _controls.Mouse.Click.performed += _ => StartedClick();
        }

        private void StartedClick()
        {
            DetectObject();
        }

        //private void EndedClick(){}

        private void DetectObject()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);

            if(hits2D.collider != null)
            {
                //Debug.Log("hit "+hits2D.collider.GetComponent<Card>().CardInfo.cardName);
                Card card = hits2D.collider.GetComponent<Card>();
                if(card.CardInfo.ability)
                {
                    //Debug.Log(card.CardInfo.ability.name);
                    Ability ability = card.CardInfo.ability.GetComponent<Ability>();
                    ability.OnActivate();
                }
                //EventDispatcher.Discard?.Invoke(card.CardInfo);
            }
        }

    }
}
