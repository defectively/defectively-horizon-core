using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Defectively.Core.Extensibility
{
    public class ExtensionManager
    {
        public static List<Extension> Extensions { get; } = new List<Extension>();

        public static void InitializeExtension(string path, bool isServerside) {
            if (File.Exists(path) && new FileInfo(path).Extension == ".dll") {
                Assembly.LoadFile(path);
                var assemblyTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => typeof(Extension).IsAssignableFrom(t) && t.IsClass).ToArray();

                foreach (var type in assemblyTypes) {
                    if (type.Attributes.HasFlag(TypeAttributes.Abstract))
                        continue;

                    var extension = (Extension) Activator.CreateInstance(type);
                    extension.ExtensionPath = path;

                    if (Extensions.Any(e => e.Namespace == extension.Namespace)) {
                        extension = null;
                        continue;
                    }

                    extension.OnInitialize(isServerside);

                    if (isServerside) {
                        EventService.RegisterServerListeners(extension);
                    } else {
                        EventService.RegisterClientListeners(extension);
                    }

                    Extensions.Add(extension);
                }
            }
        }
    }
}