using Satchel;
using HutongGames.PlayMaker;

namespace BossAbilities {

    public enum AbilityTrigger {
        Fireball,
        Quake
    }

    public class TriggerManager {
        public void RegisterTriggers() {
            // Shade Soul
            FsmState castShadeSoul = HeroController.instance.spellControl.GetState("Fireball 2");
            castShadeSoul.RemoveAction(3);
            castShadeSoul.InsertCustomAction("Fireball 2", () => HandleTrigger(AbilityTrigger.Fireball), 3);

            // Descending Dark
            HeroController.instance.spellControl.GetState("Q2 Land").InsertCustomAction("Q2 Land", () => HandleTrigger(AbilityTrigger.Quake), 13);
        }

        private void HandleTrigger(AbilityTrigger trigger) {
            foreach (IAbility ability in BossAbilities.Abilities) {
                if (ability.Trigger == trigger) ability.Perform();
            }
        }
    }
}