using System;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException($"Player is dead!");
            }

            this.ModifyBeginner(attackPlayer);

            this.ModifyBeginner(enemyPlayer);

            attackPlayer = this.BoostPlayer(attackPlayer);

            enemyPlayer = this.BoostPlayer(enemyPlayer);

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                /*
                 * Equivalent:
                 *
                 *var attackPlayerAttackPoints = this.GetTotalDamagePoints(attackPlayer.CardRepository);
                 */

                var attackerAttackPoints = attackPlayer.CardRepository.Cards
                    .Select(c => c.DamagePoints)
                    .Sum();

                enemyPlayer.TakeDamage(attackerAttackPoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyPlayerAttackPoints = this.GetTotalDamagePoints(enemyPlayer.CardRepository);

                attackPlayer.TakeDamage(enemyPlayerAttackPoints);
            }

        }

        private IPlayer BoostPlayer(IPlayer player)
        {
            player.Health += player.CardRepository.Cards
                .Select(c => c.HealthPoints)
                .Sum();

            return player;
        }

        private void ModifyBeginner(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private int GetTotalDamagePoints(ICardRepository cardRepository)
        {
            int total = 0;

            foreach (var card in cardRepository.Cards)
            {
                total += card.DamagePoints;
            }

            return total;
        }
    }
}