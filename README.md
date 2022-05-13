# Boss Abilities
A Hollow Knight mod that gives you an ability from each boss after having defeated it.

## Currently Abilities
* Mantis Lords "wind scythe" attack

# Building
Very scuffed right now, edit BossAbilities.csproj to have the right HK path, and make a folder called `lib` with the following files from `hollow_knight_Data/Managed`:
* `Assembly-CSharp.dll`
* `MMHOOK_Assembly-CSharp.dll`
* `PlayMaker.dll`
* `UnityEngine.dll`
* `UnityEngine.CoreModule.dll`
* `UnityEngine.Physics2DModule.dll`
* `UnityEngine.ParticleSystemModule.dll`
* Additionally, add Satchel 0.7.6 or above