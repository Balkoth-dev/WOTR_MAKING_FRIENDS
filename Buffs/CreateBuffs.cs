using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class CreateBuffs
    {
        public static void CreateAllBuffs()
        {
            CreateDummyBuff();
            SummonStampedeBuffs.CreateStampedeTrampleDamageImmunityBuff();
            SummonStampedeBuffs.CreateStampedeAttackBuff();
            ReleaseTheHoundsBuffs.CreateReleaseTheHoundsBuff();
            BlackTentaclesBuffs.CreateBlackTentaclesBuff();
            OverstimulateBuff.CreateOverstimulateBuff();
            SummonerLifeLinkBuff.CreateSummonerLifeLinkBuff();
        }

        private static void CreateDummyBuff()
        {
            BuffConfigurator.New("dummyBuff", GetGUID.DummyBuff).Configure();
        }
    }
}
