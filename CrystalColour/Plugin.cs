using BepInEx;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilla;

namespace CrystalColour
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        //"Not a bird"'s Idea
        GameObject CaveStuff, Crystal;
        Renderer CrystalRend;

        Color ColToSet => GorillaTagger.Instance.offlineVRRig.playerColor;

        bool caveLoaded;
        public Plugin()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnLoaded;
            //"Not a bird"'s Idea
        }

        private void OnSceneUnLoaded(Scene scene)
        {
            if (scene.name == "Cave")
            {
                caveLoaded = false;
                //"Not a bird"'s Idea
            }
        }
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Cave")
            {
                CaveStuff = GameObject.Find("Cave_Main_Prefab");
                Crystal = CaveStuff.transform.FindChildRecursive("C_DarkCrystal_Big").gameObject;
                CrystalRend = Crystal.GetComponent<Renderer>();
                caveLoaded = true;
                //"Not a bird"'s Idea
            }
        }

        void FixedUpdate()
        {
            if (caveLoaded)
            {
                if (CrystalRend.material.color != ColToSet)
                {
                    CrystalRend.material.color = ColToSet;
                    //"Not a bird"'s Idea
                }
            }
        }
    }
}