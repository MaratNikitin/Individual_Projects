const int ENTRY_FEE = 2;
const int FIRST_HOUR_FEE = 3;
const int FOLLOWING_HOUR_FEE = 4;

int CalculateParkingFee(string E, string L)
{
    DateTime startTime = new DateTime();
    DateTime endTime = new DateTime();
    startTime = DateTime.ParseExact(E, "H:m", null);
    endTime = DateTime.ParseExact(L, "H:m", null);
    int parkingFee = ENTRY_FEE + FIRST_HOUR_FEE;
    var timeDifference = endTime - startTime;
    parkingFee += timeDifference.Hours * FOLLOWING_HOUR_FEE;

    if(timeDifference.Minutes == 0)
    {
        // It's the edge case when there is a round number of hours:
        parkingFee -= FOLLOWING_HOUR_FEE;
    }

    return parkingFee;
}

// Test the CalculateParkingFee function here:
string enteredTimeString = "10:00";
string leftTimeString = "13:21";

var totalParkingFee = CalculateParkingFee(enteredTimeString, leftTimeString);
Console.WriteLine($"Total parking fee for parking between {enteredTimeString} and {leftTimeString}: ${totalParkingFee.ToString()}.");
