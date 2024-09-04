public class TimeLoggerEventArgs : EventArgs
{
    public DateTime LoggedTime { get; }

    public TimeLoggerEventArgs(DateTime loggedTime)
    {
        LoggedTime = loggedTime;
    }
}

public delegate void TimeLoggerEventHandler(object sender, TimeLoggerEventArgs e);


public class Pusher
{
    // Event declaration using the delegate
    public event TimeLoggerEventHandler logHandler;

    
    public void OnPush()
    {
        if (logHandler != null)
        {
            logHandler(this, new TimeLoggerEventArgs(DateTime.Now));
        }
    }
}


public class LogManager
{
    // Event handler method
    public void LogTimeRecorder(object sender, TimeLoggerEventArgs e)
    {
        Console.WriteLine($"Time ogged at: {e.LoggedTime}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Instantiate LogManager objects
        Pusher push = new Pusher();
        LogManager handler = new LogManager();

        
        push.logHandlerOnPush += handler.LogTimeRecorder;

        
        push.OnPush();
    }
}
