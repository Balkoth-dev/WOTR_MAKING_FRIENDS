using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Portraits
{
    internal class PortraitEidolonAstradaemon
    {
        public static void Create()
        {
            var portrait = PortraitConfigurator.New("EidolonAstradaemonPortrait", GetGUID.GUIDByName("EidolonAstradaemonPortrait"))
                .CopyFrom(BlueprintTool.GetRef<BlueprintPortraitReference>("507f0248c7a4e2b4bada154861c374b1"))
                .ConfigureWithLogging();

            SmallPortraitInjector.Replacements[portrait.Data] = AssetLoader.LoadInternal("Portraits", "AstradaemonSmall.png", 185, 242);
            HalfPortraitInjector.Replacements[portrait.Data] = AssetLoader.LoadInternal("Portraits", "AstradaemonMedium.png", 330, 432);
            FullPortraitInjector.Replacements[portrait.Data] = AssetLoader.LoadInternal("Portraits", "AstradaemonFulllength.png", 692, 1024);
            EyePortraitInjector.Replacements[portrait.Data] = AssetLoader.LoadInternal("Portraits", "DefaultEyePortrait.png", 176, 24);
        }
    }
}
