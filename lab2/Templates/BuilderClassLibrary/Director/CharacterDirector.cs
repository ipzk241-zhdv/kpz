using BuilderClassList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderClassList.Director
{
    public class CharacterDirector
    {
        public void ConstructBasicHero(ICharacterBuilder builder)
        {
            builder
                .SetName("Raziel")
                .SetNickname("Kain's lieutenant")
                .SetClass("Soul Reaver")
                .SetSpecialAction("Soul Reave")
                .SetUltimate("Reaver")
                .SetHeight(180)
                .SetBodyType("Athletic vampire, but bony")
                .SetHairColor("Black")
                .SetEyeColor("Blue")
                .SetClothes("Scarf")
                .AddInventoryItem("Soul Reaver Wraith Sword");
        }

        public void ConstructBasicEnemy(ICharacterBuilder builder)
        {
            builder
                .SetName("Moebius")
                .SetNickname("Moebius the Time Streamer")
                .SetClass("Eldrith")
                .SetSpecialAction("Serve Elder God")
                .SetUltimate("Travel in Time")
                .SetHeight(170)
                .SetBodyType("Lean")
                .SetHairColor("Bald")
                .SetEyeColor("White")
                .SetClothes("Purple Cloak")
                .AddInventoryItem("Moebius's Staff");
        }
    }
}
