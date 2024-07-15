namespace GameOfSticks
{
    public class GameOfSticks
    {
        private readonly Random _rand;

        public int InitialSticksNumbers { get; }
        public int RemainingSticks { get; private set; }
        public Player PlayerNow { get; private set; }
        public StatusOfGame GameStat { get; private set; }
        public event Action<int> MachinePlayed;
        public event EventHandler<int> HumanTurnToMakeMove;

        public event Action<Player> EndOfGame;


        public GameOfSticks(int InitialSticksNumbers, Player WhoFirstMakeMove)
        {
            if (InitialSticksNumbers < 7 || InitialSticksNumbers > 30)
                throw new ArgumentException("Начальное количество палочек должно быть больше 7 и меньше 30");
            _rand = new Random();
            this.InitialSticksNumbers = InitialSticksNumbers;
            RemainingSticks = InitialSticksNumbers;
            PlayerNow = WhoFirstMakeMove;
            GameStat = StatusOfGame.NotStarted;
        }

        public void Start()
        {
            if (GameStat == StatusOfGame.InProgress)
                throw new InvalidOperationException("Невозможно запустить игру снова, игра уже идет");
            GameStat = StatusOfGame.InProgress;

            while (GameStat == StatusOfGame.InProgress)
            {
                if (PlayerNow == Player.Human)
                    HumanMakeMove();
                else
                    CompMakeMove();
                GameEndRequired();
                PlayerNow = PlayerNow == Player.Human ? Player.Computer : Player.Human;
            }
        }

        private void GameEndRequired()
        {
            if (RemainingSticks == 0)
            {
                GameStat = StatusOfGame.GameIsFinished;
                EndOfGame(PlayerNow == Player.Human ? Player.Computer : Player.Human);
            }
        }

        private void CompMakeMove()
        {
            int maxNumber = RemainingSticks >= 3 ? 3 : RemainingSticks;
            int CompTake = _rand.Next(1, maxNumber);
            TakeSticks(CompTake);

            MachinePlayed?.Invoke(CompTake);
        }

        private void HumanMakeMove()
        {
            HumanTurnToMakeMove?.Invoke(this, RemainingSticks);
        }

        public void HumanTakeSticks(int sticks)
        {
            if (sticks < 1 || sticks > 3)
                throw new ArgumentException("Необходимо взять от 1 до 3х палочек");
            else if (sticks > RemainingSticks)
                throw new ArgumentException($"Ты пытаешься взять больше, чем осталось. Осталось {RemainingSticks}");

            TakeSticks(sticks);
        }

        private void TakeSticks(int sticks)
        {
            RemainingSticks -= sticks;
        }
    }
}
