using Satchel;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using System;
using System.Collections;

namespace BossAbilities {
    public class NeedleHook : IAbility {
        public string Name => "Needle Hook";
        public AbilityTrigger Trigger => AbilityTrigger.Dash;

        private GameObject needlePreload;

        public void Load() {

            needlePreload = BossAbilities.Preloads["GG_Hornet_1"]["Boss Holder/Hornet Boss 1/Needle"];
        }

        public void Perform() {
            HeroController.instance.StartCoroutine(AbilityCoroutine());
        }

        private IEnumerator AbilityCoroutine() {
            HeroController.instance.RelinquishControl();
            HeroController.instance.AffectedByGravity(false);

            Vector2 angle = ((Vector2) InputHandler.Instance.inputActions.moveVector).normalized;

            var needle = GameObject.Instantiate(needlePreload, HeroController.instance.transform.position, Quaternion.identity);
            needle.LocateMyFSM("Control").enabled = false;
            needle.RemoveComponent<DamageHero>();
            
            needle.SetActive(true);

            // Wait one frame because TC
            yield return null;

            needle.SetActive(true);
            needle.transform.position = HeroController.instance.transform.position;

            needle.transform.Rotate(new Vector3(0, 0, Mathf.Atan2(-angle.y, -angle.x) * Mathf.Rad2Deg), Space.Self);

            Rigidbody2D rb = needle.GetComponent<Rigidbody2D>();
            rb.velocity = angle * 80f;
            rb.drag = 5f;
            rb.mass = 5f;

            

            yield return new WaitForSeconds(0.25f);

            needle.Find("Thread").SetActive(true);

            // Move the knight the same as the needle
            Rigidbody2D knightRb = HeroController.instance.GetComponent<Rigidbody2D>();
            float drag = knightRb.drag;
            float mass = knightRb.mass;

            knightRb.drag = 1f;
            knightRb.mass = 1f;

            knightRb.velocity = angle * 40f;

            // Wait for the knight to get there
            yield return new WaitForSeconds(0.4f);

            GameObject.Destroy(needle);

            knightRb.drag = drag;
            knightRb.mass = mass;

            HeroController.instance.RegainControl();
            HeroController.instance.AffectedByGravity(true);
        }
    }
}