using SpeechRecognition.ClassLibrary;

Console.WriteLine("Welcome to the Speech Recognition App");
Console.WriteLine("Please enter a command to begin. Exit to enter.");

bool isRunning = true;

while (isRunning)
{
    string? command = Console.ReadLine();
    if (command.ToLower().Trim() == "exit")
    {
        isRunning = false;
    }
    else
    {
        SpeechRecognitionApp recogniser = new SpeechRecognitionApp();
        string? result = recogniser.RecogniseInputCommand(command);
        Console.WriteLine(result);
    }
}