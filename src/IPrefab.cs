using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAbilities
{
    public interface IPrefab
    {
        public List<(string, string)> prefabs { get; }

    }
}
