using System;
namespace AutomaticDogDoor
{
    public class Sensor
    {
        //Properties
        public string doorSensor;
        public double doorDistance; // static distance
        public string dogSensor;
        public double dogDistance;  // dynamic distance


        //Initialising our constructor and setting our parameters.

        public Sensor(string doorSensor, double doorDistance, string dogSensor, double dogDistance)
        {
            this.doorSensor = doorSensor;
            this.doorDistance = doorDistance;
            this.dogSensor = dogSensor;
            this.dogDistance = dogDistance;

        }
        //Methods
        public double getDoorDistance()
        {
            return doorDistance;
        }
        //We are using a random function to get the values of the following properties: dogDistance, doorDistance,dogSensor and doorSensor.
        //Since in this assignment, we are not actually using a sensor found in either the dog or door. I decided to use to randomly generate the distances.
        //Hence, then the randomly generated distance is used in the main to give the distance between the dog and the door and also for knowing the door status.
        public double getDogDistance()
        {
            Random rnd = new Random();
            double dogDistance = rnd.Next(1, 101);
            return dogDistance;
        }

        public double getDoorSensor()
        {
            Random rnd = new Random();
            double doorSensor = rnd.Next(1, 100);
            return doorSensor;
        }
        public double getDogSensor()
        {
            Random rnd = new Random();
            double dogSensor = rnd.Next(1, 100);
            return dogSensor;
        }

        public void setDoorSensor(string newDoorSensor)
        {
            doorSensor = newDoorSensor;
        }
        public void setDoorDistance(double newDoorDistance)
        {
            doorDistance = newDoorDistance;
        }

        public void setDogSensor(string newDogSensor)
        {
            dogSensor = newDogSensor;
        }
        public void setDogDistance(double newDogDistance)
        {
            dogDistance = newDogDistance;
        }
    }
}

