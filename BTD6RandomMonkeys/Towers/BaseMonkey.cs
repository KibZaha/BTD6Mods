﻿using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using RandomMonkeys.Display;
using RandomMonkeys.Set;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.TowerSets;
using Harmony;
using HarmonyLib;
using Il2CppSystem.Dynamic.Utils;

namespace RandomMonkeys.Towers
{
    abstract class BaseMonkey : ModTower<RandomMonkeysSet>
    {
        public override string BaseTower => TowerType.SniperMonkey;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override bool DontAddToShop => true;
        public override string Icon => IconName + "-Icon";
        public override string Portrait => IconName + "-Icon";

        public abstract override string Description { get; }
        public abstract override int Cost { get; }
        public abstract override string DisplayName { get; }

        protected abstract string IconName { get; }
        protected abstract int Index { get; }

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            //Il2CppStructArray<AreaType> newAreaType = new Il2CppStructArray<AreaType>(2);

            //newAreaType[0] = AreaType.land;
            //newAreaType[1] = AreaType.water;

            //towerModel.areaTypes = newAreaType;

            towerModel.ApplyDisplay<RandomDisplay>();
        }

        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.Find(tower => tower.name.Contains("EngineerMonkey")).towerIndex + Index;
        }
    }
}