using EFT.Interactive;
using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using acidphantasm_devbalaclavafix.Utils;
using EFT.InventoryLogic;
using System.Collections.Generic;

namespace acidphantasm_devbalaclavafix.Patches
{
    internal class ApplyDamageInfoPrefixPatch : ModulePatch
    {
        private static FieldInfo preAllocatedArmorComponents;
        protected override MethodBase GetTargetMethod()
        {
            preAllocatedArmorComponents = AccessTools.Field(typeof(Player), "_preAllocatedArmorComponents");
            return AccessTools.Method(typeof(Player), nameof(Player.ApplyDamageInfo));
        }

        [PatchPrefix]
        static bool Prefix(Player __instance)
        {
            if ((__instance.IsYourPlayer || MainUtils.IsGroupedWithMainPlayer(__instance)))
            {
                List<ArmorComponent> thisArmorComponents = (List<ArmorComponent>)preAllocatedArmorComponents.GetValue(__instance);

                using (List<ArmorComponent>.Enumerator enumerator = thisArmorComponents.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.Item.TemplateId == GClass3107.InvincibleBalaclava)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
