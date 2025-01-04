using EFT;
using Comfort.Common;
using EFT.InventoryLogic;
using System.Collections.Generic;

namespace acidphantasm_devbalaclavafix.Utils
{
    public static class MainUtils
    {
        public static List<ArmorComponent> mainPlayerComponents;
        public static Player GetMainPlayer()
        {
            var gameWorld = Singleton<GameWorld>.Instance;
            return gameWorld?.MainPlayer;
        }
        public static bool IsGroupedWithMainPlayer(this Player player)
        {
            var mainPlayerGroupId = GetMainPlayer().GroupId;
            return !string.IsNullOrEmpty(mainPlayerGroupId) && player.GroupId == mainPlayerGroupId;
        }
    }
}
