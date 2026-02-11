using acidphantasm_devbalaclavafix.Patches;
using BepInEx;

namespace acidphantasm_devbalaclavafix
{
    [BepInPlugin("com.acidphantasm.devbalaclavafix", "acidphantasm-DevBalaclavaFix", "1.1.1")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            new ActiveHealthControllerPatch().Enable();
        }
    }
}