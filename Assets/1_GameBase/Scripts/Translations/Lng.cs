using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VGame {
    public class Lng {

        public static Dictionary<int, string> menus = new Dictionary<int, string>();
        public static Dictionary<int, string> dialogue = new Dictionary<int, string>();

        public void Run() => ImplementationRun();

        // Stub virtual method to be overriden in child classes
        protected virtual void ImplementationRun() {
        }


    }
}
