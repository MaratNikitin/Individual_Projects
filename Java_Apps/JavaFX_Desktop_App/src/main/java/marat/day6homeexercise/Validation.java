/*
Day 6 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022.
Author: Marat Nikitin.
This app allows viewing a list of travel agents from the 'travelexperts' database
    and updating their data.
This class contains user input validation methods.
*/

package marat.day6homeexercise;

public class Validation {

    private final String lineEnd;

    // formal constructor:
    public Validation() {
        this.lineEnd = "\n";
    }

    // validating presence of required values:
    public String isPresent(String value, String name){
        String message = "";
        if (value.isEmpty()){
            message = name + " is required." + lineEnd;
        }
        return message;
    }

    // validating if a number is a positive integer:
    public String isPositiveInteger(String value, String name) {
        String message = "";
        try {
            Integer.parseInt(value);
            if (Integer.parseInt(value) <=0)
            {
                message = name + " must be a positive number." + lineEnd;
            }
        } catch (NumberFormatException e) {
            message = name + " must be an integer." + lineEnd;
        }
        return message;
    }

    // validating if a number of characters is within allowed range for the MySQL DB column:
    public String isNotTooLong(String value, String name, int maxAllowedNumberOfCharacters) {
        String message = "";
        if (value.length() > maxAllowedNumberOfCharacters)
        {
            message += name + " can not have more than " + maxAllowedNumberOfCharacters +
                    " characters because  of the database's column design restriction" + lineEnd;
        }
        return message;
    }
}
