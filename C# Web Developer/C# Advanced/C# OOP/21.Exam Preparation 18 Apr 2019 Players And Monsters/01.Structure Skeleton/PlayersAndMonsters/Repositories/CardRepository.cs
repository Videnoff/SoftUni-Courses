using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private Dictionary<string, ICard> cardsByName;

        public CardRepository()
        {
            this.cardsByName = new Dictionary<string, ICard>();
        }

        public int Count => this.cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardsByName.Values.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            this.ThrowIfPlayerIsNull(card, $"Card cannot be null!");

            if (this.cardsByName.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cardsByName.Add(card.Name, card);
        }

        public bool Remove(ICard card)
        {
            this.ThrowIfPlayerIsNull(card, $"Card cannot be null!");

            return this.cardsByName.Remove(card.Name);
        }

        public ICard Find(string name)
        {
            ICard card = null;

            if (this.cardsByName.ContainsKey(name))
            {
                card = this.cardsByName[name];
            }

            return card;
        }

        private void ThrowIfPlayerIsNull(ICard card, string message)
        {
            if (card == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}