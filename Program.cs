using System;
using System.IO;
using mis321_pa2_cacook7;
using mis321_pa2_cacook7.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis321_pa2_cacook7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            bool gameOver = false;

            var jack = fillInfo("Jack Sparrow", 1);
            var will = fillInfo("Will Turner", 2);
            will.attackBehavior = new SwordAttack();
            var davy = fillInfo("Davy Jones", 3);
            davy.attackBehavior = new CannonAttack();

            Console.WriteLine("Welcome to the Pirates of the Caribbean At World’s End Aracade Game!");

            Console.WriteLine("Player 1, please enter your name: ");
            var p1 = Console.ReadLine();
            Console.WriteLine("Player 2, please enter your name: ");
            var p2 = Console.ReadLine();

            int choice1;
            int choice2;

            Character player1 = chooseCharacter(p1, ref jack, ref will, ref davy);
            Character player2 = chooseCharacter(p2, ref jack, ref will, ref davy);

            Random rnd = new Random();
            int whoshouldStart = rnd.Next(2);
            double damage = 0.0;
            double bonus = 0.0;

            playGame(whoshouldStart);

            Character fillInfo(string name, int type)

            {
                Character temp = new Character();

                Random rnd = new Random();
                Double temp1 = Convert.ToDouble(rnd.Next(99)) + 1.0;
                Double temp2 = Convert.ToDouble(rnd.Next(Convert.ToInt32(temp1))) + 1.0;
                Double temp3 = Convert.ToDouble(rnd.Next(Convert.ToInt32(temp1))) + 1.0;

                temp.name = name;
                temp.characterType = type;
                temp.maxPower = temp1;
                temp.health = 100.0;
                temp.attackPower = temp2;
                temp.defensivePower = temp3;

                return temp;
            }

            Character chooseCharacter(string p, ref Character jack, ref Character will, ref Character davy)

            {
                Character player = new Character();
                int choice = 0;
                while (choice < 1 || choice > 3)

                {
                    Console.Clear();
                    Console.WriteLine($"{p} please choose your character");
                    if (jack.Taken == false) Console.WriteLine("1: " + jack.ToString());
                    if (will.Taken == false) Console.WriteLine("2: " + will.ToString());
                    if (davy.Taken == false) Console.WriteLine("3: " + davy.ToString());
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)

                    {
                        case 1:
                            player = jack;
                            jack.Taken = true;
                            break;
                        case 2:
                            player = will;
                            will.Taken = true;
                            break;
                        case 3:
                            player = davy;
                            davy.Taken = true;
                            break;
                        default:
                            Console.WriteLine("ERROR: Please re-enter a valid choice");
                            break;
                    }
                }
                return player;
            }

            double calcDamage(Character aPlayer, Character dPlayer)
            {
                double temp = 0.0;

                if (aPlayer.characterType < dPlayer.characterType || (aPlayer.characterType == 3 && dPlayer.characterType == 1))

                {
                    temp = (aPlayer.attackPower - dPlayer.defensivePower) * 1.2;
                }
                else

                {
                    temp = (aPlayer.attackPower - dPlayer.defensivePower) * 1.0;
                }

                Math.Round(temp, 2);

                if (temp <= 0) temp = 10.0;

                return temp;
            }
            void playGame(int flip)
            {
                if (flip == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"{p1} gets to go first");
                    do
                    {
                        Console.WriteLine($"\n{p1}: " + player1.ToString());
                        Console.WriteLine($"{p2}: " + player2.ToString());

                        Console.WriteLine($"\n{p1}: " + player1.attackBehavior.Attack());
                        damage = calcDamage(player1, player2);
                        damage = Math.Round(damage, 2);

                        Console.WriteLine($"{p1}: {player1.name} does {damage} damage to {player2.name}");
                        player2.health -= damage;
                        player2.health = Math.Round(player2.health, 2);

                        if (player2.health <= 0)
                        {
                            gameOver = true;
                            Console.WriteLine($"Congrats {p1}! You win!");
                            break;
                        }

                        Console.WriteLine($"\n{p1}: {player1.ToString()}");
                        Console.WriteLine($"{p2}: {player2.ToString()}");

                        Console.WriteLine($"\n{p2}: {player2.attackBehavior.Attack()}");
                        damage = calcDamage(player2, player1);
                        damage = Math.Round(damage, 2);

                        Console.WriteLine($"{p2}: {player2.name} does {damage} damage to {player1.name}");
                        player1.health -= damage;
                        player1.health = Math.Round(player1.health, 2);

                        if (player1.health <= 0)
                        {
                            gameOver = true;
                            Console.WriteLine($"Congrats {p2}! You win!");
                        }

                        Console.ReadKey();
                    }
                    while (gameOver == false);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{p2} gets to go first");
                    do
                    {
                        Console.WriteLine($"\n{p1}: {player1.ToString()}");
                        Console.WriteLine($"{p2}: {player2.ToString()}");

                        Console.WriteLine($"\n{p2}: {player2.attackBehavior.Attack()}");
                        damage = calcDamage(player2, player1);
                        damage = Math.Round(damage, 2);

                        Console.WriteLine($"{p2}: {player2.name} does {damage} damage to {player1.name}");
                        player1.health -= damage;
                        player1.health = Math.Round(player1.health);

                        if (player1.health <= 0)
                        {
                            gameOver = true;
                            Console.WriteLine($"Congrats {p2}! You win!");
                            break;
                        }

                        Console.WriteLine($"\n{p1}: " + player1.ToString());
                        Console.WriteLine($"{p2}: " + player2.ToString());

                        Console.WriteLine($"\n{p1}: " + player1.attackBehavior.Attack());
                        damage = calcDamage(player1, player2);
                        damage = Math.Round(damage, 2);

                        Console.WriteLine($"{p1}: {player1.name} does {damage} damage to {player2.name}");
                        player2.health -= damage;
                        player2.health = Math.Round(player2.health);

                        if (player2.health <= 0)
                        {
                            gameOver = true;
                            Console.WriteLine($"Congrats {p1}! You win!");
                        }

                        Console.ReadKey();
                    }
                    while (gameOver == false);

                }
            }

        }
    }
}

