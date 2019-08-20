namespace ProjectEuler.HelperClasses
{
    // thank you mathblog.dk
    class DisjointSet
    {
        /// <summary>
        /// The number of elements in the universe.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// The parent of each element in the universe.
        /// </summary>
        private int[] Parent;

        /// <summary>
        /// Initializes a new Disjoint-Set data structure, with the specified amount of elements in the universe.
        /// </summary>
        /// <param name='count'>
        /// The number of elements in the universe.
        /// </param>
        public DisjointSet(int count)
        {
            Count = count;
            Parent = new int[Count];

            for (int i = 0; i < Count; i++)
                Parent[i] = i;
        }

        /// <summary>
        /// Find the parent of the specified element.
        /// </summary>
        /// <param name='i'>
        /// The specified element.
        /// </param>
        /// <remarks>
        /// All elements with the same parent are in the same set.
        /// </remarks>
        public int Find(int i)
        {
            if (Parent[i] == i)
                return i;

            // Recursively find the real parent of i, and then cache it for later lookups.
            Parent[i] = Find(Parent[i]);
            return Parent[i];
        }

        /// <summary>
        /// Union the sets that the specified elements belong to.
        /// </summary>
        /// <param name='i'>
        /// The first element.
        /// </param>
        /// <param name='j'>
        /// The second element.
        /// </param>
        public void Union(int i, int j)
        {
            Parent[Find(i)] = Find(j);
        }

        public bool isSpanning()
        {
            for (int i = 1; i < Count; i++)
                if (Find(0) != Find(i))
                    return false;
            
            return true;
        }
    }
}
