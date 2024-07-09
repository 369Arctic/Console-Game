namespace tick_tack_toe
{

    public enum StateTabel
    {
        Cross,
        Zero,
        Unset
    }

    public enum GameWinner
    {
        Crosses,
        Zeros,
        Unfinished,
        Draw
    }
    internal class MyTickTackGame
    {
        private const int BoardSize = 9;
        private readonly StateTabel[] Fields = new StateTabel[BoardSize];
        public int MoveCounter { get; private set; }


        public MyTickTackGame()
        {
            for (int i = 0; i < Fields.Length; i++)
            {
                Fields[i] = StateTabel.Unset;
            }
        }

        public void MakeMove(int index)
        {
            Fields[index - 1] = MoveCounter % 2 == 0 ? StateTabel.Cross : StateTabel.Zero;
            MoveCounter++;
        }

        public StateTabel GetState(int index)
        {
            return Fields[index - 1];
        }


        private static readonly int[][] WinningCombinations = new int[][]
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 },
            new int[] { 1, 4, 7 },
            new int[] { 2, 5, 8 },
            new int[] { 3, 6, 9 },
            new int[] { 1, 5, 9 },
            new int[] { 3, 5, 7 },
        };

        public GameWinner GetWinner()
        {
            foreach (var combination in WinningCombinations)
            {
                if (AsSame(combination[0], combination[1], combination[2]))
                {
                    StateTabel state = GetState(combination[0]);
                    if (state != StateTabel.Unset)
                    {
                        return state == StateTabel.Cross ? GameWinner.Crosses : GameWinner.Zeros;
                    }
                }
            }
            return MoveCounter < BoardSize ? GameWinner.Unfinished : GameWinner.Draw;
        }


        private bool AsSame(int a, int b, int c)
        {
            return GetState(a) == GetState(b) && GetState(a) == GetState(c);
        }





    }
}
