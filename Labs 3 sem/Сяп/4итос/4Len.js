//1
function Add(set,item)
{
set.add(item);
}
function delet(set,item)
{
    set.delete(item);
}
function has(set,item)
{
    console.log(set.has(item));
}

let items=new Set();
Add(items,"крокодил");
Add(items,"телек");
Add(items,"тралик");

has(items,"телек");
delet(items,"телек");
has(items,"телек");
for(let key of items)
{
    console.log(key);
}
//2
function sAdd(set,item)
{
set.add(item);
}
function sDelete(set,item)
{
    for(key of set) 
    {
        if (key==item)set.delete(key);
    }
}
function sFilter(set,group)
{    
    let temp=new Set();
        for(key of set)
            {
                if (key.group==group)temp.add(key);
            }
            console.log("Группа  "+group+":");
            console.log("---------------------------");
            for(key of temp)
            {
console.log(key);
            }
            console.log("---------------------------");
}
function sSort(set)
{
    let temp=Array.from(set);
temp=temp.sort((a,b)=>a.num-b.num);
set=new Set(temp);
return set;
}


let students = new Set();
let stu1={num:987625,group:"2-8",FIO:"Фредди Фазбер Гигачадович"};
let stu2={num:168257,group:"9-11",FIO:"Майкл Джордан Президентович"};
let stu3={num:432987,group:"2-8",FIO:"Кириллл Денисович Батькович"};
sAdd(students,stu1);
sAdd(students,stu2);
sAdd(students,stu3);
for (key of students)
{
    console.log(key);
}

sFilter(students,"2-8");
students=sSort(students);

console.log("Sort:");
for (key of students)
    {
        console.log(key);
    }

sDelete(students,stu2);

console.log("------------------------------");
for (key of students)
    {
        console.log(key);
    }
//3
function mAdd(map,key,item)
{
map.set(key,item);
}
function mDeleteKey(map,key)
{
map.delete(key);
}
function mDeleteItem(map,item)
{
    for([key,value] of map)
    {
        if (value.name==item) map.delete(key);
    }
}
function mReplace(map,key,item)
{
    let temp=map.get(key);
    temp.amount=item;
    map.delete(key);
    map.set(key,temp);
}

let map=new Map();
let item1={name:"крокодил",amount:400,price:700};
let item2={name:"компы",amount:245000,price:4000};
let item3={name:"хлеб",amount:5626272,price:0.8};
let item4={name:"хлеб",amount:5626272,price:0.8};
mAdd(map,1,item1);
mAdd(map,2,item2);
mAdd(map,3,item3);
mAdd(map,4,item4);
for(key of map)
{
    console.log(key);
}
console.log("------------------------------");
mDeleteKey(map,2);
for(key of map)
{
    console.log(key);
}
console.log("------------------------------");
mDeleteItem(map,"хлеб");
for(key of map)
{
    console.log(key);
}
// let gg=new Map(map) ;
// mReplace(gg,1,228228);
//4
let cache = new WeakMap();

function process(obj) {
  if (!cache.has(obj)) {
console.log("No cache");
let result=obj.a+obj.b;
obj.sum=result;
cache.set(obj,result);
return result;
  }
  else
  {
    console.log("Cache");
    return cache.get(obj);
  }
}

let obj = {a:4,b:5};
let result1 = process(obj);
let result2 = process(obj);



