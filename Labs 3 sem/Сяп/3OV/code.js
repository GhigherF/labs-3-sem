//              1/2
let arr1=[1,[1,2,[3,4],[5,6]],[2,[4,5],4]];

let arr2 = arr1.reduce((acc, item) => {
    function obxod(array) {
        if (Array.isArray(array)) {
            return array.reduce((subAcc, subItem) => subAcc.concat(obxod(subItem)), []);
        } else {
            return array;
        }
    }
    return acc.concat(obxod(item));
}, []);

console.log(arr2);
////  3
let pivo=
{
    age:17,
        correct(user)
        {
            if (user.age>this.age) return true;
            else return false;
        }
};

let newArr ={key:0,value:0};
let students=[{name:"Lololoshka",age:14,groupId:8},
{name:"Kriper2007",age:19,groupId:4},
{name:"Kurt Cobain",age:27,groupId:15}];
let answer=students.filter(pivo.correct,pivo);
newArr.value=answer;
newArr.key=students[0].groupId;
console.log(newArr);
//// 4
let str="ABC";
let sum='';
for(let i=0;i<str.length;i++)
{
sum+=String(str.codePointAt(i));
}
let str2=sum.replace(/7/g,'1');
console.log("total1:"+sum+'\n'+"total2:"+str2+'\n'+"result:"+(sum-str2));
//5
function extend(a,b)
{
let result=Object.assign(a,b);
return result;
}
console.log(extend({a: 1, b: 2}, {c: 3}));
//6
let n=prompt("Этажей:",'');
let count=1;
for(let i=0;i<n;i++)
{
let pyramide='';
let gap="";
for(let j=0;j<n-i-1;j++)
{
    gap+=" ";
}
for(let j=0;j<count;j++)
{
    pyramide+='*';
}
console.log(gap+pyramide);
count+=2;
}




let gg=["Abc","CDEF"];
let pp=gg.map(gg=>gg.length);
console.log(pp);
