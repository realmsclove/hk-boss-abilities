using Satchel;
using HutongGames.PlayMaker;

namespace BossAbilities {

    public enum AbilityTrigger {
        Fireball
    }

    public class TriggerManager {
        public void RegisterTriggers() {
            // Shade Soul
            FsmState state = HeroController.instance.spellControl.GetState("Fireball 2");
            state.RemoveAction(3);
            state.InsertCustomAction("Fireball 2", () => HandleTrigger(AbilityTrigger.Fireball), 3);
        }

        private void HandleTrigger(AbilityTrigger trigger) {
            foreach (IAbility ability in BossAbilities.Abilities) {
                if (ability.Trigger == trigger) ability.Perform();
            }
        }
    }
}