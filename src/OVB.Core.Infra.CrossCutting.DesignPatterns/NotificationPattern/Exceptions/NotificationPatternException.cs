using OVB.Core.Infra.CrossCutting.DesignPatterns.NotificationPattern.Enums;

namespace OVB.Core.Infra.CrossCutting.DesignPatterns.NotificationPattern.Exceptions;

public sealed class NotificationPatternException : Exception
{
    public string Reason { get; }

    private NotificationPatternException(string reason)
    {
        Reason = reason;
    }

    public static void ThrowExceptionIfAnyStringIsEmpty(params string[] strings)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            if (strings[i] == string.Empty)
                throw new NotificationPatternException("The string of notification cannot be empty.");
        }
    }

    public static void ThrowExceptionIfAnyStringHasGreaterThan255Characteres(params string[] strings)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            if (strings[i].Length > 255)
                throw new NotificationPatternException("The string of notification needs to has less than or equal to 255 characters.");
        }
    }

    public static void ThrowExceptionIfTheEnumExceedTheExpected(TypeNotification typeNotification)
    {
        if (Enum.IsDefined(typeNotification) == false)
            throw new NotificationPatternException("The type of notification needs to be defined.");
    }

    public static NotificationPatternException Build(string reason)
        => new NotificationPatternException(reason);
}
