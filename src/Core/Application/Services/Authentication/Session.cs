namespace MW.SAXSAY.Core.Application.Services.Authentication;

public record Session(
    string SessionKey,
    string SessionData,
    DateTimeOffset ExpirateDate
);