# DDROIDD Winter Internship 2022 Coding Challange

### Backstory

During this festive season, all children around the globe are sending their requests to Santa. Due to the pandemic, Santa found some extra time and decided to build a computerized system for tracking the gift requests. Unfortunately he had to take care of his reindeer and couldn't finish the project. Let's help Santa!

### Requirements

#### 0. Getting started
Clone or download this repository to your local machine.
The starting project is a .NET Console Application. The easiest way to work with such project is by using Microsoft Visual Studio.

Note: You are free to implement this project in the OO Programing language of your choice. The internship however will be centered around the .NET technology stack.

#### 1. Add fields/properties and links between classes
The classes in the Core folder are incomplete. You will need to add fields/properties and links between them.
 We need to uniquely identify each child and keep information like: name, date of birth, address, etc. and if the child was good or bad. Each child can write only one letter. The letter needs to include the date when it was written. Each letter will contain a list of items - each item will have a unique identifier, name, etc. 
 
 There is a method in the Program class named Question1. In this method please build a sample data structure by instantiating the classes you previously created and display it on the console. Expected outcome: 3 Child objects each with one Letter containing 2 Items

Create a class diagram for your implementation


#### 2. Read letters from files
Santa decided to standardize the letter format this year. You can see an example in the letter-template.txt

Please create 3 new letter files using the provided format.

Read the newly created letter files and create an object structure based on the information in the files. Expected outcome: 3 Child objects each with one letter containing the provided items
Display the children names on the console

*Use the method Question2 from the Program class*

#### 3. Generate letter files
Using the data structure from Question 1, please generate letter files following the letter template but taking into account the information stored on each child. Hint: replace the tags with the actual information in the data structure (e.g. FULL_NAME with the name in the Child object)

*Use the method Question3 from the Program class*

#### 4. Build Report
Based on the letter files created or generated before, Santa needs to build a report for the Toy Factory. 

The report needs to highlight how many of each toy the elves need to build. Report format: Toy Name - Quantity

The report needs to be ordered decending by quantity

*Use the method Question4 from the Program class*

#### 5. Singleton Pattern
Can you apply Singleton Pattern in the current implementation? Please insert a comment explaining your choice 

*Use the method Question5 from the Program class*

#### 5. Travel Itinerary
 Let's help Santa with his travel itinerary. We need to make sure that Santa visits each city only once. 
Expected outcome: list with all addresses, grouped by city
*Use the method Question6 from the Program class*

# Commit Your Solution

#### 1. Package your solution
Compress your solution folder into a `.zip` or `.7z` archive

#### 2. Send the answers back to ddroidd
Contact your recruiter via email and send them the archived project solution.

# Observations
#### 1. Programming Language of choice
The provided code samples and project structure is a .NET Console Application. The internship will revolve around this technology stack.

However, you are free to complete this challenge using your preferred Object Oriented language

#### 2. Proposed time estimate
The time allowed for completing this challenge is **3 Days**

#### 3. Solution completeness
If you don't manage to complete all requirements, that's ok. Just send your partial implementation


#### 4. Can I put my project on GitHub instead of sending .zip file?
Of course, just remember to set up your repository as public and attach clear instructions on how to start the project.