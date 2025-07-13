﻿using UnityEngine;
using Verse;

namespace Infused
{
    public class Settings : ModSettings
    {
        public static int max = 5;
        public static float mult = 1f;
        public static float bias = 0.5f;

        public static float weight_artifact = 0.03175f;
        public static float weight_legendary = 0.0625f;
        public static float weight_epic = 0.125f;
        public static float weight_rare = 0.25f;
        public static float weight_uncommon = 0.50f;

        public static void DoSettingsWindowContents(Rect rect)
        {
            Listing_Standard list = new Listing_Standard(GameFont.Small);
            list.Begin(rect);
            list.ColumnWidth = 88f;
            list.IntAdjuster(ref max, 1, 1);
            list.NewColumn();
            list.ColumnWidth = rect.width - 84f;
            list.Label(new TaggedString(ResourceBank.Strings.SettingsMaxSlots + ": " + max), -1, ResourceBank.Strings.SettingsMaxSlotsDesc);
            list.End();

            rect.yMin = rect.y + list.CurHeight;

            list.Begin(rect);
            list.ColumnWidth = rect.width;
            list.GapLine();
            list.Label(new TaggedString(ResourceBank.Strings.SettingsMultiplier + ": " + mult.ToString("0.00")), -1, ResourceBank.Strings.SettingsMultiplierDesc);
            mult = list.Slider(mult, 0.05f, 4f);
            list.Label(new TaggedString(ResourceBank.Strings.SettingsBias + ": " + bias.ToString("0.00")), -1, ResourceBank.Strings.SettingsBiasDesc);
            bias = list.Slider(bias, 0.01f, 6f);
            list.GapLine();
            list.Label(new TaggedString(ResourceBank.Strings.SettingsTierCurve), -1, ResourceBank.Strings.SettingsTierCurveDesc);
            list.End();

            rect.yMin = rect.y + list.CurHeight;

            list.Begin(rect);
            list.ColumnWidth = 75f;
            list.Label(new TaggedString(ResourceBank.Strings.Artifact), -1f, null);
            list.Label(new TaggedString(ResourceBank.Strings.Legendary), -1f, null);
            list.Label(new TaggedString(ResourceBank.Strings.Epic), -1f, null);
            list.Label(new TaggedString(ResourceBank.Strings.Rare), -1f, null);
            list.Label(new TaggedString(ResourceBank.Strings.Uncommon), -1f, null);
            list.Label(new TaggedString(ResourceBank.Strings.Common), -1f, null);
            list.NewColumn();
            list.ColumnWidth = rect.width - 150f;
            weight_artifact = list.Slider(weight_artifact, 0f, 1f);
            weight_legendary = list.Slider(weight_legendary, 0f, 1f);
            weight_epic = list.Slider(weight_epic, 0f, 1f);
            weight_rare = list.Slider(weight_rare, 0f, 1f);
            weight_uncommon = list.Slider(weight_uncommon, 0f, 1f);
            list.Slider(0.99f, 0f, 1f);
            list.NewColumn();
            list.ColumnWidth = 75f;
            list.Label(new TaggedString(weight_artifact.ToStringPercent()), -1f, null);
            list.Label(new TaggedString(weight_legendary.ToStringPercent()), -1f, null);
            list.Label(new TaggedString(weight_epic.ToStringPercent()), -1f, null);
            list.Label(new TaggedString(weight_rare.ToStringPercent()), -1f, null);
            list.Label(new TaggedString(weight_uncommon.ToStringPercent()), -1f, null);
            list.Label(new TaggedString((1f).ToStringPercent()), -1f, null);
            list.End();

            rect.yMin = rect.y + list.CurHeight;

            list.Begin(rect);
            list.ColumnWidth = rect.width;
            list.GapLine();
            GUI.color = ResourceBank.Colors.Common;
            list.Label(new TaggedString(ResourceBank.Strings.SettingsExtra), -1f, null);
            GUI.color = Color.white;
            list.End();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref max, "SlotsMax", 5);
            Scribe_Values.Look(ref mult, "ChanceMult", 1f);
            Scribe_Values.Look(ref bias, "ChanceBias", 0.5f);

            Scribe_Values.Look(ref weight_artifact, "WeightArtifact", 0.03175f);
            Scribe_Values.Look(ref weight_legendary, "WeightLegendary", 0.0625f);
            Scribe_Values.Look(ref weight_epic, "WeightEpic", 0.125f);
            Scribe_Values.Look(ref weight_rare, "WeightRare", 0.25f);
            Scribe_Values.Look(ref weight_uncommon, "WeightUncommon", 0.50f);
        }
    }
}
