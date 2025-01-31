﻿using UnityEngine;
using JaLoader;
using System.Timers;
using Object = UnityEngine.Object;
using Timer = System.Timers.Timer;
using System.Reflection;

namespace Doorstop
{
    class Entrypoint
    {
        private static Timer timer;

        public static void Start()
        {
            timer = new Timer(3000);
            timer.Elapsed += RunTimer;
            timer.Enabled = true;
        }   

        private static void RunTimer(object sender, ElapsedEventArgs e)
        {
            GameObject obj = new GameObject();

            GameObject insObj = Object.Instantiate(obj);
            insObj.AddComponent<AddModLoaderComponent>();
            Object.DontDestroyOnLoad(insObj);

            timer.Enabled = false;
            timer.Dispose();
            timer.Elapsed -= RunTimer;
            timer = null;
        }
    }

    public class AddModLoaderComponent : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("JaLoader found!");
        }

        void Update()
        {
            if (!gameObject.GetComponent<ModLoader>())
            {
                gameObject.AddComponent<ModLoader>();
            }
            else
            {
                gameObject.name = "JaLoader";
                Destroy(this);
            }
        }
    }
}
