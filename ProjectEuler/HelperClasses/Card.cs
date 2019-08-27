namespace ProjectEuler.HelperClasses
{
    class Card
    {
        public char value { get; set; }
        public char suit { get; set; }

        public override string ToString() => $"{suit}{value}";
    }
}
