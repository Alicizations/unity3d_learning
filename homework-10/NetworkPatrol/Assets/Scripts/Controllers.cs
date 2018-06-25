using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;

namespace Mygame
{
    public interface ISceneController
    {
        void LoadResources();
    }

    public interface UserAction
    {
        void restart();
    }

    public class Director : System.Object
    {

        private static Director _instance;

        public ISceneController CurrentScenceController { get; set; }
        public bool running { get; set; }

        public static Director GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Director();
            }

            return _instance;
        }

    }
}