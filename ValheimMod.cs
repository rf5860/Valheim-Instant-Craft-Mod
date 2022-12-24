using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace Valheim_Mod
{
    [BepInPlugin("rjf.ValheimMod", "Valheim Mod", "1.0.1")]
    [BepInProcess("valheim.exe")]
    public class ValheimMod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("rjf.ValheimMod");

        void Awake()
        {
            harmony.PatchAll();
        }


        [HarmonyPatch(typeof(InventoryGui), "UpdateRecipe")]
        class Craft_Patch
        {
            static void Prefix(ref InventoryGui __instance)
            {
                __instance.m_craftDuration = .01f;
            }
        }
    }
}
