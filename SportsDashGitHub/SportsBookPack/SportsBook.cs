using SportsDash.UserPack;
using System.Collections;


namespace SportsDash.SportsBookPack
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
        }

        public Bet viewBet(Bet bet)
        {
            return bet;
        }
    }
}
