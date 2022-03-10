using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Poker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {  
            
            List<Card> cards = new List<Card>(); //list of cards to be generated
            for(int j = 1; j< 5; j++) //suit
            {
                for (int i = 1; i < 14; i++) //number
                {
                    cards.Add(makeCard(j, i, new Card())); //put on data to make a card
                }
            }

           LinkedList<Card> TempDeck = new LinkedList<Card>(cards); //0 indexed
           Global.deck = shuffle(TempDeck); //just so global deck starts shuffled
           TempDeck.Clear(); //clears the tempdeck

           LinkedListNode<Card> current = Global.deck.First; //Get global deck and make first node equal current
        }

        Card getNextCard(ref LinkedListNode<Card> current) //gets the next card in a linked list nodes
        {
            Card output = current.Value; //Gets the current card
            current = current.Next; //Moves the linked list to the next node
            return output;
        }


        LinkedList<Card> shuffle(LinkedList<Card> x)
        {
            Random rand = new Random(); //random class
            int size = x.Count;
            x = new LinkedList<Card>(x.OrderBy((o) => //order by sorts by a key. Key is random
            {
                return (rand.Next() % size);
            }));
            return x;
            
        }

        Card makeCard(int suit, int number, Card self)
        {
            //making the deck for start 2D array
            
            if (suit == 1) { self.suit = "H"; } //------------------
            else if (suit == 2) { self.suit = "D"; } //------------------
            else if (suit == 3) { self.suit = "S"; } //------------------
            else if (suit == 4) { self.suit = "C"; } //------------------
            if (number < 11 && number != 1)
            {
                self.strNumber = number.ToString();
            }
            else if (number == 11) { self.strNumber = "J"; }
            else if (number == 12) { self.strNumber = "Q"; }
            else if (number == 13) { self.strNumber = "K"; }
            else if (number == 1) { self.strNumber = "A"; }
            self.intNumber = number;
            return self;
        }

        void AddPlayer()
        {
            string name = Interaction.InputBox("Enter your name", "Name input", "...", 100,100);
            string Tempchips= Interaction.InputBox("Enter how many chips", "Chip input", "...", 100, 100);
            int chips;
            if (int.TryParse(Tempchips, out int result) == true) { chips = result; } //Enter chip value and check if its an int
            else {MessageBox.Show("Invalid Input, defaulting 500 chips");chips = 500; }


            Global.players.Add(new Player(name, chips)); //add a new player using info which they entered
            
        }

        private void PlayerBTN_Click(object sender, EventArgs e)
        {
            AddPlayer();
        }
    }
}
