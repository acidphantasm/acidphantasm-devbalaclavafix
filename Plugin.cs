using acidphantasm_devbalaclavafix.Patches;
using BepInEx;

namespace acidphantasm_devbalaclavafix
{
    [BepInPlugin("com.acidphantasm.devbalaclavafix", "acidphantasm-DevBalaclavaFix", "1.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("[DevBalaclavaFix] loading...");

            new ActiveHealthControllerPatch().Enable();

            Logger.LogInfo("[DevBalaclavaFix] loaded!");
        }
    }
}