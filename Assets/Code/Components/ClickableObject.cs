using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ClickableObject : MonoBehaviour, IClickable
    {
        public void OnClick()
        {
            Debug.Log("somebody clicked me");
        }
    }
}
