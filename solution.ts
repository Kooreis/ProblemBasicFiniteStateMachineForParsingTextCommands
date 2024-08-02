Here is a simple implementation of a finite state machine for parsing text commands in TypeScript:

```typescript
enum State {
    Start,
    Command,
    Argument
}

class CommandParser {
    private state: State;
    private command: string;
    private argument: string;

    constructor() {
        this.state = State.Start;
        this.command = '';
        this.argument = '';
    }

    parse(input: string): { command: string, argument: string } {
        for (let i = 0; i < input.length; i++) {
            const char = input[i];

            switch (this.state) {
                case State.Start:
                    if (char !== ' ') {
                        this.state = State.Command;
                        this.command += char;
                    }
                    break;
                case State.Command:
                    if (char === ' ') {
                        this.state = State.Argument;
                    } else {
                        this.command += char;
                    }
                    break;
                case State.Argument:
                    this.argument += char;
                    break;
            }
        }

        const result = { command: this.command, argument: this.argument };

        this.command = '';
        this.argument = '';
        this.state = State.Start;

        return result;
    }
}

const parser = new CommandParser();

console.log(parser.parse('command argument'));
console.log(parser.parse('anotherCommand anotherArgument'));
```

This program defines a `CommandParser` class that uses a finite state machine to parse text commands. The state machine has three states: `Start`, `Command`, and `Argument`. The `parse` method reads the input string one character at a time and transitions between states based on the current character. When it encounters a space, it transitions from the `Command` state to the `Argument` state. The parsed command and argument are returned as an object.