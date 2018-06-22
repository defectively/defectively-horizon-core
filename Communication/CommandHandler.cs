using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Defectively.Core.Extensibility;

namespace Defectively.Core.Communication
{
    public class CommandHandler
    {
        public delegate Task AsyncCommandAction(string sender, string[] @params);

        private static Dictionary<string, AsyncCommandAction> commandActions = new Dictionary<string, AsyncCommandAction>();

        public static async Task TryExecuteCommand(string sender, string input) {
            var matches = new Regex("\".+\"|[^ ]+").Matches(input);
            var args = new List<string>();

            for (var index = 1; index < matches.Count; index++) {
                args.Add(matches[index].Value.Trim('"'));
            }

            if (commandActions.ContainsKey(matches[0].Value.ToLower())) {
                await commandActions[matches[0].Value.ToLower()].Invoke(sender, args.ToArray());
            }
        }
        
        public static void RegisterCommand(string @namespace, string name, AsyncCommandAction action) {
            commandActions.Add(name.ToLower(), action); // IMPORTANT Add Namespace Detection
        }

        public static void RegisterCommand(Extension extension, string name, AsyncCommandAction action) => RegisterCommand(extension.Namespace, name, action);
    }
}
