﻿using Assets.Scripts.Models;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Simulation.Towers;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD6_Random_Monkeys_5_5_5.Events;
using BTD6_Random_Monkeys_5_5_5.MonkeysRandomGenerator;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

namespace BTD6_Random_Monkeys_5_5_5.BloonsMod
{
    class Main : BloonsTD6Mod
    {
        bool FirstLoaded = true;

        public override string MelonInfoCsURL => "https://raw.githubusercontent.com/GMConio/BTD6Mods/main/BTD6RandomMonkeys555/Properties/AssemblyInfo.cs";

        public override string LatestURL => "https://github.com/GMConio/BTD6Mods/blob/main/BTD6RandomMonkeys555/BTD6RandomMonkeys555.dll?raw=true";

        public static readonly ModSettingBool EnableMod = true;
        public static readonly ModSettingBool EnableSeed = false;

        internal static readonly ModSettingInt Seed = 0;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            EnableMod.OnValueChanged.Add(ModSettingEvents.ChangedStateMod);
            EnableSeed.OnValueChanged.Add(ModSettingEvents.ChangedBooleanSeed);
            Seed.OnValueChanged.Add(ModSettingEvents.ChangedSeed);

            MelonLogger.Msg("Mod BTD6_Random_Monkeys 5_5_5 Loaded!");
        }

        public override void OnMainMenu()
        {
            base.OnMainMenu();

            if (FirstLoaded)
            {
                FirstLoaded = false;
            }
        }
    }

    [HarmonyPatch(typeof(Tower), "Initialise")]
    public class TowerInitialise_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(Tower __instance, ref Model modelToUse)
        {
            if (modelToUse.name.Contains("Tier") && Main.EnableMod)
            {
                if (modelToUse.name.Contains("Tier_0"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModelTier0();
                }
                else if (modelToUse.name.Contains("Tier_1_1"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel__x(1);
                }
                else if (modelToUse.name.Contains("Tier_1_x"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel_xx(1);
                }
                else if (modelToUse.name.Contains("Tier_2_2"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel__x(2);
                }
                else if (modelToUse.name.Contains("Tier_2_x"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel_xx(2);
                }
                else if (modelToUse.name.Contains("Tier_3_3"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel__x(3);
                }
                else if (modelToUse.name.Contains("Tier_3_x"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel_xx(3);
                }
                else if (modelToUse.name.Contains("Tier_4_4"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel__x(4);
                }
                else if (modelToUse.name.Contains("Tier_4_x"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel_xx(4);
                }
                else if (modelToUse.name.Contains("Tier_5_5"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel__x(5);
                }
                else if (modelToUse.name.Contains("Tier_5_x"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel_xx(5);
                }
                else if (modelToUse.name.Contains("Tier_Random_Lite"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModelRandomLite();
                }
                else if (modelToUse.name.Contains("Tier_Random"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModelRandom();
                }
            }
            return true;
        }
    }

    /*[HarmonyPatch(typeof(TowerInventory), "Init")]
    public class TowerInventory_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref List<TowerDetailsModel> allTowersInTheGame)
        {
            if (Main.EnableMod)
            {
                if (allTowersInTheGame[31].towerId == "BananaFarm" && allTowersInTheGame.Count == 48)
                {
                    var supportMonkeys = allTowersInTheGame.GetRange(31, 17);
                    allTowersInTheGame.RemoveRange(31, 17);

                    allTowersInTheGame.Add(supportMonkeys[4]);
                    allTowersInTheGame.Add(supportMonkeys[6]);
                    allTowersInTheGame.Add(supportMonkeys[5]);
                    allTowersInTheGame.Add(supportMonkeys[8]);
                    allTowersInTheGame.Add(supportMonkeys[7]);
                    allTowersInTheGame.Add(supportMonkeys[10]);
                    allTowersInTheGame.Add(supportMonkeys[9]);
                    allTowersInTheGame.Add(supportMonkeys[12]);
                    allTowersInTheGame.Add(supportMonkeys[11]);
                    allTowersInTheGame.Add(supportMonkeys[14]);
                    allTowersInTheGame.Add(supportMonkeys[13]);
                    allTowersInTheGame.Add(supportMonkeys[16]);
                    allTowersInTheGame.Add(supportMonkeys[15]);

                    allTowersInTheGame.Add(supportMonkeys[0]);
                    allTowersInTheGame.Add(supportMonkeys[1]);
                    allTowersInTheGame.Add(supportMonkeys[2]);
                    allTowersInTheGame.Add(supportMonkeys[3]);
                }
            }
            else
            {
                if (allTowersInTheGame[31].towerId == "BananaFarm" && allTowersInTheGame.Count == 48)
                {
                    allTowersInTheGame.RemoveRange(35, 13);
                }
            }
            return true;
        }
    }*/
}

