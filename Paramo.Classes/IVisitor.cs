namespace Paramo
{
    public interface IVisitor
    {
        Result visit(Normal usr);
        Result visit(Premium usr);
        Result visit(SuperUser usr);
    }
}
