using acidphantasm_devbalaclavafix.Patches;
using BepInEx;

namespace acidphantasm_devbalaclavafix
{
    [BepInPlugin("phantasm.acid.devbalaclavafix", "acidphantasm-DevBalaclavaFix", "1.0.0")]
    [BepInDependency("com.SPT.core", "3.10.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("[DevBalaclavaFix] loading...");

            new ApplyDamageInfoPrefixPatch().Enable();

            Logger.LogInfo("[DevBalaclavaFix] loaded!");
        }
    }
}