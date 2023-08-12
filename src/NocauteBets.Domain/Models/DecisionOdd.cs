namespace NocauteBets.Domain.Models
{
    public class DecisionOdd : OddBase
    {
        public override OddType Type => OddType.Decision;
    }
}
