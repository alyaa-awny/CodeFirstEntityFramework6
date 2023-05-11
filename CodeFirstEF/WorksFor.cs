namespace CodeFirstEF
{
    public class WorksFor
    {
        public int Id { get; set; }
        public int Hours { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }

    }
}
