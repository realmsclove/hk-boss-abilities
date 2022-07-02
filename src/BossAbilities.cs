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
        public override List<(string, string)> GetPreloadNames()
        {
            List<(string, string)> prefabs = new();
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetInterface(nameof(IPrefab)) != null)
                {
                    var prefab_list = (Activator.CreateInstance(type) as IPrefab);
                    foreach(var name in prefab_list.prefabs)
                    {
                        prefabs.Add(name);
                    }
                }
            }
            return prefabs;
        }


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