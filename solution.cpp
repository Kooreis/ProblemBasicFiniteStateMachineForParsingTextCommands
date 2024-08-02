```cpp
#include <iostream>
#include <string>
#include <map>
#include <functional>

enum class State {
    Start,
    Command,
    Argument,
    End
};

class StateMachine {
public:
    StateMachine() {
        transitions[State::Start][std::isalpha] = State::Command;
        transitions[State::Command][std::isalpha] = State::Command;
        transitions[State::Command][std::isspace] = State::Argument;
        transitions[State::Argument][std::isalnum] = State::Argument;
        transitions[State::Argument][std::isspace] = State::End;
        transitions[State::End][std::isalnum] = State::Argument;
    }

    void parse(const std::string& text) {
        State state = State::Start;
        std::string command;
        std::string argument;

        for (char c : text) {
            State oldState = state;
            state = transitions[state][std::isalnum(c) ? std::isalnum : std::isspace];

            switch (state) {
            case State::Command:
                if (oldState == State::Command) command.push_back(c);
                else command = c;
                break;
            case State::Argument:
                if (oldState == State::Argument) argument.push_back(c);
                else argument = c;
                break;
            case State::End:
                std::cout << "Command: " << command << ", Argument: " << argument << std::endl;
                break;
            default:
                break;
            }
        }

        if (state == State::Argument) {
            std::cout << "Command: " << command << ", Argument: " << argument << std::endl;
        }
    }

private:
    std::map<State, std::map<std::function<int(int)>, State>> transitions;
};

int main() {
    StateMachine fsm;
    fsm.parse("command1 argument1 command2 argument2");
    return 0;
}
```