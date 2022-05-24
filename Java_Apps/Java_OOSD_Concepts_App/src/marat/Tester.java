/*
Day 3 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022
Author: Marat Nikitin
This is a class containing executable method for testing other classes of this app
*/

package marat;

public class Tester {

    public static void main(String[] args) {
        // creating Customer class instances:
        Customer cust1 = new Customer("Emily Brown", "12 Harvest Lake Crescent NE",
                "Calgary", "Alberta"); // uses constructor for all variables provided
        Customer cust2 = new Customer("Jane Doe"); // uses the base constructor
        Customer cust3 = new Customer("Jimmy Hendrix", "18 Beddington Way NE",
                "Calgary", "Alberta"); // uses constructor for all variables provided

        // creating an array of Customer class objects:
        Customer [] customersArray = new Customer[3];
        customersArray[0] = cust1;
        customersArray[1] = cust2;
        customersArray[2] = cust3;

        // executing custom method for the whole array of Customers:
        System.out.println("Phonebook customers' names as requested in the initial Day 2 task description:");
        for (int i = 0; i < customersArray.length; i++) {
            customersArray[i].makePhonebookName(customersArray[i]);
        } // end of for loop

        // creating Agent class instances as was requested:
        Agent agent2 = new Agent("Jimmy Bolton", "403-999-9999", 200);
        Agent agent1 = new Agent("Mark Simpson", "403-999-9998", 300);
        Agent agent3 = new Agent("Billy Jones"); // using base constructor with only a parent parameter

        // creating an array of Agent class objects:
        Agent [] agentsArray = new Agent[3];
        agentsArray[0] = agent1;
        agentsArray[1] = agent2;
        agentsArray[2] = agent3;

        // displaying all objects in the customersArray using 'foreach' loop variation this time:
        System.out.println("\n" + "All objects of the customersArray:");
        for (Customer i : customersArray) {
            i.display();
        } // end of for loop

        // displaying all objects in the agentsArray:
        System.out.println("\n" + "All objects of the agentsArray:");
        for (Agent i : agentsArray) {
            i.display();
        } // end of for loop

    } // end of main class
} // end of Tester class
