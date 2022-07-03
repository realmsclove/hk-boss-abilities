

namespace BossAbilities {
    public interface IAbility {

        public string abilityReplaced { get; }
        public bool canUse { get; set; }
    }
}