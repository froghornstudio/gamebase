using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VGame {
    [CreateAssetMenu]
    public class PlayerSO : ScriptableObject {

        [Header("Recommended Variables to Keep")]
        public string saveFileVersion = default;
        public int checkpoint = 0;
        public string savedScene = default;

        [Header("Custom Variables")]
        public string changeme = default;

    }
}