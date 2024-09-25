class Program
{
    class Bits
    {
        public Bits(byte b)
        {
            Value = b;
        }

        public byte Value { get; private set; } = 0;

        public bool this[int index]
        {
            get
            {
                if (index > 7 || index < 0)
                    return false;
                return ((Value >> index) & 1) == 1;
            }
            set
            {
                if (index > 7 || index < 0) return;
                if (value == true)
                    Value = (byte)(Value | (1 << index));
                else
                {
                    var mask = (byte)(1 << index);
                    mask = (byte)(0xff ^ mask);
                    Value &= (byte)(Value & mask);
                }
            }
        }

        public static implicit operator byte(Bits b) => b.Value;
        public static implicit operator long(Bits b) => b.Value;
        public static implicit operator int(Bits b) => b.Value;
    }

    static void Main(string[] args)
    {
        var b = new Bits(10);
        System.Console.WriteLine(b);

    }
}