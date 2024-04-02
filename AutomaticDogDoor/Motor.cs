using System;
namespace AutomaticDogDoor
{
    public class Motor
    {
        //Properties
        public string motorName;
        public string motorType;
        public bool motorState; // isOpen = true
        public int motorBattery;



        // Constructor and its Parameters
        public Motor(string motorName, string motorType, bool motorState, int motorBattery)
        {
            this.motorName = motorName;
            this.motorType = motorType;
            this.motorState = motorState;
            this.motorBattery = motorBattery;
        }

        //Methods
        public string getmotorName()
        {
            return motorName;
        }

        public string getmotorType()
        {
            return motorType;
        }

        public bool getmotorState()
        {
            return motorState;
        }
        // getting random battery value
        public int getmotorBattery()
        {
            Random rnd = new Random();
            int motorBatteryValue = rnd.Next(1, 101);// Get random numbers in the range of 1-100.
            return motorBatteryValue;
        }

        public void setmotorName(string newMotorName)
        {
            motorName = newMotorName;
        }

        public void setmotorType(string newMotorType)
        {
            motorType = newMotorType;
        }

        public void setmotorState(bool newMotorState)
        {
            motorState = newMotorState;
        }
        public void setmotorBattery(int newMotorBattery)
        {
            motorBattery = newMotorBattery;
        }
    }//End of class Motor
}//End of Namespace

