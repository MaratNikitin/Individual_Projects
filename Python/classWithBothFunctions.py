# This is a challenge task
# It contains a class with two independent functions
# Author: Marat Nikitin
# Date: June 8, 2022

import random
import time
from datetime import datetime
import math

class Challenge:

    # defining the requested function1 inside the class:
    def function1(self):
        print("This is function1.")
        counter = 0  # this variable is used to count the number of matches
        inputCharacter = input("Which letter would you like to display? ")

        # charactersArray = [] # generated random characters will be saved in this array
        matchDateTimesArray = []  # date-time values for characters matching the user input will be saved in this array

        for i in range(100):  # for faster testing purposes, it's better to temporarily put a number of elements significantly less than 1000
            # not sure how exactly case-sensitivity needs to be implemented in the task - I implemented it as a generated character can be upper or lower case with the same probability,
            # , and the input character can also be either lower or upper case, and the letters' cases do not matter when checking for match, e.g.'a' and 'A' are counted as a match
            randomCharacter = random.choice('abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ')  # a randomly chosen character is temporarily saved for processing
            generationDateTime = datetime.now().strftime("%Y-%m-%d %H:%M:%S.%f")[:-3]  # formatting date-time values to display milliseconds as in the task
            # charactersArray.append(randomCharacter) # randomly generated characters are saved in the array

            if (inputCharacter.upper() == randomCharacter.upper()):  # making checking character matches case-insensitive by converting characters to UPPER CASE
                counter = counter + 1  # if match is encountered, the counter variable is incremented by 1
                matchDateTimesArray.append(generationDateTime)  # if match happened, the matched character's generation date-time is saved separately for further display

            # print(str(charactersArray[i]) + " " + str(generationDateTime))
            time.sleep(0.01)  # 10ms sleep after each generation was requested in the task

        # displaying the results:
        print(str(inputCharacter) + " was generated " + str(counter) + " times at: ")
        for i in matchDateTimesArray:
            print("   " + i)
        print("")

    # defining the requested function2 inside the class:
    def function2(self):
        print("This is function2.")
        initialArray = []  # this is the array which user input elements are sorted
        rearrangedArray = []  # this array is used for sorting the initial array

        # number of elements is requested as input:
        arraySize = int(input("Enter the desired number of elements N in your array: "))  # defining the number of elements
        print("Enter array elements and press Enter after each new element: ")  # instructions to a user on what to do

        # taking the user input and creating the array:
        for i in range(0, arraySize):
            element = int(input())  # an array element is taken from user input
            initialArray.append(element)  # adding the element to the array

        print("Initial array: ")
        print(initialArray)  # displaying the initial sequence of element before sorting

        numberOfIterations = math.ceil(arraySize / 2)  # this number is needed for the following loop

        # the rearrangedArray is generated meeting the sorting criteria by appending two element per loop iteration:
        for i in range(0, numberOfIterations):
            rearrangedArray.append(initialArray[i])
            rearrangedArray.append(initialArray[arraySize - i - 1])

        # if the number of elements in the initial array was odd, then the last element should be deleted
        # since elements of rearrangedArray were generated in couples in the previous loop
        if (arraySize % 2 == 1):  # true if number of elements is odd
            rearrangedArray.pop()  # removing the last element
        initialArray = rearrangedArray  # saving the required sequence - completing the task
        print("Rearranged array: ")
        print(initialArray)  # displaying the result (properly sorted array)


# Executing the function1:
Challenge.function1(0);

# Executing the function2 after function1:
Challenge.function2(0);