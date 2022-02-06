namespace Calculator
{
    public class ExecutableEquationItem
    {
        public int Index { get; set; }
        public virtual int GetPriority()
        {
            return ExecutableEquationItemPriority.GetPriority(this);
        }
    }
}
