using SportsDash.Models.UserPack;
using System.Collections;


namespace SportsDash.Models.SportsBookPack
{
    public class SportsBook
    {
        User currentUser { get; }
        ArrayList betsList = new ArrayList();

        public SportsBook(User currentUser)
        {
            this.currentUser = currentUser;
        }

        public void placeBet(Bet bet)
        {
            // enter the palceBet function
            betsList.Add(bet);
        }

        public Bet viewBet(Bet bet)
        {
            return bet;
        }
    }
}
