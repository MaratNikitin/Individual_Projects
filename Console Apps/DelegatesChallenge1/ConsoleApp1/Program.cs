// Solved without using delegates:
internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("What is the destination zone?");
            string zone = Console.ReadLine() ?? "";

            if (zone.ToUpper().Contains("EXIT"))
            {
                Environment.Exit(0);
            }

            Console.WriteLine("What is the item's price?");
            string priceInput = Console.ReadLine() ?? "0.0";
            
            if (priceInput.ToUpper().Contains("EXIT"))
            {
                Environment.Exit(0);
            }

            double price = Double.Parse(priceInput);
            double shippingFee = CalculateShippingFee(zone, price);
            Console.WriteLine($"The shipping fees are: ${shippingFee}");
            Console.WriteLine();
        }

        double CalculateShippingFee(string zone, double price)
        {
            double calculatedFee = 0.0;
            switch (zone.ToLower())
            {
                case "zone1":
                    calculatedFee = price * 0.25;
                    break;
                case "zone2":
                    calculatedFee = price * 0.12 + 25;
                    break;
                case "zone3":
                    calculatedFee = price * 0.08;
                    break;
                case "zone4":
                    calculatedFee = price * 0.04 + 25;
                    break;
                default:
                    Console.WriteLine("Sorry, incorrect zone's name was entered.");
                    break;
            }
            return calculatedFee;
        }
    }
}

//public delegate double CalculateFeeDelegate(string zone, double price);
