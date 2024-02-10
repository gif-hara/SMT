using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SMT
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField]
        private HK.UI.HKUIDocument uiDocument;

        [SerializeField]
        private int endCount;

        void Start()
        {
            var document = Instantiate(uiDocument);
            var end = document.Q("End");
            end.SetActive(false);
        }
    }
}
