﻿using Verse;
using System.Collections.Generic;

namespace TKKN_NPS
{
	class ThingWeatherReaction : DefModExtension
	{
		public string frostGraphicPath;
		public string snowGraphicPath;
		public string frostLeaflessGraphicPath;
		public string snowLeaflessGraphicPath;
		public Graphic frostGraphicData;

		public List<TerrainDef> allowedTerrains;
		
	}
}
