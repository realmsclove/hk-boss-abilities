using Satchel;
using HutongGames.PlayMaker;
using UnityEngine;
using System;
using System.Collections;
using HutongGames.PlayMaker.Actions;
namespace BossAbilities {
    public class SoulPillars : IAbility {
        public string Name => "Soul Pillars";
        public AbilityTrigger Trigger => AbilityTrigger.Quake;

        private GameObject plumePreload;
        private GameObject Pure;
        private AudioClip Audio;
        private int n = 3;
        private float spacing = 5f;
        public void Load() {
            Pure = BossAbilities.Preloads["GG_Hollow_Knight"]["Battle Scene/HK Prime"];
            plumePreload = UnityEngine.Object.Instantiate(Pure.LocateMyFSM("Control").GetAction<SpawnObjectFromGlobalPool>("Plume Gen", 0).gameObject.Value);
            plumePreload.SetActive(false);
            Audio = Pure.LocateMyFSM("Control").GetAction<AudioPlayerOneShotSingle>("Plume Up", 1).audioClip.Value as AudioClip;
            UnityEngine.Object.DontDestroyOnLoad(plumePreload);
            plumePreload.RemoveComponent<DamageHero>();
            plumePreload.layer = 17;
            plumePreload.transform.SetParent(HeroController.instance.transform);
           var damageEnemies = plumePreload.GetAddComponent<DamageEnemies>();
            damageEnemies.attackType = AttackTypes.Spell;
            damageEnemies.circleDirection = true;
            damageEnemies.damageDealt = PlayerData.instance.GetInt(nameof(PlayerData.nailDamage));
            damageEnemies.ignoreInvuln = false;
            damageEnemies.direction = 180f;
            damageEnemies.moveDirection = true;
            damageEnemies.magnitudeMult = 1f;
            damageEnemies.specialType = SpecialTypes.None;
            
        }

        public void Perform() {
            HeroController.instance.StartCoroutine(SpawnPlumes());
        }

        private IEnumerator SpawnPlumes() {
            float x = -1 * ((n * spacing) / 2);
            for (int i = 0; i < n; i++)
            {
                GameObject plume = UnityEngine.Object.Instantiate(plumePreload, HeroController.instance.transform.position - new Vector3(-1f*x, 3f, 0f),Quaternion.identity);
                x += spacing;
                plume.SetActive(true);
            }
            yield return new WaitForSeconds(0.2f);
            HeroController.instance.gameObject.GetComponent<AudioSource>().PlayOneShot(Audio);
        }
    }
}