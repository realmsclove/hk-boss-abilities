# Boss Abilities
A Hollow Knight mod that gives you an ability from each boss after having defeated it.

## Currently Abilities
* Mantis Lords "wind scythe" attack 
* Hornet's NeedleHook
* Soul Pillars
* Flower (for tests)
# Building
Copy the `LocalBuildProperties_example.props` and rename it to `LocalBuildProperties.props`. 
Set `HollowKnightFolder` to where your Managed folder is located and `OutputDirectory` to Mods folder an example of the props file is given below
```xml
<Project>
  <PropertyGroup>
    <HollowKnightFolder>C:\Program Files (x86)\Steam\steamapps\common\Hollow Knight\hollow_knight_Data\Managed</HollowKnightFolder>
    <OutputDirectory>$(HollowKnightFolder)/Mods</OutputDirectory>
  </PropertyGroup>
</Project>
```
## Dependencies:
* [Satchel DEV build](https://github.com/randomscorp/Satchel)
* [AbilityChanger](https://github.com/randomscorp/AbilityChanger/tree/api-rework) 
