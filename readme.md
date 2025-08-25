# Note
This readme is incomplete. For now it's just quick developer notes so I can write out the details later (famous last words...)

# CSV Input Custom Sanitizer
I found out the `csv` file we got from the bookkeeping software was not in a valid `csv` format:
- Some lines were missing the date, even though they were supposed to have the same date as the line above them.
- Some data lines were split out over multiple lines in the file. 
So I decided to write a program that solves these two problems and generates a sensible `csv` which this original file should have been. This is obviously a lot of domain specific knowledge, but by keeping that here the main program should be able to maintain generality.

## Usage with the main program
Note that if you copy `OutputConfiguration` from the `appsettings.json` of this program to `Bookkeeping` of `appsettings.json` of the main program, the main program will read the generated output of this script.