
namespace BossAbilities {
    public interface IAbility {
        string Name { get; }
        AbilityTrigger Trigger { get; }
    
        void Load();
        void Perform();
    }
}