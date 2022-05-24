/*
Day 3 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022
Author: Marat Nikitin
Custom-made Customer class is created here
*/

package marat;

// custom class
public class Customer extends Person { // Customer class inherits from Person class
    // below are instance variables specific to this class; making them private ensures that they are
        // not accessible from outside the objects:
    private String custAddress;
    private String custCity;
    private String custProvince;

    // constructor for when all four variables provided:
    public Customer (String name, String address, String city, String province) {
        super(name); // name comes from the parent class
        custAddress = address;
        custCity = city;
        custProvince = province;
    }

    // constructor for the case when only customer's name is provided:
    public Customer (String name) {
        super(name); // name variable comes from the parent Person class
        custAddress = "unknown"; // setting the default value
        custCity = "unknown"; // setting the default value
        custProvince = "unknown"; // setting the default value
    }

    // defining the abstract method of the parent class, displaying what's inside an object:
    @Override
    public void display() {
        System.out.println("Customer's name: " + name + "; address: " + custAddress + "; city: " +
                custCity + "; province: " + custProvince + ".");
    }

    // getter for custAddress:
    public String getCustAddress() {
        return custAddress;
    }

    // setter for custAddress:
    public void setCustAddress(String custAddress) {
        this.custAddress = custAddress;
    }

    // getter for custCity:
    public String getCustCity() {
        return custCity;
    }

    // setter for custCity:
    public void setCustCity(String custCity) {
        this.custCity = custCity;
    }

    // getter for custProvince:
    public String getCustProvince() {
        return custProvince;
    }

    // setter for custProvince:
    public void setCustProvince(String custProvince) {
        this.custProvince = custProvince;
    }

    // custom method modifying 'FirstName LastName' into 'LastName, FirstName' returned String:
    public String makePhonebookName(Customer member){
        // + 1 is needed in the substring method to ensure that white space is omitted:
        // [0] in the split method means that the first substring (before first space) is returned:
        String phonebookName = member.name.substring(member.name.lastIndexOf(" ") + 1)
                + ", " + member.name.split(" ")[0];
        System.out.println(phonebookName);
        return phonebookName;
    } // end of makePhonebookName method
} // end of Person class
