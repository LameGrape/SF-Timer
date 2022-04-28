using UnityEngine;
using TMPro;
using HarmonyLib;
using System.Diagnostics;
using System;

namespace SFTimer
{
    class ControllerPatch
    {
        public static DateTime startTime;
        public static GameObject timer;
        public static void Patch(Harmony harmonyInstance)
        {
            var StartMethod = AccessTools.Method(typeof(Controller), "Start");
            var StartMethodFix = new HarmonyMethod(typeof(ControllerPatch).GetMethod(nameof(ControllerPatch.StartMethodFix)));
            harmonyInstance.Patch(StartMethod, prefix: StartMethodFix);

            var UpdateMethod = AccessTools.Method(typeof(Controller), "Update");
            var UpdateMethodFix = new HarmonyMethod(typeof(ControllerPatch).GetMethod(nameof(ControllerPatch.UpdateMethodFix)));
            harmonyInstance.Patch(UpdateMethod, prefix: UpdateMethodFix);
        }
        public static void StartMethodFix(Controller __instance)
        {
            if(GameObject.Find("Timer") != null){
                GameObject.Destroy(GameObject.Find("Timer"));
            }
            timer = new GameObject("Timer");
            timer.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            TextMeshProUGUI tmp = timer.AddComponent<TextMeshProUGUI>();
            tmp.alignment = TextAlignmentOptions.TopLeft;
            tmp.fontSize = 75;
            tmp.fontStyle = FontStyles.Bold;
            tmp.color = Color.white;
            UnityEngine.Debug.Log("Starting Timer");
            startTime = DateTime.Now;
        }
        public static void UpdateMethodFix(Controller __instance)
        {
            TimeSpan ts = startTime - DateTime.Now;
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", -ts.Minutes, -ts.Seconds, -ts.Milliseconds / 10);
            timer.GetComponent<TextMeshProUGUI>().text = elapsedTime;
        }
    }
}
