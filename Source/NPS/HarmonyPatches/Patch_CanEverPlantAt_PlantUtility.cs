﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace TKKN_NPS.HarmonyPatches
{
    [HarmonyPatch(typeof(PlantUtility))]
    [HarmonyPatch("CanEverPlantAt")]
    internal class Patch_CanEverPlantAt_PlantUtility
    {
        [HarmonyPostfix]
        public static void Postfix(ThingDef plantDef, IntVec3 c, Map map, ref bool __result)
        {
            if (!__result)
            {
                return;
            }

            //verify that the plant can grow on this terrain.
            var terrain = c.GetTerrain(map);
            var weatherReaction = plantDef.GetModExtension<ThingWeatherReaction>();
            if (weatherReaction?.allowedTerrains == null)
            {
                return;
            }

            if (!weatherReaction.allowedTerrains.Contains(terrain))
            {
                __result = false;
            }
        }
    }
}