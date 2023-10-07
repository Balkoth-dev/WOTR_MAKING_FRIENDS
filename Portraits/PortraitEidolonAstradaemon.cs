using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Portraits
{
    internal class PortraitEidolonAstradaemon
    {
        public static void Create()
        {
            var portrait = PortraitConfigurator.New("EidolonAstradaemonPortrait", GetGUID.GUIDByName("EidolonAstradaemonPortrait"))
                .SetData(new PortraitData())
                .ConfigureWithLogging();

            SmallPortraitInjector.Replacements[portrait.Data] = AssetLoader.LoadInternal("Portraits", "AstradaemonSmall.png", 185, 242);
            HalfPortraitInjector.Replacements[portrait.Data] = AssetLoader.LoadInternal("Portraits", "AstradaemonMedium.png", 330, 432);
            FullPortraitInjector.Replacements[portrait.Data] = AssetLoader.LoadInternal("Portraits", "AstradaemonFulllength.png", 692, 1024);
            EyePortraitInjector.Replacements[portrait.Data] = AssetLoader.LoadInternal("Portraits", "DefaultEyePortrait.png", 176, 24);
        }
    }
}
