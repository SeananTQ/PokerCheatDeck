namespace TexasHoldem
{
    using System.Collections.Generic;


    public interface IHandEvaluator
    {
        BestHand GetBestHand(IEnumerable<Card> cards);
    }
}
