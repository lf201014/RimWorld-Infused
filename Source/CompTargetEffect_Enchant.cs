using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace Infused
{
    public class CompTargetEffect_Enchant : CompTargetEffect
    {
        public override void DoEffectOn(Pawn user, Thing target)
        {
            float hp = (float)target.HitPoints / target.MaxHitPoints;

            CompInfused infused = target.TryGetComp<CompInfused>();

            var toTranfer = parent.GetComp<CompInfused>().Infusions.ToList();
            if (toTranfer.NullOrEmpty())
            {
                List<Def> list = infused.RemoveRandom(Rand.Range(1, Settings.max));
                Thing amplifier = ThingMaker.MakeThing(ResourceBank.Things.InfusedAmplifier);
                infused = amplifier.TryGetComp<CompInfused>();
                infused.SetInfusions(list);
                amplifier.HitPoints = amplifier.MaxHitPoints;
                if (!GenPlace.TryPlaceThing(amplifier, parent.Position, parent.Map, ThingPlaceMode.Near))
                {
                    Log.Error($"Could not drop new amplifier near {parent.Position}");
                }
            }
            else
            {
                foreach (Def infusion in toTranfer)
                {
                    infused.Attach(infusion);
                }
            }

            // Use GetStatValue to force proper stat calculation with new infusions
            int newMaxHitPoints = Mathf.RoundToInt(target.GetStatValue(StatDefOf.MaxHitPoints));
            int newHitPoints = Mathf.FloorToInt(newMaxHitPoints * hp);
            target.HitPoints = newHitPoints;

            infused.ThrowMote();
        }
    }
}
