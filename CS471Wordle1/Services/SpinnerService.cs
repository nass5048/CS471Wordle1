using System;

namespace Services;

public class SpinnerService
{
    // Tracks whether the loading spinner is currently visible
    public bool IsShowing { get; private set; }

    // Event with current visibility state
    public event Action<bool>? OnChange;

    /*
        Function Name: Show
        Input: N/A
        Output: N/A
        Brief description:
            Displays spinner
    */

    public void Show() => Toggle(true);

    /*
        Function Name: Hide
        Input: N/A
        Output: N/A
        Brief description:
            Hides spinner
    */
    
    public void Hide() => Toggle(false);

    /*
        Function Name: Toggle 
        Input: true (should be shown) or false (should be hidden)
        Output: N/A
        Brief description:
            Updates spinner visbility state
    */    

    public void Toggle(bool show)
    {
        if (IsShowing == show) return;
        IsShowing = show;
        OnChange?.Invoke(IsShowing);
    }
}