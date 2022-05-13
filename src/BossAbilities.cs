using System;
using Modding;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BossAbilities {
    public class BossAbilities : Mod {
        public BossAbilities() : base("BossAbilities") {}
        public override string GetVersion() => "v0";

        public static List<IAbility> Abilities;
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
                new TriggerManager().RegisterTriggers();

                foreach(IAbility ability in Abilities) {
                    ability.Load();
                }
            };
        }

        private void LoadAbilities() {
            Abilities = new List<IAbility>();

            // Find all abilities
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes()) {
                if (type.GetInterface("IAbility") != null) {
                    // Type is an ability

                    Abilities.Add(Activator.CreateInstance(type) as IAbility);
                }
            }

            foreach (IAbility ability in Abilities) {
                Log($"Loading ability {ability.Name}!");
                ability.Load();
            }
        }
    }
}