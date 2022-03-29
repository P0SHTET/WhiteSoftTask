namespace Sort
{
    public interface ISortAlgorithm<T> where T : IComparable
    {
        public IEnumerable<T> Sort(IEnumerable<T> array);
    }
}