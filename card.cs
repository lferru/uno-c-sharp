using System;

namespace UnoCards {

	class Card {

		private string suit, rank;

		public string Suit {

			get { return suit; }
			set { suit = value; }
		}

		public string Rank {

			get { return rank; }
			set { rank = value; }
		}

		public Card(string s, string r) {

			this.Suit = s;
			this.Rank = r;
		}
	}

	class Deck {

		private Card[] packet = new Card[112];

		public Deck() {

			string[] colors = new string[] { "RED", "YELLOW", "GREEN", "BLUE" };
		    string[] wilds = new string[] { "NORMAL", "+4", "CUSTOM", "SHUFFLE" };
			string[] ranks = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "+2", "REVERSE", "SKIP" };
			int i = 0;

			foreach ( string color in colors ) {
				
				packet[i++] = new Card(color, "" + 0);

				foreach ( string rank in ranks ) {
					
					for ( int k = 0; k < 2; k++ ) {

						packet[i++] = new Card(color, rank);
					}
				}
			}

			for ( int j = 0; j < 4; j++ ) {

				packet[i++] = new Card("WILD", "NORMAL");
				packet[i++] = new Card("WILD", "+4");

				if ( j == 3 ) continue;
				packet[i++] = new Card("WILD", "CUSTOM");
			}
			packet[i] = new Card("WILD", "SHUFFLE");
		}
		
		public void shuffle() {
			
			Card temp;
			Random rand = new Random();

			for ( int i = 0; i < 112 - 1; i++ ) {

				int r = rand.Next(i, 112);
				temp = packet[i];
				packet[i] = packet[r];
				packet[r] = temp;
			}
		}

		public void show() {

			for ( int i = 0; i < 112; i++ ) {

				Console.WriteLine(i + ": " + packet[i].Rank + " of " + packet[i].Suit);
			}
		}
	}

	class unoGame {

		static void Main(string[] args) {
			Deck mine = new Deck();
			mine.shuffle();
			mine.show();
		}
	}
}
