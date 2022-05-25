using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Game.Logic;

namespace Game.Components
{
    public class PlayCard : MonoBehaviour
    {

        private Card _cardScript;

        private void Awake()
        {
            _cardScript = gameObject.GetComponent<Card>();
        }

        //private void Start()
        //{
        //    EventDispatcher.Discard?.Invoke(_cardScript.CardInfo);
        //}

        // Update is called once per frame
        void Update()
        {
            // input para hacer que pase la info
            //EventDispatcher.Discard?.Invoke(_cardScript.CardInfo);
        }

        public void PlayThisCard(InputAction.CallbackContext context)
        {
            if(context.performed)
                Debug.Log(_cardScript.CardInfo.cardName);
        }
    }
}
