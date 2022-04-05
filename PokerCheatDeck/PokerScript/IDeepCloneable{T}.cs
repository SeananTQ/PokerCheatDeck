namespace TexasHoldem
{
    public interface IDeepCloneable<out T>
    {
        T DeepClone();
    }
}
