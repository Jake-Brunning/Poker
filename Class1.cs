using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Poker
{
    class Player
    {
        private int chips; //player chips
        private string name;  //player name
        private string[] CurrentCards = new string[1];  //player cards there holding
        Label chipsLabel = new Label();
        
        public Player(string name, int chips)  //constructor
        {
            this.name = name;
            this.chips = chips;

            //setting up chips label
            chipsLabel.Text = chips.ToString();
            chipsLabel.Location = new System.Drawing.Point(Global.x, Global.y);
            Global.x += 200;
            chipsLabel.AutoSize = true;
            chipsLabel.Font = new System.Drawing.Font("Calibri", 18);
            chipsLabel.ForeColor = System.Drawing.Color.Green;
            chipsLabel.Padding = new Padding(6);
            Form.ActiveForm.Controls.Add(chipsLabel);
        }

        public int removeChips(Player self, int amountToRemove) //removing chips
        {
            return self.chips - amountToRemove;
        }
    }
}
