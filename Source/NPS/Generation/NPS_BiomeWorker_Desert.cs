﻿using RimWorld;
using RimWorld.Planet;
using Verse;

namespace TKKN_NPS;

internal class NPS_BiomeWorker_Desert : BiomeWorker_Desert
{
    public override float GetScore(Tile tile, int id)
    {
        if (!(base.GetScore(tile, id) > 0))
        {
            return 0f;
        }

        if (Rand.Value > .006)
        {
            return 0f;
        }

        return tile.temperature + 15;
    }
}

/*
class NPS_BiomeWorker_Sequioa : BiomeWorker_TemperateForest
{
    public override float GetScore(Tile tile)
    {
        if (tile.WaterCovered)
        {
            return -100f;
        }
        if (tile.temperature < -10.0)
        {
            return 0f;
        }
        if (tile.rainfall < 600.0)
        {
            return 0f;
        }

        if (Rand.Value > .0001)
        {
            return 0f;
        }
        return (float)(16.0 + (tile.temperature - 7.0) + (tile.rainfall - 600.0) / 180.0);
    }
}
*/
/*
class NPS_BiomeWorker_AridShrubland : BiomeWorker_AridShrubland
{
    public override float GetScore(Tile tile)
    {
        //keep this the same, just make it fail more often. When it fails, shrubland will be rendered, instead.
        if (tile.WaterCovered)
        {
            return -100f;
        }
        if (tile.temperature < -10f)
        {
            return 0f;
        }
        if (tile.rainfall < 600f || tile.rainfall >= 2000f)
        {
            return 0f;
        }

        if (g.passOrFail(19))
        {

            return 0f; ;
        }

        return 22.5f + (tile.temperature - 20f) * 2.2f + (tile.rainfall - 600f) / 100f;
    }
}
*/