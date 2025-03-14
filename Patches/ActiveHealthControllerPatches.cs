using acidphantasm_devbalaclavafix.Utils;
using Comfort.Common;
using EFT;
using EFT.HealthSystem;
using EFT.InventoryLogic;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace acidphantasm_devbalaclavafix.Patches
{
    internal class ActiveHealthControllerPatch: ModulePatch
    {
        private static FieldInfo thisPlayer;
        protected override MethodBase GetTargetMethod()
        {
            thisPlayer = AccessTools.Field(typeof(ActiveHealthController), "Player");
            return AccessTools.Method(typeof(ActiveHealthController), nameof(ActiveHealthController.ApplyDamage));
        }

        [PatchPrefix]
        static bool Prefix(ActiveHealthController __instance, EBodyPart bodyPart, float damage, DamageInfoStruct damageInfo)
        {
            Player player = (Player)thisPlayer.GetValue(__instance);
            if (player.IsYourPlayer)
            {
                //Logger.LogInfo("Main Player damaged");

                List<ArmorComponent> armorComponents = new List<ArmorComponent>(20);
                player.Inventory.GetPutOnArmorsNonAlloc(armorComponents);

                using (List<ArmorComponent>.Enumerator enumerator = armorComponents.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.Item.TemplateId == GClass3178.InvincibleBalaclava)
                        {
                            //Logger.LogInfo("Main Player is wearing Dev Balaclava - damage nullified");
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
