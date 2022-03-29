namespace Sort
{
    public interface ISortAlgorithm
    {
        public IList<IComparable> Sort(IList<IComparable> array);        
    }
}