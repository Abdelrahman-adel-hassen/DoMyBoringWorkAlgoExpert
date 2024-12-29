using System;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

class Program
{
    static void Main()
    {
        // Initialize InputSimulator for keyboard simulation
        var sim = new InputSimulator();
        var options = new ChromeOptions();
        options.AddArgument(@"user-data-dir=c:\Users\{username}\AppData\Local\Google\Chrome\User Data\");
        IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
        driver.Url = "https://accounts.google.com/";

        Console.ReadKey();
        driver.Navigate().GoToUrl("https://www.algoexpert.io/systems/workspace/design-a-code-deployment-system");
        Console.WriteLine("Opened Google.com");
  









        // Start screen recording
        StartStopRecording(sim);
        Console.WriteLine("Recording started.");

        // Wait for a few seconds (you can replace this with your actual task)
        Console.ReadLine(); // Wait for 5 seconds

        // Stop screen recording
        StartStopRecording(sim);
        Console.WriteLine("Recording stopped.");

        // Close the browser
        driver.Quit();
    }

    static void StartStopRecording(InputSimulator sim)
    {
        // Simulate "Windows + Alt + R" to start/stop screen recording
        sim.Keyboard.KeyDown(VirtualKeyCode.LWIN);   // Windows key down
        sim.Keyboard.KeyDown(VirtualKeyCode.LMENU);  // Alt key down
        sim.Keyboard.KeyPress(VirtualKeyCode.VK_R);  // Press R
        sim.Keyboard.KeyUp(VirtualKeyCode.LMENU);    // Alt key up
        sim.Keyboard.KeyUp(VirtualKeyCode.LWIN);     // Windows key up
    }
}
