using BuilderClassList.Interfaces;
using BuilderClassList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderClassList.Builders
{
    public class HeroBuilder : ICharacterBuilder
    {
        private readonly Character _hero = new() { Role = "Hero" };

        public ICharacterBuilder SetHeight(float height)
        {
            _hero.Height = height;
            return this;
        }

        public ICharacterBuilder SetBodyType(string bodyType)
        {
            _hero.BodyType = bodyType;
            return this;
        }

        public ICharacterBuilder SetHairColor(string color)
        {
            _hero.HairColor = color;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string color)
        {
            _hero.EyeColor = color;
            return this;
        }

        public ICharacterBuilder SetClothes(string clothes)
        {
            _hero.Clothes = clothes;
            return this;
        }

        public ICharacterBuilder AddInventoryItem(string item)
        {
            _hero.Inventory.Add(item);
            return this;
        }

        public HeroBuilder AddGoodDeed(string deed)
        {
            _hero.Deeds.Add($"Good: {deed}");
            return this;
        }

        public ICharacterBuilder SetName(string name)
        {
            _hero.Name = name;
            return this;
        }

        public ICharacterBuilder SetNickname(string nickname)
        {
            _hero.Nickname = nickname;
            return this;
        }

        public ICharacterBuilder SetClass(string dndclass)
        {
            _hero.Class = dndclass;
            return this;
        }

        public ICharacterBuilder SetSpecialAction(string specialAction)
        {
            _hero.SpecialAction = specialAction;
            return this;
        }

        public ICharacterBuilder SetUltimate(string ultimate)
        {
            _hero.Ultimate = ultimate;
            return this;
        }

        public Character Build() => _hero;
    }
}
