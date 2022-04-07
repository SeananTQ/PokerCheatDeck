using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeananTools;
using TexasHoldem;
namespace  MainLogic
{
    public  class HandLogic
    {

        private readonly Deck deck;
        private readonly List<Card> communityCards;
        private CheatDeck cheatDeck;

        public HandLogic()
        {

            this.deck = new Deck();
            this.communityCards = new List<Card>(5);
            this.cheatDeck = new CheatDeck();

        }

        public void Show()
        {

            DebugClass.Log(cheatDeck.GetRandomHandType
                (7).ToFriendlyString()+"\r\n");

        }


        public void Play()
        {
            List<Card> cards = new();

            Card tempCard1 = new (CardSuit.Club,CardNumber.Five);
            Card tempCard2 = new (CardSuit.Diamond, CardNumber.Five);
            Card tempCard3 = new(CardSuit.Spade, CardNumber.Five);
            Card tempCard4 = new (CardSuit.Heart, CardNumber.Five);
            Card tempCard5 = new (CardSuit.Club, CardNumber.Jack);

            cards.Add(tempCard1);
            cards.Add(tempCard2);
            cards.Add(tempCard3);
            cards.Add(tempCard4);
            cards.Add(tempCard5);
            //cards.Add(deck.GetNextCard());
            //cards.Add(deck.GetNextCard());
            //cards.Add(deck.GetNextCard());
            //cards.Add(deck.GetNextCard());
            //cards.Add(deck.GetNextCard());                      

            DebugClass.Log(Helpers.GetHandRank(cards).ToString());
        }


    }
}
