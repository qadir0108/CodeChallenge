# Code Challenge Instructions
A sovled code challenge with instructions

<h2>Overview</h2>
This exercise asks you to write code that reads an input file, manipulates the contents, and produces one or more output files. There are two options to choose from below; pick one or both and write your solution in C#. You have 24 hours the receipt of these instructions to email us your source code.  

<h2>Input File</h2>
Your solution must accept an input file via command line parameter. Each line of this input file will be formatted like so:

~~~~
<Population, in hundreds of thousands>|<City>|<State>|<Semicolon-delimited list of interstates that run through this city>\n
~~~~

Example:

~~~~
4|Raleigh|North Carolina|I-40;I-85;I-95
27|Chicago|Illinois|I-94;I-90;I-88;I-57;I-55
10|San Jose|California|I-5;I-80
~~~~

You may assume the following:
-	The input file is well-formed: each pipe-delimited section will have one or more characters; the interstates section will have at least one interstate; the population number will be an integer; etc.
-	All interstates have the “I-” prefix.
-	The same city will not appear more than once in the input file.
-	Chicago will be in the input file.

There is a sample data set in Page 3 of this assignment.

<h2>Option 1</h2>
Produce two output files from the input. The first must be named Cities_By_Population.txt and have data in the following format:

~~~~
<Population>
(newline)
<City>, <State>
Interstates: <Comma-separated list of interstates, sorted by interstate number ascending>
(newline)
~~~~

Cities must be ordered from highest population to lowest. If there are multiple cities with the same population, group them under a single <Population> heading and sort them alphabetically by state and then city.

Example output:

~~~~
83
New York, New York
Interstates: I-78, I-80, I-87, I-95

27
Chicago, Illinois
Interstates: I-55, I-57, I-88, I-90, I-94

15
Phoenix, Arizona
Interstates: I-8, I-10, I-17

Philadelphia, Pennsylvania
Interstates: I-76, I-95 
~~~~

The second output file must be named Interstates_By_City.txt and contain a list of interstates and the number of cities they run through. Each line of the output file must be of the form:

~~~~
<Interstate> <Number of cities>
~~~~

Sort the list by interstate number ascending.
Example output:

~~~~
I-5 5
I-10 4
I-19 1
I-20 3 
~~~~

<h2>Option 2</h2>
Produce a single output file named Degrees_From_Chicago.txt. Each line of the output file must be of the form:

~~~~
<Degrees removed from Chicago> <City>, <State>
~~~~

A city is considered 1 degree removed from Chicago if it shares an interstate with Chicago. A city that is not directly connected to Chicago but is to a city 1 degree removed is considered 2 degrees removed. And so on.  Chicago itself is 0 degrees removed, and a city that is not directly or indirectly connected to Chicago has a degree of -1. Cities must only appear once, with the lowest degree of connection.

Sort the output by degree descending and then by city and state ascending.

Example output:

~~~~
1 Boston, Massachusetts
1 Cleveland, Ohio
1 Seattle, Washington
0 Chicago, Illinois
~~~~

Sample Cities File

~~~~
6|Oklahoma City|Oklahoma|I-35;I-44;I-40
6|Boston|Massachusetts|I-90;I-93
8|Columbus|Ohio|I-70;I-71
4|Arlington|Texas|I-30;I-20
5|Long Beach|California|I-10;I-5
4|Bakersfield|California|I-5
27|Chicago|Illinois|I-94;I-90;I-88;I-57;I-55
8|Jacksonville|Florida|I-10;I-95
12|Dallas|Texas|I-35;I-20;I-45;I-30
6|Kansas City|Kansas|I-35;I-70;I-29;I-49
6|Seattle|Washington|I-5;I-90
4|Cleveland|Ohio|I-90;I-71;I-80;I-77
15|Philadelphia|Pennsylvania|I-95;I-76
83|New York|New York|I-78;I-95;I-87;I-80
6|Portland|Oregon|I-5;I-84
6|Nashville|Tennessee|I-24;I-65;I-40
5|Tucson|Arizona|I-10;I-19
4|Atlanta|Georgia|I-86;I-75;I-20
4|Oakland|California|I-80
7|El Paso|Texas|I-10;I-25
10|San Jose|California|I-5;I-80
~~~~
