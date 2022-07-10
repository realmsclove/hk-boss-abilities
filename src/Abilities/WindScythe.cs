using Satchel;
using HutongGames.PlayMaker;
using UnityEngine;

namespace BossAbilities {
    /*public class WindScythe : IAbility {
        public string Name => "Wind Scythe";
        public AbilityTrigger Trigger => AbilityTrigger.Fireball;

        private GameObject scythePreload;

        public void Load() {
            scythePreload = BossAbilities.Preloads["GG_Mantis_Lords"]["Shot Mantis Lord"];
            scythePreload.RemoveComponent<DamageHero>();
        }

        public void Perform() {
            var scythe = GameObject.Instantiate(scythePreload, HeroController.instance.transform.position, Quaternion.identity);
            scythe.SetActive(true);

            // Figure out which scythe mode to do
            string dir = (HeroController.instance.cState.facingRight) ? "L" : "R";
            string type = (PlayerData.instance.equippedCharm_19) ? "WIDE" : "NARROW";

            scythe.LocateMyFSM("Control").SendEvent($"{type} {dir}");
        }
    }*/
}