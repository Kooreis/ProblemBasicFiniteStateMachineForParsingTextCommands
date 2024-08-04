class StateMachine {
    ...

    execute(command) {
        const state = this.states[this.currentState];
        if (!state) throw new Error(`State '${this.currentState}' does not exist`);
        state.execute(command, this);
    }
}