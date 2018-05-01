using System;
using Tennis.GameScore;

namespace Tennis.Game.UI
{
//    interface IGameState
//    {
 //       GameState Next();
  //  }

    class StartGame : GameState//, IGameState 
    {
        public StartGame(GameState gameState): base(gameState) { }

        public override GameState Next()
        {
            Say("Welcome to Mega Tennis !");
            Say("------------------------");
            Say();
            Say("notice: responding with '!' always ends the game.");
            Say();

            char response = '!';
            if (!ForcedExit) response = Choose("New Game? (Y/N)");

            switch (response)
            {
                case 'Y': return new CreateGame(this);
                default : return new EndGame(this);
            }
        }
    }

    class CreateGame : GameState//, IGameState
    {
        public CreateGame(GameState gameState): base(gameState) { }

        public override GameState Next()
        {
            if (!ForcedExit) player1 = new Player(Ask("Name of serving player   :"));
            if (!ForcedExit) player2 = new Player(Ask("Name of receiving player :"));
            if (ForcedExit) return new EndGame(this);


            game = new TennisGame(player1, player2);
            serving = game.Started;

            return new FirstServe(this);
        }
    } 

    class FirstServe : GameState//, IGameState
    {
        public FirstServe(GameState gameState) : base(gameState) 
        {
            SayScore();
            Say();

            currentPlayer = player1;
            serving = game.Started;
        }

        public override GameState Next()
        {
            char response='!';

            if (!ForcedExit) response = Choose(player1.Name + " served correctly (Y/N)");

            switch (response)
            {
                case 'Y': return CorrectServe(this);
                case 'N': return FaultyServe(this);
                default: return new EndGame(this);
            }
        }
    }  

    class SecondServe : GameState//, IGameState
    {
        public SecondServe(GameState gameState):base(gameState) { }

        public override GameState Next()
        {
            char response = '!';

            if (!ForcedExit) response = Choose(player1.Name + " served correctly (Y/N)");

            switch (response)
            {
                case 'Y': return CorrectServe(this);
                case 'N': return FaultyServe(this);                       
                default: return new EndGame(this);
            }
        }

    }

    class ReturnRally : GameState//, IGameState
    {
        public ReturnRally(GameState gameState):base(gameState)
        {
            currentPlayer = currentPlayer.OtherPlayer;
        }

        public override GameState Next()
        {
            char response = '!';

            if (!ForcedExit) response = Choose(currentPlayer.Name + " returned correctly (Y/N)");

            switch (response)
            {
                case 'Y': return CorrectReturn(this);
                case 'N': return FaultyReturn(this);
                default: return new EndGame(this);
            }
        }
    }

    class EndGame : GameState//, IGameState
    {
        public EndGame(GameState gamestate):base(gamestate){ }
    }

    class GameState //: IGameState
    {
        #region fields
        protected bool ForcedExit = false;
        protected Player player1;
        protected Player player2;
        protected Player currentPlayer;

        protected TennisGame game;
        protected I_am_rallying rallying;
        protected I_am_serving serving;
        #endregion

        #region construction
        public GameState() { }
        protected GameState(GameState previousState)
        {
            player1 = previousState.player1;
            player2 = previousState.player2;
            game = previousState.game;
            currentPlayer = previousState.currentPlayer;
            rallying = previousState.rallying;
            serving = previousState.serving;
        }
        #endregion

        #region helpers
        protected void SayScore()
        {
            Console.WriteLine(FormatScore(player1.Name + " vs " + player2.Name, game.Score));
        }
        private static string FormatScore(string prefix, string gameScore)
        {
            if (prefix.Length > 38) prefix = prefix.Substring(0, 38);
            var spaces = 40 - prefix.Length;
            return prefix + new string(' ', spaces) + " Score:" + gameScore;
        }

        protected void Say()
        {
            Console.WriteLine();
        }
        protected void Say(string information)
        {
            Console.WriteLine(information);
        }
        protected string Ask(string question)
        {
            Console.Write(question + " ");

            string response;
            do    { response = Console.ReadLine().ToUpper(); }
            while ( response.Length == 0 );

            if (response.ToCharArray()[0] =='!') ForcedExit = true;
            return response;
        }
        protected char Choose(string question)
        {
            Console.Write(question + " ");
            var response = Console.ReadLine().ToUpper();

            if (response.Length > 0)
            {
                if (response.ToCharArray()[0] == '!') ForcedExit = true;
                return response.ToCharArray()[0];
            }
            else
            {
                ForcedExit = true;
                return '!';
            }
        }

        protected GameState CorrectReturn(GameState gameState)
        {
            rallying.Return();

            return new ReturnRally(gameState);
        }
        protected GameState FaultyReturn(GameState gameState)
        {
            rallying.Miss();

            return new FirstServe(gameState);
        }
        protected GameState CorrectServe(GameState gamestate)
        {
            rallying = serving.Serve();

            return new ReturnRally(gamestate);
        }
        protected GameState FaultyServe(GameState gamestate) {
            if (gamestate.GetType() == typeof(FirstServe))
            {
                serving = game.ServeFaulty();
                return new SecondServe(gamestate);
            }
            else
            {
                serving.ServeFaulty();
                return new FirstServe(gamestate);
            }
        }
        #endregion

        #region published interface
        public virtual GameState Next()
        {
            return new StartGame(this);
        }
        #endregion
    }


    class Display
    {
        GameState gamestate;

        public void Start()
        {
            gamestate = new GameState();
            do
            {
                gamestate = gamestate.Next();
            }
            while (gamestate.GetType() != typeof(EndGame));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var showtime = new Display();
            showtime.Start();
        }
    }
}
