using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VGame {
public class NewLoadDeleteUI : MonoBehaviour {

		[Header("New Game Buttons")]
		[SerializeField] private GameObject newbtn1;
		[SerializeField] private GameObject newbtn2;
		[SerializeField] private GameObject newbtn3;

		[Header("Delete Buttons")]
		[SerializeField] private GameObject deletebtn1;
		[SerializeField] private GameObject deletebtn2;
		[SerializeField] private GameObject deletebtn3;

		[Header("Load Buttons")]
		[SerializeField] private GameObject loadbtn1;
		[SerializeField] private GameObject loadbtn2;
		[SerializeField] private GameObject loadbtn3;

        private void Start() {
			refreshButtons();
        }


		//Tries to populate the static PlayerSO's that are in Gamemaster that are just for this purpose of temporarily looking
		//at the saved player data
		private void loadSlotData() {
			GameMaster.LoadData("PlayerData", GameMaster.bandaidSlotA, 1);
			GameMaster.LoadData("PlayerData", GameMaster.bandaidSlotB, 2);
			GameMaster.LoadData("PlayerData", GameMaster.bandaidSlotC, 3);
		}

		//Hide all of the buttons
		private void hideAllButtons() {
			newbtn1.SetActive(false);
			newbtn2.SetActive(false);
			newbtn3.SetActive(false);
			deletebtn1.SetActive(false);
			deletebtn2.SetActive(false);
			deletebtn3.SetActive(false);
			loadbtn1.SetActive(false);
			loadbtn2.SetActive(false);
			loadbtn3.SetActive(false);
        }


		private void refreshButtons() {
			hideAllButtons();
			loadSlotData();

			//First save slot
			if (GameMaster.bandaidSlotA.savedScene == "") {
				newbtn1.SetActive(true);
            } else {
				deletebtn1.SetActive(true);
				loadbtn1.SetActive(true);
            }

			//Second save slot
			if (GameMaster.bandaidSlotB.savedScene == "") {
				newbtn2.SetActive(true);
			} else {
				deletebtn2.SetActive(true);
				loadbtn2.SetActive(true);
			}

			//Third save slot
			if (GameMaster.bandaidSlotC.savedScene == "") {
				newbtn3.SetActive(true);
			} else {
				deletebtn3.SetActive(true);
				loadbtn3.SetActive(true);
			}


		}


		public void OnClick_NewBtn(int slotnum) {
			GameMaster.CurrentSlot = slotnum;
			//Start your game here!
		}

		public void OnClick_LoadBtn(int slotnum) {
			GameMaster.CurrentSlot = slotnum;
			
			//Load Game Data into Runtime SO
			GameMaster.LoadData("PlayerData", GameMaster.GetSO<PlayerSO>(), slotnum);

			//Load your game here. Default behaviour is to load the scene specified in the runtime PlayerSO
			SceneManager.LoadScene(GameMaster.GetSO<PlayerSO>().savedScene);
		}


		public void OnClick_DeleteBtn(int slotnum) {
			if (slotnum == 1) {
				GameMaster.bandaidSlotA = GameMaster.bandaidBlank;
				GameMaster.SaveData("PlayerData", GameMaster.bandaidBlank, slotnum);
			}

			if (slotnum == 2) {
				GameMaster.bandaidSlotB = GameMaster.bandaidBlank;
				GameMaster.SaveData("PlayerData", GameMaster.bandaidBlank, slotnum);
			}

			if (slotnum == 3) {
				GameMaster.bandaidSlotC = GameMaster.bandaidBlank;
				GameMaster.SaveData("PlayerData", GameMaster.bandaidBlank, slotnum);
			}

			refreshButtons();

		}


	}
}