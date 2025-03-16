using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderClassList.Models;

namespace BuilderClassList.Interfaces
{
    public interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetNickname(string nickname);
        ICharacterBuilder SetClass(string className);
        ICharacterBuilder SetSpecialAction(string action);
        ICharacterBuilder SetUltimate(string ultimate);

        ICharacterBuilder SetHeight(float height);
        ICharacterBuilder SetBodyType(string bodyType);
        ICharacterBuilder SetHairColor(string color);
        ICharacterBuilder SetEyeColor(string color);
        ICharacterBuilder SetClothes(string clothes);
        ICharacterBuilder AddInventoryItem(string item);

        Character Build();
    }
}
