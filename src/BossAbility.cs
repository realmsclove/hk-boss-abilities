using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAbilities
{
    public abstract class BossAbility: Ability
    {
        public BossAbility() { }
        public abstract string abilityReplaced { get; }
        public abstract bool canUse { get; set; }
        public override bool hasAbility() => canUse;
        public virtual List<(string, string)> prefabs { get; }


    }
}
