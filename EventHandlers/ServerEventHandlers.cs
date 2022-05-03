using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using MEC;
using Exiled.API.Extensions;
using Exiled.API.Enums;
using UnityEngine;


namespace EventHandlers
{
    public class ServerEventHandlers
    {
        public static CoroutineHandle coroutine;

        private static void Server_RoundStarted()
        {
            Log.Info("Round started");  
        }    

        public static void OnEnabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted += Server_RoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers += Server_WaitingForPlayers;
        }

        private static void Server_WaitingForPlayers()
        {

        }
        public static void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= Server_RoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= Server_WaitingForPlayers;
            Timing.KillCoroutines(coroutine);
        }
    }
}
