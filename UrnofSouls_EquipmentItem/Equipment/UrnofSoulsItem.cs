﻿using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;
using static UrnofSouls_EquipmentItem.Main;

namespace UrnofSouls_EquipmentItem.Equipment
{
    class UrnofSoulsItem : EquipmentBase
    {
        public override string EquipmentName => "Urn of Souls";

        public override string EquipmentLangTokenName => "URN_OF_SOULS";

        public override string EquipmentPickupDesc => "Kill enemies for souls, then unleash those souls in a firey stream.";

        public override string EquipmentFullDescription => "Killing an enemy grants one soul charge. A soul charge creates a stream of fire that lasts for .85 seconds per charge, which fire continously until either it's manually cancelled, or the souls are depleted. Max of 25.";

        public override string EquipmentLore => "heehoo tboi item go brr";

        public override GameObject EquipmentModel => MainAssets.LoadAsset<GameObject>("UrnofSouls.prefab");

        public override Sprite EquipmentIcon => MainAssets.LoadAsset<Sprite>("UrnofSoulsIcon.jpeg");

        public override ItemDisplayRuleDict CreateItemDisplayRules()
        {
            return new ItemDisplayRuleDict();
        }

        public override void Init(ConfigFile config)
        {

        }

        protected override bool ActivateEquipment(EquipmentSlot slot)
        {
            Chat.AddMessage("You used the equipment, yay");
            return false;
        }
    }
}