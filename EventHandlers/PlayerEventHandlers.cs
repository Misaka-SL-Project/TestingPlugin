using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.Handlers;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using Exiled.API.Features.Items;
using InventorySystem.Items;
using InventorySystem.Items.Usables;
using InventorySystem.Items.Usables.Scp244;
using Mirror;

namespace EventHandlers
{
    public class PlayerEventHandlers
    {
        public static void OnEnabled()
        {
            Exiled.Events.Handlers.Player.DroppingItem += Player_DroppingItem;
            Exiled.Events.Handlers.Player.UsingItem += Player_UsingItem;
            Exiled.Events.Handlers.Player.Dying += Player_Dying;
        }

        private static void Player_Dying(DyingEventArgs ev)
        {
            Log.Info("Dying event called");
            ev.IsAllowed = false;
        }

        private static void Player_UsingItem(UsingItemEventArgs ev)
        { 
        }

        private static void Player_DroppingItem(DroppingItemEventArgs ev)
        {

        }


        private void Player_Spawning(SpawningEventArgs ev)
        {

        }
        public static void OnDisabled()
        {
            Exiled.Events.Handlers.Player.DroppingItem -= Player_DroppingItem;
            Exiled.Events.Handlers.Player.UsingItem -= Player_UsingItem;
            Exiled.Events.Handlers.Player.Dying -= Player_Dying;
        }
    }
}
