namespace NocauteBets.Domain.Models
{
    public class SubmissionOdd : OddBase
    {
        public override OddType Type => OddType.Submission;
    }
}
