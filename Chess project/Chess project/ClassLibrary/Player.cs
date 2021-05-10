using System;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace ChessLibrary
{
	 
	/// The class stores info about the chess player. Like 
	/// his type, name, image and side.
	 
    [Serializable]
	public class Player
	{
		private Type s_Type;		// Type of the player i.e. computer or human
		private Side s_Side;		// Player side i.e. white or black
		private string s_Name;		// Name of the Player
		private Image s_Image;		// Image of the player
		private Rules s_Rules;		// A reference to the chess rules
		private TimeSpan s_MaximumThinkTime;		// Maximum think time in seconds

		private TimeSpan s_TotalThinkTime;	// Stores total think time of the player
		private DateTime s_StartTime;		// User turn time starts
		private int	s_TotMovesAnalyzed;	// Total no. of moves analzyed by the player
		private bool s_GameNearEnd;			// True when the game is near the end
		public enum Type{Human, Computer};

        // Empty Constructor for XML serialization
        internal Player()
        {
            s_Side = PlayerSide;
            s_Type = PlayerType;
            s_MaximumThinkTime = new TimeSpan(0, 0, 4);	// maximum think for 4 seconds
            s_TotalThinkTime = (DateTime.Now - DateTime.Now);	// Reset the time
        }

		// Constructor for the new playe
		public Player(Side PlayerSide, Type PlayerType)
		{
			s_Side=PlayerSide;
			s_Type=PlayerType;
			s_MaximumThinkTime = new TimeSpan(0,0,4);	// maximum think for 4 seconds
			s_TotalThinkTime = (DateTime.Now - DateTime.Now);	// Reset the time
		}

		// Constructor for the new playe
		public Player(Side PlayerSide, Type PlayerType, Rules rules) : this(PlayerSide,PlayerType)
		{
			s_Rules=rules;	
		}

		// User turn/thinking time starts
		public void TimeStart()
		{
			s_StartTime=DateTime.Now;
		}

		// User turn/thinking time ends
		public void TimeEnd()
		{
			s_TotalThinkTime+= (DateTime.Now - s_StartTime);
		}

		// Update the user time
		public void UpdateTime()
		{
		}

		// Returns true if the current player is computer
		public bool IsComputer()
		{
			return (s_Type==Type.Computer);
		}

		// Reset the player timers
		public void ResetTime()
		{
			s_TotalThinkTime = (DateTime.Now - DateTime.Now);	// Reset time
		}

        // Get or Set the game rules
        [XmlIgnore]
        internal Rules GameRules
        {
            set { s_Rules = value; }
        }

		// Get the best move available to the player
		public Move GetFixBestMove()
		{
			int alpha, beta;
			int depth;					// depth to which to do the search
			TimeSpan ElapsedTime= new TimeSpan(1);		// Total elpased time
			Move BestMove=null;		// The best move for the current position

			// Initialize constants
			const int MIN_SCORE= -1000000;		// Minimum limit of negative for integer
			const int MAX_SCORE= 1000000;		// Maximum limit of positive integer

			ArrayList TotalMoves=s_Rules.GenerateAllLegalMoves(s_Side); // Get all the legal moves for the current side
			ArrayList PlayerCells = s_Rules.ChessBoard.GetSideCell(s_Side.type);

			alpha = MIN_SCORE;	// The famous Alpha & Beta are set to their initial values
			beta  = MAX_SCORE;	// at the start of each increasing search depth iteration

			depth=3;

			// Loop through all the legal moves and get the one with best score
			foreach (Move move in TotalMoves)
			{
				// Now to get the effect of this move; execute this move and analyze the board
				s_Rules.ExecuteMove(move);
				move.Score = -AlphaBeta(s_Rules.ChessGame.EnemyPlayer(s_Side).PlayerSide,depth - 1, -beta, -alpha);
				s_Rules.UndoMove(move);	// undo the move

				// If the score of the move we just tried is better than the score of the best move we had 
				// so far, at this depth, then make this the best move.
				if (move.Score > alpha)
				{
					BestMove = move;
					alpha = move.Score;
				}
			}		
			return BestMove;
		}


		// Get the best move available to the player
		public Move GetBestMove()
		{
			int alpha, beta;
			int depth;					// depth to which to do the search
			TimeSpan ElapsedTime= new TimeSpan(1);		// Total elpased time
			Move BestMove=null;		// The best move for the current position

			// Initialize constants
			const int MIN_SCORE= -10000000;		// Minimum limit of negative for integer
			const int MAX_SCORE= 10000000;		// Maximum limit of positive integer

			ArrayList TotalMoves=s_Rules.GenerateAllLegalMoves(s_Side); // Get all the legal moves for the current side

			// Now we use the Iterative deepening technique to search the best move
			// The idea is just simple, we will keep searching in the more and more depth
			// as long as we don't time out.
			// So, it means that when we have less moves, we can search more deeply and which means
			// better chess game.
			DateTime ThinkStartTime=DateTime.Now;
			int MoveCounter;
			Random RandGenerator= new Random();

			// Game is near the end, or the current player is under check
			if (s_Rules.ChessBoard.GetSideCell(s_Side.type).Count<=5 || TotalMoves.Count <= 5 )
				s_GameNearEnd = true;

			// Game is near the end, or the Enemy player is under check
			Side EnemySide;

			if (s_Side.isBlack())
				EnemySide = s_Rules.ChessGame.WhitePlayer.PlayerSide;
			else
				EnemySide = s_Rules.ChessGame.BlackPlayer.PlayerSide;

			if (s_Rules.ChessBoard.GetSideCell(s_Side.Enemy()).Count<=5 || s_Rules.GenerateAllLegalMoves(EnemySide).Count <= 5 )
				s_GameNearEnd = true;

			s_TotMovesAnalyzed=0;		// Reset the total moves anazlye counter

			for (depth = 1;; depth++)	// Keep doing a depth search 
			{
				alpha = MIN_SCORE;	// The famous Alpha & Beta are set to their initial values
				beta  = MAX_SCORE;	// at the start of each increasing search depth iteration
				MoveCounter = 0;	// Initialize the move counter variable

				// Loop through all the legal moves and get the one with best score
				foreach (Move move in TotalMoves)
				{
					MoveCounter++;

					// Now to get the effect of this move; execute this move and analyze the board
					s_Rules.ExecuteMove(move);
					move.Score = -AlphaBeta(s_Rules.ChessGame.EnemyPlayer(s_Side).PlayerSide,depth - 1, -beta, -alpha);
					s_TotMovesAnalyzed++;	// Increment move counter
					s_Rules.UndoMove(move);	// undo the move

					// If the score of the move we just tried is better than the score of the best move we had 
					// so far, at this depth, then make this the best move.
					if (move.Score > alpha)
					{
						BestMove = move;
						alpha = move.Score;
					}

					s_Rules.ChessGame.NotifyComputerThinking(depth, MoveCounter, TotalMoves.Count,s_TotMovesAnalyzed, BestMove );

					// Check if the user time has expired
					ElapsedTime=DateTime.Now - ThinkStartTime;
					if ( ElapsedTime.Ticks > (s_MaximumThinkTime.Ticks) )	// More than 75 percent time is available
						break;							// Force break the loop
				}

				// Check if the user time has expired
				ElapsedTime=DateTime.Now - ThinkStartTime;
				if ( ElapsedTime.Ticks > (s_MaximumThinkTime.Ticks*0.25))	// More than 75 percent time is available
					break;							// Force break the loop
			}
		
			s_Rules.ChessGame.NotifyComputerThinking(depth, MoveCounter, TotalMoves.Count,s_TotMovesAnalyzed, BestMove );
			return BestMove;
		}

		// Alpha and beta search to recursively travers the tree to calculate the best move
		private int AlphaBeta(Side PlayerSide, int depth, int alpha, int beta)
		{
			int val;
			System.Windows.Forms.Application.DoEvents();

			// Before we do anything, let's try the null move. It's like giving the opponent
			// a free shot and see if he can damage us. If he can't, we are in a better position and 
			// can nock down him

			// "Adaptive" Null-move forward pruning
			int R = (depth>6 ) ? 3 : 2; //  << This is the "adaptive" bit
			// The rest is normal Null-move forward pruning
			if (depth >= 2 && !s_GameNearEnd && s_Rules.ChessGame.DoNullMovePruning)	// disable null move for now
			{
				val = -AlphaBeta(s_Rules.ChessGame.EnemyPlayer(PlayerSide).PlayerSide,depth  - R - 1, -beta, -beta + 1); // Try a Null Move
				if (val >= beta) // All the moves can be skipped, i.e. cut-off is possible
					return beta;
			}

			// This variable is set to true when we have found at least one Principle variation node.
			// Principal variation (PV) node is the one where One or more of the moves will return a score greater than alpha (a PV move), but none will return a score greater than or equal to beta. 
			bool bFoundPv = false;

			// Check if we have reached at the end of the search
			if (depth <= 0)
			{
				// Check if need to do queiscent search to avoid horizontal effect
				if (s_Rules.ChessGame.DoQuiescentSearch)
					return QuiescentSearch(PlayerSide, alpha, beta);
				else
					return s_Rules.Evaluate(PlayerSide);	// evaluate the current board position
			}	
			// Get all the legal moves for the current side
			ArrayList TotalMoves=s_Rules.GenerateAllLegalMoves(PlayerSide); 

			// Loop through all the legal moves and get the one with best score
			foreach (Move move in TotalMoves)
			{
				// Now to get the effect of this move; execute this move and analyze the board
				s_Rules.ExecuteMove(move);

				// Principle variation node is found
				if (bFoundPv && s_Rules.ChessGame.DoPrincipleVariation) 
				{
					val = -AlphaBeta(s_Rules.ChessGame.EnemyPlayer(PlayerSide).PlayerSide, depth - 1, -alpha - 1, -alpha);
					if ((val > alpha) && (val < beta)) // Check for failure.
						val=-AlphaBeta(s_Rules.ChessGame.EnemyPlayer(PlayerSide).PlayerSide,depth - 1, -beta, -alpha); // Do normal Alpha beta pruning
				} 
				else
					val = -AlphaBeta(s_Rules.ChessGame.EnemyPlayer(PlayerSide).PlayerSide,depth - 1, -beta, -alpha); // Do normal Alpha beta pruning

				s_TotMovesAnalyzed++;	// Increment move counter
				s_Rules.UndoMove(move);	// undo the move
			
				// This move will never played by the opponent, as he has already better options
				if (val >= beta)
					return beta;
				// This is the best move for the current side (found so far)
				if (val > alpha)
				{
					alpha = val;
					bFoundPv = true;		// we have found a principle variation node
				}
			}
			return alpha;			
		}


		// Do the queiscent search to avoid horizontal effect
		int QuiescentSearch(Side PlayerSide, int alpha, int beta)
		{
			int val = s_Rules.Evaluate(PlayerSide);

			if (val >= beta) // We have reached beta cutt off
				return beta;
			
			if (val > alpha) // found alpha cut-off
				alpha = val;

			// Get all the legal moves for the current side
			ArrayList TotalMoves=s_Rules.GenerateGoodCaptureMoves(PlayerSide); 

			// Loop through all the legal moves and get the one with best score
			foreach (Move move in TotalMoves)
			{
				// Now to get the effect of this move; execute this move and analyze the board
				s_Rules.ExecuteMove(move);
				val = -QuiescentSearch(s_Rules.ChessGame.EnemyPlayer(PlayerSide).PlayerSide, -beta, -alpha);
				s_Rules.UndoMove(move);	// undo the move

				if (val >= beta) // We have reached beta cutt off
					return beta;
			
				if (val > alpha) // found alpha cut-off
					alpha = val;
			}

			return alpha;
		}


		//--------------------------------------------------
		#region Properties for the player class
        [XmlAttribute("Type=PlayerType")]
		public Type PlayerType
		{
			get
			{
				return s_Type;
			}
			set
			{
				s_Type=value;
			}
		}
		//--------------------------------------------------
		public Side PlayerSide
		{
			get
			{
				return s_Side;
			}
			set
			{
				s_Side=value;
			}
		}
		//--------------------------------------------------
		public string Name
		{
			get
			{
				return s_Name;
			}
			set
			{
				s_Name=value;
			}
		}
		//--------------------------------------------------
        [XmlIgnore]
		public Image Image
		{
			get
			{
				return s_Image;
			}
			set
			{
				s_Image=value;
			}
		}

		// Set and Get the total think time. Used for the computer player
		public int TotalThinkTime
		{
			get
			{
				return s_MaximumThinkTime.Seconds;	// returns back total think time of the user
			}
			set
			{
				s_MaximumThinkTime=new TimeSpan(0,0,value);	// returns back total think time of the user
			}
		}

		// Get the time used by player to make a move
        [XmlIgnore]
		public TimeSpan ThinkSpanTime
		{
			get
			{
				return s_TotalThinkTime;	// returns back total think time of the user
			}
            set
            {
                s_TotalThinkTime = value;
            }
		}

         
        /// Get or set the total think time in seconds
         
        public long ThinkSpanTimeInSeconds
        {
            get
            {
                return (long)s_TotalThinkTime.TotalSeconds;	// returns back total think time of the user
            }
            set
            {
                s_TotalThinkTime = new TimeSpan(0,0, (int)value);
            }
        }

		// Get user total think time in time format
		public string ThinkTime
		{
			get
			{
				string strThinkTime;

                // If the Start time is not yet set, initialize it
                if (s_StartTime.Year == 1)
                    s_StartTime = DateTime.Now;

				TimeSpan timespan = s_TotalThinkTime+(DateTime.Now - s_StartTime);
				strThinkTime =  timespan.Hours.ToString("00")+":"+timespan.Minutes.ToString("00")+":"+timespan.Seconds.ToString("00");
				return strThinkTime;	// returns back total think time of the user
			}
		}
		#endregion
	}
}
