# CommandLine.Commands

## Build status

|Production|CI
|--|--
|[![Build status](https://ci.appveyor.com/api/projects/status/7yqwrr50qfaua3wb/branch/master?svg=true)](https://ci.appveyor.com/project/azachert/commandline-commands/branch/master)|[![Build status](https://ci.appveyor.com/api/projects/status/7yqwrr50qfaua3wb?svg=true)](https://ci.appveyor.com/project/azachert/commandline-commands)

## Introduction

This is an extension to [CommandLineParser](https://github.com/commandlineparser/commandline) project.
## Usage

Create your options class
``` csharp
[Verb("add")]
internal class AddOptions
{
}
```

Create your command handler class
``` csharp
internal class AddCommand : Command<AddOptions>
{
        public override async Task<int> ExecuteAsync(AddOptions options)
        {
            // do your magic here
            // and return some value
        }
}
```

Handle input arguments in Program.Main
``` csharp
class Program 
{
    public static async Task<int> Main(IEnumerable<string> args)
    {
        var commands = new ICommand[] 
        {
	        new AddCommand(),
	        // add your other commands here
        };

        return await Parser.Default.ParseArguments(args, commands)
            .WithNotParsed(result =>
            {
                // handle error
            })
            .WithParsedAsync(commands);	
    }
}
```



## Copyrights & License
Copyrights © Arkadiusz Zachert

This software is licensed based on [MIT License](https://raw.githubusercontent.com/azachert/CommandLineParser.Commands/master/LICENSE)