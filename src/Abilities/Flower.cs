using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAbilities.src.Abilities
{

    public class Flower : BossAbility
    {
        static Sprite getActiveSprite() { return Satchel.AssemblyUtils.GetSpriteFromResources("flower.png"); }
        static Sprite getInactiveSprite() { return Satchel.AssemblyUtils.GetSpriteFromResources("flower.png"); }
        public override string name { get => "Teleport"; set { } }
        public override string title { get => "Teleport"; set { } }
        public override string description { get => "Ability to Teleport."; set { } }
        public override Sprite activeSprite { get => getActiveSprite(); set { } }
        public override Sprite inactiveSprite { get => getInactiveSprite(); set { } }
        public override string abilityReplaced => AbilityChanger.Abilities.NAIL;
        public override List<(string, string)> prefabs => new()
        {
            ("GG_Mantis_Lords", "Shot Mantis Lord"),
            ("GG_Hollow_Knight", "Battle Scene/HK Prime"),
            ("Deepnest_East_Hornet_boss", "Hornet Outskirts Battle Encounter/Thread"),
            ("GG_Hornet_1", "Boss Holder/Hornet Boss 1/Needle"),
            ("GG_Hornet_1", "Boss Holder/Hornet Boss 1")
        };

        public override bool canUse { get; set; } 

        public static  GameObject flower;
        public Flower() 
        {
            
        }

        public override void Hooks()
        {
            #region Defining GOs
            flower = new GameObject()
            {
                name = "flower"
            };
            SpriteRenderer sr = flower.AddComponent<SpriteRenderer>();
            Texture2D tex = AssemblyUtils.GetTextureFromResources("flower.png");
            sr.sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 128f, 0, SpriteMeshType.FullRect);
            sr.color = new Color(1f, 1f, 1f, 1.0f);
            flower.SetActive(false);
            GameObject.DontDestroyOnLoad(flower);
            canUse = true;

            #endregion
        }

        public static void plantFlower(int DreamnailType = 0)
        {
            GameObject f = null;
            f = GameObject.Instantiate(flower);
            f.transform.position = HeroController.instance.transform.position + new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(0.2f, -0.2f) - 1f, -0.01f);
            f.SetActive(true);
        }
        public void handleAbilityUse()
        {
            plantFlower();
        }

        public override bool hasStart() => false;
        public override bool hasCharging() => false;
        public override bool hasCharged() => false;
        public override bool hasCancel() => false;
        public override bool hasTrigger() => false;
        public override bool hasOngoing() => false;
        public override bool hasContact() => false;
        public override bool hasComplete() => true;

        public override void Charged() => plantFlower();
        public override void Start() => plantFlower();
        public override void Charging(Action Next, Action Cancel) => plantFlower();
        public override void Cancel() => plantFlower();
        public override void Trigger(string type) => plantFlower();
        public override void Ongoing() => plantFlower();
        public override void Contact(GameObject other) => plantFlower();
        public override void Complete(bool wasCancelled) => plantFlower();

    }
}
