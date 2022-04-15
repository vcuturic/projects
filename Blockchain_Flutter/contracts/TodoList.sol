pragma solidity 0.5.16;

contract todoList{
    uint public taskCount;

    struct Task{
        string taskName;
        bool isCompleted;
    }

    mapping(uint => Task) public todos;

    event TaskCreated(string task, uint taskNumber);
    // na ove evente moze da se subskrajba sa fronta (Mozda je resenje)

    constructor() public {
        taskCount = 0 ;
    }

    function createTask(string memory _taskName) public{
        todos[taskCount++] = Task(_taskName, false);
        emit TaskCreated(_taskName, taskCount-1);
    }
}