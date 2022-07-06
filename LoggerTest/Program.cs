// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;

Console.WriteLine("Hello, World!");

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    // reloadOnChange will allow you to auto reload the minimum level and level switches
    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true) 
    .AddEnvironmentVariables()
    .Build();


var levelSwitch = new LoggingLevelSwitch();
levelSwitch.MinimumLevel = LogEventLevel.Information;//  (LogEventLevel)Enum.Parse(typeof(LogEventLevel), configuration["Serilog:LevelSwitches:$consoleSwitch"] ?? "Information", true);

var myMoo = configuration["moo"];
    

// build Serilog logger from IConfiguration
var log = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .MinimumLevel.ControlledBy(levelSwitch)
    .CreateLogger();


while (true)
{
    log.Verbose("This is a Verbose log message");
    log.Debug("This is a Debug log message");
    log.Information("This is an Information log message");
    log.Warning("This is a Warning log message");
    log.Error("This is a Error log message");
    log.Fatal("This is a Fatal log message");

    Console.WriteLine("LOGLEVEL : " + configuration["Serilog:LevelSwitches:$consoleSwitch"]);
    Console.WriteLine("Moo? : " + myMoo);
    
    await Task.Delay(2000);
}
