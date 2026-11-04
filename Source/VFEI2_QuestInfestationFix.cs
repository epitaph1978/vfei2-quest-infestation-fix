using System;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace VFEI2_QuestInfestationFix
{
    [StaticConstructorOnStartup]
    public static class ModInit
    {
        static ModInit()
        {
            var harmony = new Harmony("epitaph.vfei2questinfestationfix");
            harmony.PatchAll();
            Log.Message("[VFEI2 Quest Infestation Fix] Initialized successfully.");
        }
    }

    [HarmonyPatch(typeof(InfestationUtility), nameof(InfestationUtility.SpawnTunnels))]
    public static class Patch_InfestationUtility_SpawnTunnels
    {
        [HarmonyPrefix]
        public static void Prefix(int hiveCount, Map map, ref float? insectsPoints)
        {
            if (!insectsPoints.HasValue || insectsPoints.Value <= 0f)
            {
                float pointsPerHive = 250f;
                insectsPoints = Mathf.Max(hiveCount * pointsPerHive, 250f);
                Log.Message(string.Format("[VFEI2 Quest Infestation Fix] Infestation spawned with missing insectsPoints for {0} hives. Injected {1} combat points so VFEI2 can spawn defenders/assault insects.", hiveCount, insectsPoints.Value));
            }
        }
    }

    [HarmonyPatch(typeof(TunnelHiveSpawner), "Spawn")]
    public static class Patch_TunnelHiveSpawner_Spawn
    {
        [HarmonyPriority(Priority.First)]
        public static void Prefix(TunnelHiveSpawner __instance)
        {
            if (__instance.insectsPoints <= 0f)
            {
                __instance.insectsPoints = 250f;
                Log.Message("[VFEI2 Quest Infestation Fix] Fallback: Injected 250 points into TunnelHiveSpawner with 0 insect points.");
            }
        }
    }
}
