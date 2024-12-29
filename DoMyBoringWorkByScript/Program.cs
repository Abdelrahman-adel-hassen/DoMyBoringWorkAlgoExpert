
using System.Diagnostics;
using WindowsInput;
using WindowsInput.Native;

class Program
{
    static void Main()
    {
        int[] timeArray = { 58, 49, 60, 47, 48, 48, 47, 37, 40, 51, 45, 39, 42 };
        //int[] timeArray = { 1, 1, 60, 47, 48, 48, 47, 37, 40, 51, 45, 39, 42 };

        string[] linksArray = [
        "https://www.algoexpert.io/systems/workspace/design-a-code-deployment-system",
        "https://www.algoexpert.io/systems/workspace/design-algoexpert",
        "https://www.algoexpert.io/systems/workspace/design-a-stockbroker",
        "https://www.algoexpert.io/systems/workspace/design-amazon",
        "https://www.algoexpert.io/systems/workspace/design-the-reddit-api",
        "https://www.algoexpert.io/systems/workspace/design-facebook-news-feed",
        "https://www.algoexpert.io/systems/workspace/design-google-drive",
        "https://www.algoexpert.io/systems/workspace/design-netflix",
        "https://www.algoexpert.io/systems/workspace/design-the-uber-api",
        "https://www.algoexpert.io/systems/workspace/design-tinder",
        "https://www.algoexpert.io/systems/workspace/design-slack",
        "https://www.algoexpert.io/systems/workspace/design-airbnb",
        "https://www.algoexpert.io/systems/workspace/design-the-twitch-api"
        ];
        for (int i = 0; i < linksArray.Length; i++)
        {
            var sim = new InputSimulator();

            string browserPath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"; // Update this path
            string url = linksArray[i];

            Process browserProcess = StartBrowser(browserPath, url);
            Console.WriteLine("Browser launched and URL opened.");

            // Wait for a few seconds to ensure the page loads
            Thread.Sleep(5000);

            // Simulate pressing F12 to open Developer Tools
            sim.Keyboard.KeyPress(VirtualKeyCode.F12);
            Console.WriteLine("F12 key pressed (Developer Tools opened).");

            // Wait for the console to be focused
            Thread.Sleep(5000);

            FocusConsoleTab(sim);
            Thread.Sleep(2000);

            WriteToConsole(sim, "Array.from(document.querySelectorAll('button')).find(button => button.textContent.trim() === 'Video Solution').click();");

            Console.WriteLine("GoLeft");
            Thread.Sleep(2000);
            GoToLeft(sim);
            Thread.Sleep(1000);
            Search(sim);
            Thread.Sleep(2000);
            Console.WriteLine("GoRight");
            GoToRight(sim);
            Thread.Sleep(2000);
            FocusConsoleTab(sim);
            Thread.Sleep(2000);
            StartVideo(sim);
            Thread.Sleep(1000);
            StartStopRecording(sim);
            Thread.Sleep(1000);
            sim.Keyboard.KeyPress(VirtualKeyCode.F12);
            Console.WriteLine("Recording started.");
            Console.WriteLine("Performing tasks...");
            Thread.Sleep(timeArray[i] * 60000);

            StartStopRecording(sim);
            Console.WriteLine("Recording stopped.");

            // Close the browser
            if (browserProcess != null && !browserProcess.HasExited)
            {
                browserProcess.Kill();
                Console.WriteLine("Browser closed.");
            }
            Console.WriteLine("Browser closed.");
        }

    }

    private static void StartVideo(InputSimulator sim)
    {
        WriteToConsole(sim, "document.querySelector('#cc-control-bar-button').click();");
        Thread.Sleep(2000);
        WriteToConsole(sim, "document.querySelectorAll('.MenuOptionListItem_module_listItem__2a2a4b59')[1].click();");
        Thread.Sleep(2000);
        WriteToConsole(sim, "document.querySelector('button[aria-label=\"Close menu\"]').click();");
        Thread.Sleep(2000);
        WriteToConsole(sim, "document.querySelector('.PlayButton_module_playButton__282507bf').click();");
        Thread.Sleep(1000);
        WriteToConsole(sim, "document.querySelector('#fullscreen-control-bar-button').click();");
    }

    static Process StartBrowser(string browserPath, string url)
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = browserPath,
                Arguments = url,
                UseShellExecute = true
            };
            return Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error launching browser: {ex.Message}");
            return null;
        }
    }
    static void DeleteAll(InputSimulator sim)
    {
        sim.Keyboard.KeyDown(VirtualKeyCode.CONTROL);  // Press Ctrl
        sim.Keyboard.KeyPress(VirtualKeyCode.VK_A);    // Press A (Select All)
        sim.Keyboard.KeyUp(VirtualKeyCode.CONTROL);    // Release Ctrl

        sim.Keyboard.KeyPress(VirtualKeyCode.DELETE);  // Press Delete

    }
    static void FocusConsoleTab(InputSimulator sim)
    {
        // Focus on the Console tab by pressing the keyboard shortcut
        // For Edge or Chrome, use Ctrl + ` to focus on the Console
        sim.Keyboard.KeyDown(VirtualKeyCode.CONTROL);  // Press Ctrl
        sim.Keyboard.KeyPress(VirtualKeyCode.OEM_3); // Press `
        sim.Keyboard.KeyUp(VirtualKeyCode.CONTROL);    // Release Ctrl
    }
    static void GoToRight(InputSimulator sim)
    {

        // Simulate Ctrl + ]
        sim.Keyboard.KeyDown(VirtualKeyCode.CONTROL);  // Press Ctrl
        sim.Keyboard.KeyPress(VirtualKeyCode.OEM_6); // Press ]
        sim.Keyboard.KeyUp(VirtualKeyCode.CONTROL);    // Release Ctrl
    }
    static void GoToLeft(InputSimulator sim)
    {
        // Simulate Ctrl + [
        sim.Keyboard.KeyDown(VirtualKeyCode.CONTROL);  // Press Ctrl
        sim.Keyboard.KeyPress(VirtualKeyCode.OEM_4); // Press [
        sim.Keyboard.KeyUp(VirtualKeyCode.CONTROL);    // Release Ctrl
    }
    static void Search(InputSimulator sim)
    {
        // Simulate Ctrl + F
        sim.Keyboard.KeyDown(VirtualKeyCode.CONTROL);  // Press Ctrl
        sim.Keyboard.KeyPress(VirtualKeyCode.VK_F);       // Press F
        sim.Keyboard.KeyUp(VirtualKeyCode.CONTROL);    // Release Ctrl
        Thread.Sleep(1000);
        WriteToConsole(sim, "iframe");
        Thread.Sleep(1000);
        sim.Keyboard.KeyPress(VirtualKeyCode.RETURN); //enter
        Thread.Sleep(1000);
        sim.Keyboard.KeyPress(VirtualKeyCode.RETURN); //enter
        Thread.Sleep(1000);
        sim.Keyboard.KeyPress(VirtualKeyCode.RETURN); //enter
        Thread.Sleep(1000);
        DeleteAll(sim);
        Thread.Sleep(1000);
        WriteToConsole(sim, "Button_module_button__779846a6");
    }

    static void WriteToConsole(InputSimulator sim, string script)
    {
        // Focus on the console in Developer Tools and type the script
        sim.Keyboard.TextEntry(script);  // Type the script in the console
        sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);  // Press Enter to execute the script
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
