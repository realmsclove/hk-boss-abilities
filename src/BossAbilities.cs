using System;
using Modding;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static AbilityChanger.AbilityChanger;

namespace BossAbilities {
    public class BossAbilities : Mod {
        public BossAbilities() : base("BossAbilities") {}
        public override string GetVersion() => "v0";

        public static List<IAbility> Abilities= new();
        public static Dictionary<string, Dictionary<string, GameObject>> Preloads;

        public static BossAbilities instance;
        // @TODO: have abilities declare the preloads they need and collect them here
        public override List<(string, string)> GetPreloadNames() => new()
        {
            ("GG_Mantis_Lords", "Shot Mantis Lord"),
            ("GG_Hollow_Knight", "Battle Scene/HK Prime"),
            ("Deepnest_East_Hornet_boss", "Hornet Outskirts Battle Encounter/Thread"),
            ("GG_Hornet_1", "Boss Holder/Hornet Boss 1/Needle"),
            ("GG_Hornet_1", "Boss Holder/Hornet Boss 1")
        };



        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects) {
            Preloads = preloadedObjects;
            LoadAbilities();
            instance= this;

        }

        private void LoadAbilities() {
            // Find all abilities
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes()) {
                if (type.BaseType ==typeof(Ability) && type.GetInterface(nameof(IAbility)) != null) {
                    // Type is an ability
                   Abilities.Add(Activator.CreateInstance(type) as IAbility);
                }
            }

            foreach (Ability ability in Abilities) {
                RegisterAbility((ability as IAbility).abilityReplaced, ability);
                Log($"Registered ability {ability.name}!");
            }
        }
    }

}