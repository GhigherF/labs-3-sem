let idTask=0;
let idList=0;
let state=["Не выполнена","Выполнена"];

class Task
{
   _id;
    _name;
    _status;
    constructor(name)
    {
       this._id=idTask++;
        this._name=name;
        this._status=state[0];
    }
    get name()
    {
        return  this._name;
    }
    set name(value)
    {
       this. _name=value;
    }
    get id()
    {
        return this._id;
    }
    changeStatus()
    {
       this._status = this._status === state[0] ? state[1] : state[0];
    }
}

class ToDoList
{
    _id;
    _name;
    _list;

    constructor(name)
    {
        this._id=idList++;
        this._name=name;
        this._list=[];
    }
    set name(value)
    {
       this. _name=value;
    }
get name()
    {
        return  this._name;
    }
    Add(task)
    {
this._list.push(task);
this._status=state[1];
    }
    Delete(name)
    {
        this._list.splice(this._list.indexOf(name),1);
    }
}


let task1=new Task("Купить слона");
// console.log("-------------------------------------------------------------");
// console.log(task1);
// task1.changeStatus();
// console.log(task1);
// task1.name="Купить Бугатти";
// console.log(task1);
let task2=new Task("Сдать Лабу");
let list1=new ToDoList("Планы на жизнь");
list1.Add(task1);
list1.Add(task2);
task2.changeStatus();
list1.Delete(task2.name);
console.log(list1);

function gg()
{
    alert ("TEST");
}