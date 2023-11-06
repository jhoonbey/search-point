namespace SearchPoint.Data.Entities
{
    public class Rectangle : BaseEntity
    {
        public double BottomLeftX { get; set; }

        public double BottomLeftY { get; set; }

        public double TopRightX { get; set; }

        public double TopRightY { get; set; }
    }
}