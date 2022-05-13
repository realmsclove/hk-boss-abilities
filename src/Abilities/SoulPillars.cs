using Satchel;
using HutongGames.PlayMaker;
using UnityEngine;
using System;
using System.Collections;

namespace BossAbilities {
    public class SoulPillars : IAbility {
        public string Name => "Soul Pillars";
        public AbilityTrigger Trigger => AbilityTrigger.Quake;

        private GameObject plumePreload;

        public void Load() {
            plumePreload = BossAbilities.Preloads["GG_Hollow_Knight"]["Battle Scene/HK Prime/Stomp Plumes"];
            plumePreload.RemoveComponent<DamageHero>();
        }

        public void Perform() {
            HeroController.instance.StartCoroutine(SpawnPlumes());
        }

        private IEnumerator SpawnPlumes() {
            var plumes = GameObject.Instantiate(plumePreload, HeroController.instance.transform.position, Quaternion.identity);
            plumes.SetActive(true);

            yield return new WaitForSeconds(0.2f);
        }
    }
}