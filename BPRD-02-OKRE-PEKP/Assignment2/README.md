# Assignment 2

All non-code answers are in this file.


---

## PLC 2.5

Has already been done and simply just compile provided `Machine.java` and run:
```% javac Machine.java```
```% java Machine is1.txt```

</br>

## PLC 3.2



</br>

## HelloLex Question 1

Read the specification `hello.fsl`.
What are the regular expressions involved, and which semantic values are they associated with?

##### Answer:



</br>

## HelloLex Question 2

Generate the lexer out of the specification using a command prompt. Which additional file is generated during the process?

##### Answer:


How many states are there by the automation of the lexer?

##### Answer:



</br>

## HelloLex Question 3

Compile and run the generated program `hello.fs`from question 2.

##### Answer:
The program is run with `dotnet run`.


</br>

## HelloLex Question 4

Extend the lexer specification `hello.fsl`to recognise numbers of more than one digit.
New lexer specification is `hello2.fsl`.
Generate `hello2.fs`, compile and run the generated program.

##### Answer:
The program is run with `dotnet run`.


</br>

## HelloLex Question 5

Extend the lexer specification `hello2.fsl`to recognise numbers of more than one digit.
New lexer specification is `hello3.fsl`.
Generate `hello3.fs`, compile and run the generated program.

Hint: You can use the regular expression `[+-]?([0-9]*[.])?[0-9]+` to recognize floats.

##### Answer:
The program is run with `dotnet run`.


</br>

## HelloLex Question 6

Consider the 3 examples of input provided at the prompt and the result.

```fsharppc
% dotnet bin/Debug/net8.0/hello3.dll
Hello World from FSLex!

Please pass a digit:
34
The lexer recognises 34

% dotnet bin/Debug/net8.0/hello3.dll
Hello World from FsLex!

Please pass a digit:
34.24
The lexer recognises 34.24

% dotnet bin/Debug/net8.0/hello3.dll
Hello World from FsLex!

Please pass a digit:
34,34
The lexer recognises 34
%
```

Explain why the results are expected behaviour from the lexer.

##### Answer:



---