using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;
using static UrnofSouls_EquipmentItem.Main;
using System;

namespace UrnofSouls_EquipmentItem.Equipment
{
    class UrnofSoulsItem : EquipmentBase
    {
        public override string EquipmentName => "Urn of Souls";
        public override string EquipmentLangTokenName => "URN_OF_SOULS";
        public override string EquipmentPickupDesc => "Kill enemies for souls, then unleash those souls in a firey burst.";
        public override string EquipmentFullDescription => "Killing an enemy creates an orb that grants soul charges upon pickup. Charges are consumed quickly and do not last long, but have no max capacity.";
        public override string EquipmentLore => "heehoo tboi item go brr";
        public override GameObject EquipmentModel => MainAssets.LoadAsset<GameObject>("UrnofSouls.prefab");
        public override Sprite EquipmentIcon => MainAssets.LoadAsset<Sprite>("UrnofSouls_Icon");
        public byte ActiveEquipmentSlot { get; private set; }

        public static BuffDef SoulChargeBuff;


        private void CreateBuff()
        {
            UrnofSoulsItem.SoulChargeBuff = ScriptableObject.CreateInstance<BuffDef>();
            UrnofSoulsItem.SoulChargeBuff.name = "Urn of Souls: Soul Charges";
            UrnofSoulsItem.SoulChargeBuff.buffColor = Color.white;
            UrnofSoulsItem.SoulChargeBuff.canStack = true;
            UrnofSoulsItem.SoulChargeBuff.isDebuff = false;
            UrnofSoulsItem.SoulChargeBuff.iconSprite = MainAssets.LoadAsset<Sprite>("SoulChargeBuffIcon");
            BuffAPI.Add(new CustomBuff(UrnofSoulsItem.SoulChargeBuff));
        }

        private EquipmentState[] equipmentStateSlots = Array.Empty<EquipmentState>();
        public EquipmentState GetEquipment(uint slot)
        {
            if ((ulong)slot >= (ulong)(long)this.equipmentStateSlots.Length)
            {
                return EquipmentState.empty;
            }
            return this.equipmentStateSlots[(int)slot];
        }
        public override ItemDisplayRuleDict CreateItemDisplayRules()
        {
            return new ItemDisplayRuleDict();
        }
        public void Awake()
        {
            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
        }

        public override void Init(ConfigFile config)
        {
            CreateLang();
            CreateEquipment();
        }
        protected override bool ActivateEquipment(EquipmentSlot slot)
        {
            return false;
        }

        public override void Hooks()
        {
            base.Hooks();
        }
        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            if (equipmentDef == EquipmentDef)
            {
                throw new NotImplementedException();
            }
        }
    }
}
