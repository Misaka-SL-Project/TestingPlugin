using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using RemoteAdmin;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Toys;
using Exiled.API.Features.Items;
using Exiled.API.Enums;
using Exiled.API.Extensions;

namespace TestingPlugin
{

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class LightCommand : ICommand
    {
        public string Command { get; } = "light";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "adds light";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            Light light = Light.Create(player.Position);
            LightList.lights.Add(light);
            response = null;
            return true;
        }
    }
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class LightRangeCommand : ICommand
    {
        public string Command { get; } = "range";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "change light range";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            foreach(Light light in LightList.lights)
            {
                light.Range = (float)Convert.ToInt32(arguments.ElementAt(0));
            }
            response = null;
            return true;
        }
    }
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class DeleteLightCommand : ICommand
    {
        public string Command { get; } = "delete";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "delete light";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            int index = Convert.ToInt32(arguments.ElementAt(0));
            LightList.lights[index].Destroy();
            LightList.lights.RemoveAt(index);
            response = null;
            return true;
        }
    }
    [CommandHandler(typeof (RemoteAdminCommandHandler))]
    public class Items : ICommand
    {
        public string Command { get; } = "ItemCount";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Count items";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Stopwatch stopwatch = new Stopwatch();
            Player player = Player.Get(sender);
            stopwatch.Start();
            bool str = player.Items.Count == 0;
            stopwatch.Stop();
            TimeSpan timeTaken = stopwatch.Elapsed;
            response = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff") + str;
            return true;

        }
    }
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Cooldown : ICommand
    {
        public string Command { get; } = "custominfocolor";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            Misc.TryParseColor("Red", out UnityEngine.Color32 color);
            player.CustomInfo = $"<color={color}>Red CustomInfo</color>";
            response = "";
            return true;

        }
    }
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Handcuff : ICommand
    {
        public string Command { get; } = "handcuff";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            player.Handcuff();
            response = "";
            return true;
        }
    }
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class IntercomReset : ICommand
    {
        public string Command { get; } = "IntercomReset";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Intercom.host.remainingCooldown = -1f;
            response = "";
            return true;
        }
    }
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class IntercomCD : ICommand
    {
        public string Command { get; } = "IntercomCD";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Intercom.host.remainingCooldown = Convert.ToInt32(arguments.ElementAt(0));
            response = "";
            return true;
        }
    }
    public class LightList
    {
        public static List<Light> lights = new List<Light>();
    }
}
