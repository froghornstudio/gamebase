using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace VGame {
    public class TPM_Lang : MonoBehaviour {

        private TextMeshProUGUI tpm = default;

        private enum Defs { menus }
        [SerializeField] private Defs myDef = Defs.menus;
        [SerializeField] private int index = default;

        private void Awake() {
            tpm = GetComponent<TextMeshProUGUI>();

            //Change language dictionary
            switch (myDef) {
                case Defs.menus:
                    tpm.text = Lng.menus[index].ToString();
                    break;
                default:
                    break;
            }



            
        }

    }
}