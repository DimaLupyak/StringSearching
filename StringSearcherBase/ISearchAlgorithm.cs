namespace StringSearch
{
    // T is the type of the object produced by algorithm pre-processing
    public interface ISearchAlgorithm<out T>
    {
        int Search(char[] s, char[] key);

        int[] SearchAll(char[] s, char[] key);
    }
}
