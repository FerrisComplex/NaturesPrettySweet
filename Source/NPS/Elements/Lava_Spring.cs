﻿using Verse;

namespace TKKN_NPS;

public class Lava_Spring : ThingWithComps
{
    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);
        _ = Map;
        _ = map.Biome;
    }
}