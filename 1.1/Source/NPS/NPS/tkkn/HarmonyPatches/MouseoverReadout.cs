﻿using System;
using Verse;
using HarmonyLib;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace TKKN_NPS
{


	[HarmonyPatch(typeof(MouseoverReadout))]
	[HarmonyPatch("MouseoverReadoutOnGUI")]
	class PatchMouseoverReadout
	{
		static void Postfix()
		{
			IntVec3 c = UI.MouseCell();
			Map map = Find.CurrentMap;
			if (!c.InBounds(map))
			{
				return;
			}
			Rect rect;
			Vector2 BotLeft = new Vector2(15f, 65f);
			float num = 38f;
			Zone zone = c.GetZone(map);
			if (zone != null)
			{
				num += 19f;
			}
			float depth = map.snowGrid.GetDepth(c);
			if (depth > 0.03f)
			{
				num += 19f;
			}
			List<Thing> thingList = c.GetThingList(map);
			for (int i = 0; i < thingList.Count; i++)
			{
				Thing thing = thingList[i];
				if (thing.def.category != ThingCategory.Mote)
				{
					num += 19f;
				}
			}
			RoofDef roof = c.GetRoof(map);
			if (roof != null)
			{
				num += 19f;
			}
			if (Settings.showDevReadout)
			{
				rect = new Rect(BotLeft.x, (float)UI.screenHeight - BotLeft.y - num, 999f, 999f);
				string label3 = "C: x-" + c.x.ToString() + " y-" + c.y.ToString() + " z-" + c.z.ToString();
				Widgets.Label(rect, label3);
				num += 19f;

				Watcher watcher = map.GetComponent<Watcher>();
				cellData cell = watcher.cellWeatherAffects[c];
				if (cell == null)
				{
					return;
				}
				rect = new Rect(BotLeft.x, (float)UI.screenHeight - BotLeft.y - num, 999f, 999f);
				string label2 = "Temperature: " + cell.temperature + " Rain Rate:" + map.weatherManager.curWeather.rainRate + " Humidity:" + watcher.humidity;
				Widgets.Label(rect, label2);
				num += 19f;

				rect = new Rect(BotLeft.x, (float)UI.screenHeight - BotLeft.y - num, 999f, 999f);
				string label5 = "Cell Info: Base Terrain " + cell.baseTerrain.defName + " Current Terrain " + cell.currentTerrain.defName + " HowWet " + cell.howWet.ToString() + " | How Packed " + cell.howPacked.ToString();

				if (cell.weather != null)
				{
					if (cell.weather.wetTerrain != null)
					{
						label5 += " | T Wet " + cell.weather.wetTerrain.defName;
					}
					if (cell.weather.dryTerrain != null)
					{
						label5 += " | T Dry " + cell.weather.dryTerrain.defName;
					}
					if (cell.weather.freezeTerrain != null)
					{
						label5 += " | T Freeze " + cell.weather.freezeTerrain.defName;
					}
				}
				if (cell.originalTerrain != null)
				{
					label5 += " | Orig Terrain " + cell.originalTerrain.defName;
				}
				Widgets.Label(rect, label5);
				num += 19f;

				rect = new Rect(BotLeft.x, (float)UI.screenHeight - BotLeft.y - num, 999f, 999f);
				string label6 = "TKKN_Wet " + cell.currentTerrain.HasTag("TKKN_Wet") + "TKKN_Swim " + cell.currentTerrain.HasTag("TKKN_Swim");
				Widgets.Label(rect, label6);
				num += 19f;
				



			}


			depth = map.GetComponent<FrostGrid>().GetDepth(c);
			if (depth > 0.01f)
			{
				rect = new Rect(BotLeft.x, (float)UI.screenHeight - BotLeft.y - num, 999f, 999f);
				FrostCategory frostCategory = FrostUtility.GetFrostCategory(depth);
				string label2 = FrostUtility.GetDescription(frostCategory);
				Widgets.Label(rect, label2);
			//	Widgets.Label(rect, label2 + " " + depth.ToString());
				num += 19f;
			}

		}
	}
}

