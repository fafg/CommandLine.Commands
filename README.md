# CommandLineParser.Commands

[![Build status](https://ci.appveyor.com/api/projects/status/3mii1nsbg8hig49o?svg=true)](https://ci.appveyor.com/project/azachert/commandlineparser-commands)

## Introduction

This is an extension to [CommandLineParser](https://github.com/commandlineparser/commandline) project.
## Usage

``` csharp
class Program 
{
	public static async Task Main(IEnumerable<string> args)
	{
		var commands = new ICommand[] 
		{
			// add your commands here
		};

		var parsed = Parser.Default.ParseArguments(args, commands);
		await parsed.WithParsedAsync(commands, returnValue => {
			// consume returned value
		});
		parsed.WithNotParsed(result => {
			// handle error
		});
	}
}
```


## Copyrights & License
Copyrights (C) Arkadiusz Zachert

This software is licensed based on [MIT License](https://raw.githubusercontent.com/azachert/CommandLineParser.Commands/master/LICENSE)