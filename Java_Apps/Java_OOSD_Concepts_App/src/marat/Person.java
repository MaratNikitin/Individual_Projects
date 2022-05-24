/*
Day 3 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022
Author: Marat Nikitin
Custom-made Person class (parent class for Agent & Customer classes) is created here
*/

/* This is a parent class for the Agent & Customer classes */
package marat;

// since this class contains an abstract method, it has to be abstract
public abstract class Person {
    // the instance variable, 'protected' allows access from this package or sub-classes only:
    protected String name;

    // constructor receiving the name:
    public Person(String name) {
        this.name = name; // here we save names passed from children classes
    }

    // getter for the name:
    public String getName() {
        return name;
    }

    // setter for the name:
    public void setName(String name) {
        this.name = name;
    }

    // abstract method forcing all child classes to define this method properly:
    public abstract void display();
}
