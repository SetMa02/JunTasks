using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;

namespace CardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("1. Взять карту" +
                                  "\n2. Хватит");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        player.TakeCard();
                        break;
                    case "2":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }

                player.ShowCards();
            }
        }
    }

    class Player
    {
        private List<Card> _cards;
        private Deck _deck;

        public Player()
        {
            _deck = new Deck();
            _cards = new List<Card>() { };
        }

        public void ShowCards()
        {
            foreach (var card in _cards)
            {
                Console.WriteLine($"{_cards.IndexOf(card)}. {card.Name}");
            }
        }

        public void TakeCard()
        {
            Card card = _deck.GiveCard();
            
            if (card == null)
            {
                Console.WriteLine("Колода пуста");
            }
            else
            {
                _cards.Add(card);
            }
        }
    }

    class Deck
    {
        private int _startCard;
        private List<Card> _cards;
        private Random _random;

        public Deck()
        {
            _cards = new List<Card>() { };
            _random = new Random();
            _startCard = 7;
            CreateCards();
        }
        
        public Card GiveCard()
        {
            if (_cards.Any())
            {
                int giveCardId = _random.Next(0, _cards.Count);
                Card card = _cards[giveCardId];
                _cards.RemoveAt(giveCardId);
                return card;
            }
            else
            {
                return null;
            }
        }

        private void CreateCards()
        {
            CreateSuit("♠");
            CreateSuit("♥");
            CreateSuit("♦");
            CreateSuit("♣");
        }

        private void CreateSuit(string suit)
        {
            for (int i = _startCard; i <= 10; i++)
            {
                Card card = new Card($"{i} {suit}");
                _cards.Add(card);
            }

            _cards.Add(new Card($"Валет {suit}"));
            _cards.Add(new Card($"Дама {suit}"));
            _cards.Add(new Card($"Король {suit}"));
            _cards.Add(new Card($"Туз {suit}"));
        }
    }

    class Card
    {
        private string _name;
        public string Name => _name;

        public Card(string name)
        {
            _name = name;
        }
    }
}