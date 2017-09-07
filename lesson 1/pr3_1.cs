using System;

class TestApplication
{
   static void Main() 
   {
     Console.WriteLine("Привет!");
     
     HelloMessage v = new HelloMessage();
     v.Speak();
   }
}