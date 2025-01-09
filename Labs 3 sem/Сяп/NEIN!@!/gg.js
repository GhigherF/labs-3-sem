//1
let BigYellowSquare={size:"Big",color:"Yellow",form:"Square"};
let SmallYellowSquare={size:"Small"};
Object.setPrototypeOf(SmallYellowSquare,BigYellowSquare);   
let flag=false;
for (let i in SmallYellowSquare)
{
    if (SmallYellowSquare.hasOwnProperty(i))
    {
        flag=true;
    }
}
console.log(flag);

let BigGreenCircle={size:"Big",color:"Green",form:"Circle"};
let BigWhiteCircle={color:"White"};
Object.setPrototypeOf(BigWhiteCircle,BigGreenCircle);

for (let i in BigWhiteCircle)
{
    if (BigWhiteCircle.hasOwnProperty(i))
    {
        console.log(i);
    }
}

let BigWhiteTriangle1={color:"White",form:"Triangle",lines:1};
let BigWhiteTriangle3={lines:3};
Object.setPrototypeOf(BigWhiteTriangle3,BigWhiteTriangle1);

console.log(BigWhiteTriangle3);

for(let i in BigWhiteTriangle3)
{
console.log(i);
}
//2
class Human
{
    public;
 _age;
_year;
    constructor (name,surname,adress)
    {
        this._name=name;
        this._surname=surname;
        this._adress=adress;
    }

 set age(value)
 {
     this._year=value;
     this._age=2024-value;
 }
 get age()
 {
     return 2024-this._year;
 }
set adress(value)
{
    this._adress=value;
}
}

class Student extends Human
{
    constructor(name,surname,adress,faculty,curse,group,num)
    {   
    super(name,surname,adress);
    this._faculty=faculty;
    this._curse=curse;
    this._group=group;
    this._num=num;
    }
   get num()
   {
    return this._num;
   }
    set curse(value)
    {
        this._curse=value;
    }
    set group(value)
    {
        this._group=value;
    }
    get group()
    {
        return this._group;
    }
get fullName()
{
    return this._name+" "+this._surname;
}
}

class Faculty
{
    _name="IT";
    _numOfGroups=10;
    _numOfStudents=170;

    set numOfGroups(value)
    {
        this._numOfGroups=value;
    }
    set numOfStudents(value)
    {
        this._numOfStudents=value;
    }
    static  getDev(arr)
    {
        for (let i in arr)
        {
            if (Math.floor(arr[i].num/1000000%10)==3) console.log(arr[i]);
        }
    }
    static getGroup(arr,group)
    {
        for (let i in arr)
            {
               if (arr[i].group==group)console.log(arr[i]);
            }
    }
}

// let human=new Human("Kirill","Dmitrochenko","kopeika");
// human. adress="Lenina";
// human.age=2005;
// console.log(human);

let stud=new Student("Kirill","Dmitrochenko","kopeika","IT",2,"10-2",73221666);
stud.age=2006;
stud.public=25;
console.log(stud.public);
let stud2=new Student("Kirill","Dmitrochenko","kopeika","IT",2,"8-1",74221666);
stud2.age=2006;
let arr=[stud,stud2];
Faculty.getDev(arr);
console.log("---------------------------------------")
Faculty.getGroup(arr,"8-1");


// stud.age=2006;
// stud.curse=1;
// stud.group="10-2";
// console.log(stud);
// console.log(stud.fullName);
