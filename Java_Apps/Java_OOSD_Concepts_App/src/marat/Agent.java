/*
Day 3 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022
Author: Marat Nikitin
Custom-made Agent class is created here
*/

package marat;

import java.text.NumberFormat;

public class Agent extends Person {
    // below are instance variables specific to this class; making them private ensures that they are
    // not accessible from outside the objects:
    private String agentPhoneNumber;
    private double commissionRate;

    // constructor matching the parent constructor:
    public Agent(String name) {
        super(name); // name variable comes from the parent Person class
        agentPhoneNumber = "unknown"; // setting the default value
        commissionRate = 0; // "default value is set to 0"
    }

    // defining the abstract method of the parent class, displaying what's inside an object:
    @Override
    public void display() {
        // commission rate will be shown in currency format:
        NumberFormat formatter = NumberFormat.getCurrencyInstance();
        String formattedCommissionRate = formatter.format(commissionRate);
        // displaying the object:
        System.out.println("Agent's name: " + name + "; phone number: " + agentPhoneNumber +
                "; commission: " + formattedCommissionRate + ".");
    }

    // constructor for all the variables provided:
    public Agent(String name, String agentPhoneNumber, double commissionRate) {
        super(name); // name variable comes from the parent Person class
        this.agentPhoneNumber = agentPhoneNumber;
        this.commissionRate = commissionRate;
    }

    // getter for agentPhoneNumber:
    public String getAgentPhoneNumber() {
        return agentPhoneNumber;
    }

    // setter for agentPhoneNumber:
    public void setAgentPhoneNumber(String agentPhoneNumber) {
        this.agentPhoneNumber = agentPhoneNumber;
    }

    // getter for commissionRate:
    public double getCommissionRate() {
        return commissionRate;
    }

    // setter for commissionRate:
    public void setCommissionRate(double commissionRate) {
        this.commissionRate = commissionRate;
    }
}
