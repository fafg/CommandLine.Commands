# CommandLine.Verbs

[![Build status](https://ci.appveyor.com/api/projects/status/lii5ru8udg5kb2ae?svg=true)](https://ci.appveyor.com/project/azachert/commandline-verbs)

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

Create your handler class
``` csharp
internal class AddVerb : Verb<AddOptions>
{
        public override async Task<object> ExecuteAsync(AddOptions options)
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
	public static async Task Main(IEnumerable<string> args)
	{
		var verbs = new IVerb[] 
		{
			new AddVerb(),
			// add your other verbs here
		};

		await Parser.Default.ParseArguments(args, verbs)
		    .WithNotParsed(result => {
			    // handle error
		    })
		    .parsed.WithParsedAsync(verbs, returnValue => {
			    // consume returned value
		    });
	}
}
```



## Copyrights & License
Copyrights © Arkadiusz Zachert

This software is licensed based on [MIT License](https://raw.githubusercontent.com/azachert/CommandLineParser.Commands/master/LICENSE)