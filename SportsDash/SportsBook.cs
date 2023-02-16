using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsDash
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
