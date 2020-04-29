namespace Checkpoint3
{
    public class Price
    {
        public double Adult { get; set; }
        public double Child => Adult * 0.5;
        public double Family => Adult * 0.6;
        public double GroupAdult => Adult * 0.75;
        public double GroupChildren => Adult * 0.4;
    }
}
