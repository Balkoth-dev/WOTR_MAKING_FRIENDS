using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class CreateBuffs
    {
        public static void CreateAllBuffs()
        {
            CreateDummyBuff();
            BuffSummonStampede.CreateStampedeTrampleDamageImmunityBuff();
            BuffSummonStampede.CreateStampedeAttackBuff();
            BuffReleaseTheHounds.CreateReleaseTheHoundsBuff();
            BuffBlackTentacles.CreateBlackTentaclesBuff();
            BuffOverstimulate.CreateOverstimulateBuff();
            BuffSummonerLifeLink.CreateSummonerLifeLinkBuff();
            BuffSummonerShieldAlly.CreateShieldAllyBuffs();
            BuffSummonerShieldAllyGreater.CreateShieldAllyGreaterBuffs();
            BuffSummonerLifeBond.CreateSummonerLifeBondBuff();
        }

        private static void CreateDummyBuff()
        {
            BuffConfigurator.New("dummyBuff", GetGUID.DummyBuff).Configure();
        }
    }
}
