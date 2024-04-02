using System;
namespace AutomaticDogDoor
{
    public class Dog
    {
        /// <summary>
        /// This class is used to define the properties of the class Dog and to set the parameters and initialises the properties.
        /// </summary>
        ///Properties
        public string dogName;
        public string dogType;
        public string ownerName;
        public string dogCollar;
        public int pin;
        public string dogAccessibility;

        ///Initialising our constructor and setting parameters
        public Dog(string dogName, string dogType, string ownerName, string dogCollar, int pin, string dogAccessibility)
        {
            this.dogName = dogName;
            this.dogType = dogType;
            this.ownerName = ownerName;
            this.dogCollar = dogCollar;
            this.pin = pin;
            this.dogAccessibility = dogAccessibility;
        }

        //Methods

        public string getDogName()
        {
            return dogName;
        }

        public string getDogType()
        {
            return dogType;
        }
        public string getOwnerName()
        {
            return ownerName;
        }

        public string getDogCollar()
        {
            return dogCollar;
        }

        public int getPin()
        {
            return pin;
        }

        public string getDogAccessibility()
        {
            return dogAccessibility;
        }

        public void setDogName(string newDogName)
        {
            dogName = newDogName;
        }

        public void setDogType(string newDogType)
        {
            dogType = newDogType;
        }
        public void setOwnerName(string newOwnerName)
        {
            ownerName = newOwnerName;
        }

        public void setDogCollar(string newDogCollar)
        {
            dogCollar = newDogCollar;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setdogAccessibility(string newAccessibility)
        {
            dogAccessibility = newAccessibility;
        }
    }//End of class Dog
}//End of Namespace

