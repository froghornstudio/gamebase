using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VGame {
    public class en : Lng {

        protected override void ImplementationRun() {
            #region Menus
            //Warnings Menu
            menus[0] = "Warning Message 1";
            menus[1] = "Warning Message 2";
            menus[2] = "Quit";
            menus[3] = "Play";

            //MainMenu
            menus[4] = "Start";
            menus[5] = "Extras";
            menus[6] = "Options";
            menus[7] = "Quit";

            //StartGame Menu
            menus[8] = "Start Game";
            menus[9] = "Skip Intro";
            menus[10] = "Reset Game";
            menus[11] = "Ok";

            //Options Menu
            menus[12] = "Video";
            menus[13] = "Audio";
            menus[14] = "Controls";

            //Audio Menu
            menus[15] = "Master";
            menus[16] = "Dialogue";
            menus[17] = "Music";
            menus[18] = "SFX";

            //Video Menu
            menus[19] = "Full Screen";
            menus[20] = "Windowed";
            menus[21] = "Apply";

            //Version
            menus[22] = "Version";

            //Controls Menu
            menus[23] = "Left Click to Move";
            menus[24] = "Right Click to Open Pause Menu";
            menus[25] = "Touch One Finger to Move";
            menus[26] = "Touch Two Fingers to Open Pause Menu in game";

            //Extras Menu
            menus[27] = "Continue";
            menus[28] = "Female Vocals";
            menus[29] = "Male Vocals";

            //Thank You
            menus[30] = "Thank You";

            #endregion


            #region dialogue
            dialogue[0] = "This is some dialogue.";
            #endregion

        }
    }
}