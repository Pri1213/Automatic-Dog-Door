using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;

/// Student Name: Priyasnee Boolaky
/// Student ID: 20380009
/// Assignment 2 BAD

/// The purpose: To provide a user with an app like interaction with the program. Meaning just like an application, it has a
/// database for its users and using a login type of procsss.
/// This is why the first step is asking the user for its name then it compares it to the database created(list below) and follow up
/// to ask for their pin as further login verification.

/// <How to test the system>
/// First, you ll be prompt to insert a username, select one dogowner name from the dogprofiles list for example: Taylor Swift
/// Secondly, you will be required to insert the corresponding pin for example, if you chose Taylor Swift from the list,
/// her corresponding pin is 3333.
/// After successfully inputing both a valid username and pin , you will be welcomed in the system.
/// The system will show you a menu of options and you can choose and run any of them.
/// For example you can create a dog profile and then view that dog profile by prompting option 2 and inserting the dog name.
///

///Improvements to implement in further system development
///Implement a function to set a new accessibility level for your desired dog, the function will have to override the current database.
///Implement a function whereby it uses the activation distance to show the door status by using the dog's distance from the door.
///Implement a function to track the activity of the motor and log in the time it openes and closes in a database.



namespace AutomaticDogDoor
{
    class Program
    {
        static void Main(string[] args)// Method to run the automatic door dog program.
        {

            //Database
            //Please use the values in this database when testing the application

            Motor motor = new Motor("motorName", "motorType", true, 100);

            Sensor sensor = new Sensor("doorSensor", 50.0, "dogSensor", 10.0);

            List<Dog> dogprofiles = new List<Dog>();
            dogprofiles.Add(new Dog("Toto", "Labadrador", "James Smith", "Microchip sensor", 1234, "in-only"));
            dogprofiles.Add(new Dog("Max", "Husky", "Frank Charles", "Magnetic sensor", 1111, "closed"));
            dogprofiles.Add(new Dog("Rose", "French Bulldog", "Jamie Tartt", "Microchip sensor", 2222, "out-only"));
            dogprofiles.Add(new Dog("Mercedes", "Golden Retriever", "Harry Styles", "rfid sensor", 4321, "closed"));
            dogprofiles.Add(new Dog("Meredith", "Shiba Inu", "Taylor Swift", "Microchip sensor", 3333, "full-access"));
            dogprofiles.Add(new Dog("Olivia", "Shiba Inu", "Joe Alwyn", "Magnetic sensor", 1313, "full-access"));

            //Function to display the menu
            void printOptions()// These options give the user the choice to access the functions created
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1.Create your Dog's Profile");
                Console.WriteLine("2.View your Dog's Profile");
                Console.WriteLine("3.View current door state");
                Console.WriteLine("4.Set Activation Distance");
                Console.WriteLine("5.View Accessibility");
                Console.WriteLine("6.View Motor Battery Level");
                Console.WriteLine("7.View Distance");
                Console.WriteLine("8.Exit");
            }

            //Function for the user to create a dog profile
            void createDogProfile()
            {
                Console.WriteLine("Hello please insert your dog's name");
                string dogName = Console.ReadLine();

                Console.WriteLine("Now insert the owner's name");
                string ownerName = Console.ReadLine();

                Console.WriteLine("The next step is to input your dog's type");
                string dogType = Console.ReadLine();

                Console.WriteLine("The next step is to input your dog's collar type: Magnetic, Rfid, Microchip only");
                string dogCollar = Console.ReadLine();

                Console.WriteLine("The next step is to input your pin");
                int pin = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter your desired level of accessibility: in-only, out-only,full-access, closed");
                string dogAccessibility = Console.ReadLine();

                dogprofiles.Add(new Dog(dogName, dogType, ownerName, dogCollar, 1234, dogAccessibility));

                Console.WriteLine("Profile created");

            }

