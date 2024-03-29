﻿using System;
using System.Linq;
using System.Reflection;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            switch (type)
            {
                case "Trap":
                    card = new TrapCard(name);
                    break;
                case "Magic":
                    card = new MagicCard(name);
                    break;
            }

            return card;

            /*
             * With Reflection:

            Type cardType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.StartsWith(type));

            var card = Activator.CreateInstance(cardType, name) as ICard;

            return card;

            */
        }
    }
}