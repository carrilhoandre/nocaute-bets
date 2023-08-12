namespace NocauteBets.Domain.Models
{
    public class WinOdd : OddBase
    {
        public override OddType Type => OddType.Win;
    }
}