            ///Function used to display dog profile of the user's dog.
            void displayDogProfile()
            {

                Console.WriteLine("Hello,please insert your dog's name");

                Dog currentUser;
                string dogName = Console.ReadLine();

                currentUser = dogprofiles.FirstOrDefault(dog => dog.dogName == dogName); // Tried to implement a search list and return object principle.

                Console.WriteLine("The owner's name is " + currentUser.ownerName);

                Console.WriteLine("Your dog's type: " + currentUser.dogType);

                Console.WriteLine("Your dog's collar type: " + currentUser.dogCollar);

                Console.WriteLine("Your pin: " + currentUser.pin);

                Console.WriteLine("Your level of accessibility: " + currentUser.dogAccessibility);

            }

            ///Function that allows to uses to their dog's accessibility
            void viewAccessibility()
            {
                Console.WriteLine("Hello please insert your dog name");
                string dogName = Console.ReadLine();
                Dog currentUser;
                currentUser = dogprofiles.FirstOrDefault(dog => dog.dogName == dogName);
                Console.WriteLine("Your level of accessibility: " + currentUser.dogAccessibility);

            }



            ///Function to set activation distance
            void activationDitsance()
            {
                double doorOpening = 0;

                Console.WriteLine("Please insert the minimun distance between the dog and the door to active the system");

                doorOpening = double.Parse(Console.ReadLine());

                Console.WriteLine("Activation distance is: " + doorOpening + " meters");

            }

            //Function to view distance between dog and door.
            void distance()
            {
                var dogDistance = sensor.getDogDistance();
                Console.WriteLine("The Distance between your dog and the door is : " + dogDistance + " meters");
            }

            //Function to display the motor battery level.
            void motorBattery()
            {
                var motorBatteryValue = motor.getmotorBattery();
                Console.WriteLine("Your battery level is.." + motorBatteryValue + "%");
            }

            //Function to see the current door status.
            //We are using the two distances and comparing them to get the status of the door
            void doorState()
            {
                double dogSensor = sensor.getDogDistance();
                double doorSensor = sensor.getDoorDistance();

                if (dogSensor < doorSensor)
                {
                    Console.WriteLine("The door is open");
                }
                else
                {
                    Console.WriteLine("The door is closed");
                }

            }


            //Prompt User
            Console.WriteLine("Welcome to your door app");
            Console.WriteLine("Hi, please insert your username");

            String appUser = "";
            Dog currentUser;

            //A loop  is implement and used to test if the input from the user successfully matches with the database available
            while (true)
            {
                try
                {
                    appUser = Console.ReadLine();

                    //Access database to compare the user input with the list (database)
                    currentUser = dogprofiles.FirstOrDefault(a => a.ownerName == appUser);

                    if (currentUser != null) { break; }
                    else Console.WriteLine("User not recognized.Please try again");
                }
                catch { Console.WriteLine("User not recognized.Please try again"); }

            }

            //After successfull inputing the rigt username, the user will be prompt to insert the pin to its profile/application
            Console.WriteLine("Please enter your Pin...");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());

                    if (currentUser.getPin() == userPin) { break; }
                    else Console.WriteLine("Incorrect pin.Please try again");
                }
                catch { Console.WriteLine("Incorrect pin.Please try again"); }

            }

            //Once the pin matches with the database's one, the system welcomes the user and allows them access to our menu option.

            Console.WriteLine("Welcome " + currentUser.getOwnerName());

            int option = 0; // we are initialising the option integer and setting it to zero at first, meaning no option in the
                            // menu have been choosen yet.

            // this loop do-while is used to show the menu in the printOption function and allow the user to choose the option they want.
            // Using a try catch to ensure that if the user input a string , it gives an error since the only datatype for option is integer.
            do
            {
                printOptions(); //This gives the user a menu to choose from.
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("An error occured");
                } //Here, we are calling the functions to the options that relates to their position in the menu shown at the start in the printOptions function.
                if (option == 1) { createDogProfile(); }
                if (option == 2) { displayDogProfile(); }
                else if (option == 3) { doorState(); }
                else if (option == 4) { activationDitsance(); }
                else if (option == 5) { viewAccessibility(); }
                else if (option == 6) { motorBattery(); }
                else if (option == 7) { distance(); }
                else { Console.WriteLine("Please choose a valid option"); }
            } while (option != 8);//The User is exiting the system

            Console.WriteLine("Thank you for using the app");



        }//end of main

    }//end of class
}

