/*
Day 3 Individual Home Assignment
CMPP-264-A - Java Programming course, OOSD program,
SAIT, March 2022
Author: Marat Nikitin
*/


package marat;

import org.junit.Test;

import static org.junit.Assert.*;

public class makePhonebookNameTest {

    // testing the makePhonebookName method:
    @Test
    public void makePhonebookNameTest() {
        Customer testCustomer = new Customer("David Simpson");
        /* testing if for a customer "David Simpson" phonebook name returns
            as "Simpson, David"  */
        String expected = "Simpson, David";
        String actual = testCustomer.makePhonebookName(testCustomer);
        assertEquals(expected, actual);
    }
}