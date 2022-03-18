using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VGame {
public class SimpleMenuSwitcher : MonoBehaviour {

		[Header("Place all top level panels here")]
		[SerializeField] private GameObject[] panels = default;
		
		[Header("Which Panel to show first")]
		[SerializeField] private int firstPanelShow = default;

        private void Start() {
            ChangePanel(firstPanelShow);
        }

        public void ChangePanel(int panelNum) {
			HideAllPanels();
			panels[panelNum].SetActive(true);
        }

		private void HideAllPanels() {
            foreach (GameObject item in panels) {
				item.SetActive(false);
            }
        }

	}
}