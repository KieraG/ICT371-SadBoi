using UnityEngine;
using Fluent;

/// <summary>
/// This example shows you how to execute code when an option is selected
/// </summary>
public class MumDialogue : MyFluentDialogue
{

    private void SomeFunction()
    {
        // do something
    }

    public override FluentNode Create()
    {
        return
            Show() *
            Write(0, "Time to realise your choices affect the world!") *

            Options
            (
                Option("Make me pink!") *
                    Write("Abara Kadabara!") *
                    Do(() => SomeFunction()) *

                Option("Make me blue!") *
                    Hide() *
                    Yell("Abara Kadabara!") *
                    Do(() => SomeFunction()) *
                    Pause(1) *
                    Show() *

                Option("Bye !") *
                    Hide() *
                    Yell("Bye bye!") *
                    End()
             );
    }
}
    


