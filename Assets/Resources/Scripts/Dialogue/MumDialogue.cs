using UnityEngine;
using Fluent;

/// <summary>
/// This example shows you how to execute code when an option is selected
/// </summary>
public class MumDialogue : MyFluentDialogue
{
    public override void OnStart() { PlayerController.canMove = false; }
    public override void OnFinish() { PlayerController.canMove = true; }

    private void SomeFunction()
    {
        // do something
    }
    
    FluentNode DinnerOptions()
    {
        return
            Options
            (
                Option("Pasta!") *
                    Hide() *
                    Yell("Don't tell me what to do!") *
                    End() *
                Option("The blood of my enemies") *
                    Hide() *
                    Yell("Don't tell me what to do!") *
                    End() *
                Option("Fruit loops") *
                    Hide() *
                    Yell("Sure!") *
                    End()
            );
    }

    public override FluentNode Create()
    {
        return
            Show() *
            Write(0, "Hello daughter!") *

            Options
            (
                Option("What's for dinner?") *
                    Write("I don't know, what is for dinner?") *
                    DinnerOptions() *

                Option("Hello!") *
                    Hide() *
                    Yell("Hello! Is there somehting I can do for you?") *
                    Show() *

                Option("Bye !") *
                    Hide() *
                    Yell("Bye bye!") *
                    End()
             );
    }
}
    


