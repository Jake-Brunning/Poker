using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    static class Global
    {
        static public LinkedList<Card> deck = new LinkedList<Card>();  //global linked lists of cards
        static public List<Player> players = new List<Player>(); //global lists of players

        static public int x = 10;
        static public int y = 10;
    }
}
