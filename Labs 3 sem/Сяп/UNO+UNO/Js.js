//1
function  basicOperation(operation,value1,value2)
{
    switch(operation)
    {
        case '+' :   
        {
       return +(value1)+(+value2); 
        }
        case '-' :   
        {
       return value1-value2; 
        }
        case '*' :   
        {
       return value1*value2; 
        }
        case '/' :   
        {
       return value1/value2; 
        }
    }
}
let  task1  =   basicOperation( '+' , '5','10');  
console.log("task 1:" + task1);
//2
function cube (n)
{
    let sum=0;
    for (let i=1;i<=n;i++)
    {
        sum+=i**3;
    }
    return sum;
}
let task2=cube(3);
console.log("task 2:" + task2);  
//3
let a=[1,2,3,4,5,8];
function middle (array)
{
    let sum=0;
    for(let i=0;i<array.length;i++)
    {
        sum+=array[i];
    }
    return sum/array.length;
}
let task3=middle(a);
console.log("task 3:"+task3);
//4
let abc='reh09-!gi451;.,/hg1112@@';
//65-90 97-122
function reverse(str)
{
    
    let str2="";
    for(let i=0;i<str.length;i++)
    {
    if (str.charCodeAt(i)<65||str.charCodeAt(i)>90&&str.charCodeAt(i)<97||str.charCodeAt(i)>122)   {str=str.replace(str[i],"0")};
    }
    str=str.replace(/0/g,"");

    for(i=str.length-1;i>=0;i--)
    {
        str2+=str[i];
    }
return str2;
}
console.log("task 4: "+reverse(abc));
//5
let n=4;
let dog="Гав";

function repeat(n,str)
{
    let str2="";
    for (let i=0;i<n;i++)
    {
        str2+=str;
    }
    return str2;
}
console.log("task 5:" + repeat(n,dog));
//6
let one=["Гав","Мяу","Старый Бог!"];
let two =["Гав","Мяу","Мееее"];

    function compare(a,b)
    {
        let k=0;
let c=[];
for (let i=0;i<a.length;i++)
{
    let flag=true;
    for(let j=0;j<b.length;j++)
    {
        if (a[i]==b[j]) flag=false;
    }
    if (flag==true) {c[k]=a[i];k+=1;}
}
    return c;
    } 
    console.log("task 6:"+compare(one,two));