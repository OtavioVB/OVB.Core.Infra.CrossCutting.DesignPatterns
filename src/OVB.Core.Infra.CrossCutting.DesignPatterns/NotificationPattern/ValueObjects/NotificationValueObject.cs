using OVB.Core.Infra.CrossCutting.DesignPatterns.NotificationPattern.Enums;
using OVB.Core.Infra.CrossCutting.DesignPatterns.NotificationPattern.Exceptions;

namespace OVB.Core.Infra.CrossCutting.DesignPatterns.NotificationPattern.ValueObjects;

public readonly struct NotificationValueObject
{
    public bool IsValid { get; }
    private string Code { get; }
    private string Message { get; }
    private TypeNotification TypeNotification { get; }
    
    private NotificationValueObject(string code, string message,  TypeNotification typeNotification)
    {
        IsValid = true;
        Code = code;
        Message = message;
        TypeNotification = typeNotification;
    }

    public NotificationContent GetNotification()
        => new NotificationContent(Code, Message, TypeNotification);

    public static NotificationValueObject Build(string code,  string message,  TypeNotification typeNotification)
    {
        NotificationPatternException.ThrowExceptionIfAnyStringIsEmpty(code, message);

        NotificationPatternException.ThrowExceptionIfTheEnumExceedTheExpected(typeNotification);

        NotificationPatternException.ThrowExceptionIfAnyStringHasGreaterThan255Characteres(code, message);

        return new NotificationValueObject( code,  message,  typeNotification);
    }

    public static NotificationValueObject BuildSuccessNotification(string code, string message)
        => Build(code, message, TypeNotification.Success);

    public static NotificationValueObject BuildErrorNotification(string code, string message)
        => Build(code, message, TypeNotification.Error);

    public static NotificationValueObject BuildInformationNotification(string code, string message)
        => Build(code, message, TypeNotification.Information);


    public readonly struct NotificationContent
    {
        public NotificationContent(string code, string message, TypeNotification typeNotification)
        {
            Code = code;
            Message = message;
            TypeNotification = typeNotification;
        }

        public string Code { get; }
        public string Message { get; }
        public TypeNotification TypeNotification { get; }

    }
}
