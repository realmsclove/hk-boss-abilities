using System;
using Modding;
using System.Collections.Generic;
using System.Reflection;
using On;
using UnityEngine;

namespace BossAbilities {
    public class BossAbilities : Mod {
        public BossAbilities() : base("BossAbilities") {}
        public override string GetVersion() => "v0";

        private List<IAbility> abilities;
        public static Dictionary<string, Dictionary<string, GameObject>> Preloads;

        // @TODO: have abilities declare the preloads they need and collect them here
        public override List<(string, string)> GetPreloadNames() => new List<(string, string)> {
            ("GG_Mantis_Lords", "Shot Mantis Lord")
        };

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects) {
            Preloads = preloadedObjects;
            LoadAbilities();

            On.HeroController.Awake += delegate(On.HeroController.orig_Awake orig, HeroController self) {
                orig.Invoke(self);

                foreach(IAbility ability in abilities) {
                    ability.Load();
                }
            };
        }

        private void LoadAbilities() {
            abilities = new List<IAbility>();

            // Find all abilities
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes()) {
                if (type.GetInterface("IAbility") != null) {
                    // Type is an ability

                    abilities.Add(Activator.CreateInstance(type) as IAbility);
                }
            }

            foreach (IAbility ability in abilities) {
                Log($"Loading ability {ability.Name}!");
                ability.Load();
            }
        }
    }
}