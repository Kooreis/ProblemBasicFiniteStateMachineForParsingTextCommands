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
}