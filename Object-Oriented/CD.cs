namespace OOProgramming
{
    public class CD : InterestEarningAccount
    {
        public DateTime MaturityDate { get; }
        public decimal InterestRate { get; }

        // <Constructor>
        public CD(string name, decimal initialBalance, decimal interestRate, int termInMonths)
            : base(name, initialBalance)
        {
            InterestRate = interestRate;
            MaturityDate = DateTime.Now.AddMonths(termInMonths);
        }
        // </Constructor>

        // <OverridePerformMonthEndTransactions>
        public override void PerformMonthEndTransactions()
        {
            if (DateTime.Now >= MaturityDate)
            {
                // Apply interest only when the term has ended
                decimal interest = Balance * InterestRate;
                MakeDeposit(interest, DateTime.Now, "apply CD interest");
            }
            else
            {
                // No interest applied if before maturity
                Console.WriteLine("CD is not matured yet, no interest applied.");
            }
        }
        // </OverridePerformMonthEndTransactions>

        // <OverrideWithdrawalMethod>
        public override void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (DateTime.Now < MaturityDate)
            {
                throw new InvalidOperationException("Cannot withdraw from CD before maturity.");
            }
            base.MakeWithdrawal(amount, date, note); // Call the base class withdrawal method
        }
        // </OverrideWithdrawalMethod>
    }
}
