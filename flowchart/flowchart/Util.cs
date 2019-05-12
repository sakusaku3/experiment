namespace flowchart
{
    class Util
    {
        static short[,] costs;
        static short[,] next;

        public static void AllPairsShortestPaths(short[] vertices, bool[,] hasEdge)
        {
            int N = vertices.Length;
            costs = new short[N, N];
            next = new short[N, N];
            for (short i = 0; i < N; ++i)
            {
                for (short j = 0; j < N; ++j)
                {
                    costs[i, j] = hasEdge[i, j] ? (short)1 : short.MaxValue;
                    if (costs[i, j] == 1)
                        next[i, j] = -1;
                }
            }

            for (short k = 0; k < N; ++k)
            {
                for (short i = 0; i < N; ++i)
                {
                    for (short j = 0; j < N; ++j)
                    {
                        if (costs[i, k] + costs[k, j] < costs[i, j])
                        {
                            costs[i, j] = (short)(costs[i, k] + costs[k, j]);
                            next[i, j] = k;
                        }
                    }
                }
            }
        }

        public string GetPath(short src, short dst)
        {
            if (costs[src, dst] == short.MaxValue) return "<no path>";
            short intermediate = next[src, dst];
            if (intermediate == -1)
                return "->";
            return GetPath(src, intermediate) + intermediate + GetPath(intermediate, dst);
        }
    }
}
