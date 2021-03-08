#Towers of Hanoi

The program starts by placing 4 numbers in a stack. 
It then prompts the user to select the stack they would like to move the top value from and to.
It runs the IsMoveValid function, which checks that the following are true:
-There is a value in the 'from' stack
-the user didn't select the same stack twice
-that the top 'from' isn't greater than the top 'to'
If they are true, then the value is moved to the chosen stack
The CheckWin function then checks is the full stack has been built in the C column
if not, then the code loops back to the user input