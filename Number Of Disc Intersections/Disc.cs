namespace Number_Of_Disc_Intersections
{
    public class Disc
    {
        public uint Position { get; }
        public uint Radius  { get;  }
        

        public int LeftPoint { get; }
        public uint RightPoint { get; }

        public Disc(uint position, uint radius)
        {
            Position = position;
            Radius = radius;
            LeftPoint = (int) (position - radius);
            RightPoint = position + radius;
        }
    }
}