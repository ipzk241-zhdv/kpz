using BuilderClassList.Interfaces;
using BuilderClassList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderClassList.Builders
{
    public class EnemyBuilder : ICharacterBuilder
    {
        private readonly Character _enemy = new() { Role = "Enemy" };

        public ICharacterBuilder SetHeight(float height)
        {
            _enemy.Height = height;
            return this;
        }

        public ICharacterBuilder SetBodyType(string bodyType)
        {
            _enemy.BodyType = bodyType;
            return this;
        }

        public ICharacterBuilder SetHairColor(string color)
        {
            _enemy.HairColor = color;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string color)
        {
            _enemy.EyeColor = color;
            return this;
        }

        public ICharacterBuilder SetClothes(string clothes)
        {
            _enemy.Clothes = clothes;
            return this;
        }

        public ICharacterBuilder AddInventoryItem(string item)
        {
            _enemy.Inventory.Add(item);
            return this;
        }

        public EnemyBuilder AddEvilDeed(string deed)
        {
            _enemy.Deeds.Add($"Evil: {deed}");
            return this;
        }

        public ICharacterBuilder SetName(string name)
        {
            _enemy.Name = name;
            return this;
        }

        public ICharacterBuilder SetNickname(string nickname)
        {
            _enemy.Nickname = nickname;
            return this;
        }

        public ICharacterBuilder SetClass(string dndclass)
        {
            _enemy.Class = dndclass;
            return this;
        }

        public ICharacterBuilder SetSpecialAction(string specialAction)
        {
            _enemy.SpecialAction = specialAction;
            return this;
        }

        public ICharacterBuilder SetUltimate(string ultimate)
        {
            _enemy.Ultimate = ultimate;
            return this;
        }

        public Character Build() => _enemy;
    }
}
