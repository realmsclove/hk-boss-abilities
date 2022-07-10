using Satchel;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BossAbilities {
    /*public class NeedleHook : IAbility {
        public string Name => "Needle Hook";
        public AbilityTrigger Trigger => AbilityTrigger.Dash;

        private float THROW_SPEED = 100f;
        private float PULL_SPEED = 75f;

        private GameObject needlePreload;
        private GameObject needle;

        private GameObject thread;

        private AudioSource source;
        private Dictionary<string, AudioClip> audioClips;

        public void Load() {
            needlePreload = BossAbilities.Preloads["GG_Hornet_1"]["Boss Holder/Hornet Boss 1/Needle"];

            source = HeroController.instance.GetComponent<AudioSource>();

            needlePreload.LocateMyFSM("Control").enabled = false;
            needlePreload.RemoveComponent<DamageHero>();

            // Make the needle damage enemies
            needlePreload.layer = 17;

            var enemyDamager = needlePreload.GetAddComponent<DamageEnemies>();
            enemyDamager.attackType = AttackTypes.Nail;
            enemyDamager.circleDirection = true;
            enemyDamager.damageDealt = PlayerData.instance.GetInt(nameof(PlayerData.nailDamage));
            enemyDamager.direction = 180f;
            enemyDamager.ignoreInvuln = false;
            enemyDamager.magnitudeMult = 1;
            enemyDamager.moveDirection = true;
            enemyDamager.specialType = SpecialTypes.None;

            // Get sounds
            var hornet = BossAbilities.Preloads["GG_Hornet_1"]["Boss Holder/Hornet Boss 1"];
            audioClips = Satchel.Futils.Extractors.AudioClips.GetAudioClips(hornet.GetComponent<PlayMakerFSM>());
        }

        public void Perform() {
            if (needle == null) {
                needle = GameObject.Instantiate(needlePreload, HeroController.instance.transform.position, Quaternion.identity);
                thread = needle.Find("Thread");
            }
            
            if (!needle.activeSelf) HeroController.instance.StartCoroutine(ThrowCoroutine());
            else HeroController.instance.StartCoroutine(PullCoroutine());
        }

        private IEnumerator ThrowCoroutine() {
            Vector2 angle = ((Vector2) InputHandler.Instance.inputActions.moveVector).normalized;

            needle.transform.rotation = Quaternion.identity;
            needle.transform.Rotate(new Vector3(0, 0, Mathf.Atan2(-angle.y, -angle.x) * Mathf.Rad2Deg), Space.Self);

            // Raycast to find the target point is (layer 8 is terrain)
            RaycastHit2D hit = Physics2D.Raycast(HeroController.instance.transform.position, angle, Mathf.Infinity, 256);
            if (hit.collider == null) yield break;

            needle.SetActive(true);
            thread.SetActive(false);

            source.PlayOneShot(audioClips["hornet_needle_catch"]);
            
            HeroController.instance.RelinquishControl();
            HeroController.instance.AffectedByGravity(false);

            needle.transform.position = hit.point;

            float time = hit.distance / THROW_SPEED;

            float t = 0;
            while (t < time) {
                needle.transform.position = Vector3.Lerp(HeroController.instance.transform.position, hit.point, Mathf.SmoothStep(0, 1f, t / time));
                t += Time.deltaTime;

                yield return null;
            }

            HeroController.instance.RegainControl();
            HeroController.instance.AffectedByGravity(true);

            // Hold-to-pull
            if (InputHandler.Instance.inputActions.dash.IsPressed) Perform();
        }

        private IEnumerator PullCoroutine() {
            thread.SetActive(true);

            HeroController.instance.RelinquishControl();
            HeroController.instance.AffectedByGravity(false);

            // Move the player off the ground slightly
            HeroController.instance.transform.Translate(new Vector3(0, 0.01f, 0));

            Vector3 startPos = HeroController.instance.transform.position;
            source.PlayOneShot(audioClips["hornet_dash"]);

            float dist = (startPos - needle.transform.position).magnitude;
            float time = dist / PULL_SPEED;

            float t = 0;
            while (t < time) {

                // Move unless it would pass through a terrain collider
                Vector3 oldPos = HeroController.instance.transform.position;
                Vector3 newPos = Vector3.Lerp(startPos, needle.transform.position, Mathf.SmoothStep(0, 1f, t / time));

                if (Physics2D.Linecast(oldPos - new Vector3(0, HeroController.instance.GetComponent<Collider2D>().bounds.size.y / 2, 0), newPos, 1 << 8).collider != null) {
                    // Collided with something, end the pull
                    t = time;
                } else {
                    // Good to go, no collision
                    HeroController.instance.transform.position = newPos;
                }

                // Also another check because this is needed for some reason
                Physics2D.SyncTransforms();
                if (HeroController.instance.GetComponent<Collider2D>().IsTouchingLayers(1 << 8)) {
                    HeroController.instance.transform.position = oldPos;
                    t = time;
                }

                t += Time.deltaTime;

                yield return null;
            }

            HeroController.instance.RegainControl();
            HeroController.instance.AffectedByGravity(true);

            needle.SetActive(false);
        }
    }*/
}