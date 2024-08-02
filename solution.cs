Here is a simple implementation of a finite state machine for parsing text commands in JavaScript:

```javascript
class StateMachine {
    constructor() {
        this.states = {};
        this.currentState = null;
    }

    addState(name, type) {
        this.states[name] = type;
        if (!this.currentState) this.currentState = name;
    }

    transition(newState) {
        this.currentState = newState;
    }

    execute(command) {
        const state = this.states[this.currentState];
        if (!state) throw new Error(`State '${this.currentState}' does not exist`);
        state.execute(command, this);
    }
}

class State {
    execute(command, stateMachine) {
        throw new Error('execute method must be overridden');
    }
}

class CommandState extends State {
    execute(command, stateMachine) {
        console.log(`Executing command '${command}' in state '${stateMachine.currentState}'`);
        if (command === 'NEXT') stateMachine.transition('nextState');
    }
}

class NextState extends State {
    execute(command, stateMachine) {
        console.log(`Executing command '${command}' in state '${stateMachine.currentState}'`);
        if (command === 'PREV') stateMachine.transition('commandState');
    }
}

const stateMachine = new StateMachine();
stateMachine.addState('commandState', new CommandState());
stateMachine.addState('nextState', new NextState());

stateMachine.execute('NEXT');
stateMachine.execute('PREV');
```

This code defines a `StateMachine` class that maintains a dictionary of states and the current state. The `addState` method is used to add new states to the machine, and the `transition` method is used to transition between states. The `execute` method is used to execute a command in the current state.

The `State` class is a base class for all states. It defines an `execute` method that throws an error if it is not overridden in a derived class.

The `CommandState` and `NextState` classes are derived from the `State` class and override the `execute` method to execute commands and transition to other states.

The last part of the code creates a state machine, adds the `CommandState` and `NextState` states to it, and executes some commands.