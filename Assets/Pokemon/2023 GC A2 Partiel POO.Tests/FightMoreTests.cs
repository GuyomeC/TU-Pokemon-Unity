using _2023_GC_A2_Partiel_POO.Level_2;
using NUnit.Framework;
using System;

namespace _2023_GC_A2_Partiel_POO.Tests.Level_2
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer des features et les TU sur le reste du projet
        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)


        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        [Test]
        public void VerifyStatus()
        {
            Character salameche = new Character(100, 50, 30, 20, TYPE.FIRE);
            Character bulbizarre = new Character(90, 60, 10, 200, TYPE.GRASS);
            Fight f = new Fight(salameche, bulbizarre);
            FireBall fb = new FireBall();
            MagicalGrass mg = new MagicalGrass();

            f.ExecuteTurn(fb, mg);

            Assert.That(bulbizarre.CurrentStatus, Is.EqualTo(StatusEffect.GetNewStatusEffect(StatusPotential.BURN)));
            Assert.That(salameche.CurrentStatus, Is.EqualTo(StatusEffect.GetNewStatusEffect(StatusPotential.SLEEP)));

        }
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        [Test]
        public void VerifyType()
        {
            Character salameche = new Character(100, 50, 30, 20, TYPE.FIRE);
            Character bulbizarre = new Character(90, 60, 10, 200, TYPE.GRASS);
            Fight f = new Fight(salameche, bulbizarre);
            Punch p = new Punch();

            f.ExecuteTurn(p, p);

            Assert.That(bulbizarre.CurrentHealth, Is.EqualTo(16));
            Assert.That(salameche.CurrentHealth, Is.EqualTo(74));
        }




        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type
        // - L'utilisation d'objets : Potion, SuperPotion, Vitess+, Attack+ etc.
        // - Gérer les PP (limite du nombre d'utilisation) d'une attaque,
        // si on selectionne une attack qui a 0 PP on inflige 0

        // Choisis ce que tu veux ajouter comme feature et fait en au max.
        // Les nouveaux TU doivent être dans ce fichier.
        // Modifiant des features il est possible que certaines valeurs
        // des TU précédentes ne matchent plus, tu as le droit de réadapter les valeurs
        // de ces anciens TU pour ta nouvelle situation.

    }
}
