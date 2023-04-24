using BlueprintCore.Blueprints.CustomConfigurators;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WOTR_MAKING_FRIENDS.Utilities
{
    public static class RootConfiguratorExtensions
    {
        public static T ConfigureWithLogging<T, TBuilder>(this RootConfigurator<T, TBuilder> configurator, bool patch = false)
            where T : BlueprintScriptableObject
            where TBuilder : RootConfigurator<T, TBuilder>
        {
            // Use reflection to access the protected fields of the original RootConfigurator object
            var blueprintField = typeof(RootConfigurator<T, TBuilder>).GetField("Blueprint", BindingFlags.Instance | BindingFlags.NonPublic);

            var blueprint = (T)blueprintField.GetValue(configurator);

            if (patch)
            {
                Main.Log("Patching " + blueprint.name + " : " + blueprint.AssetGuid);
            }
            else 
            { 
                Main.Log("Configuring " + blueprint.name + " : " + blueprint.AssetGuid);
            }

            return configurator.Configure();
        }
    }
}
