//1.1
// function makeCounter()
// {
// let currentCount=1;
// return function()
// {
//     return currentCount++;
// }
// }
// let counter=makeCounter();
// alert(counter());//1
// alert(counter());//2
// alert(counter());//3


// let counter2=makeCounter();
// alert(counter2());//1

//1.2
// let currentcount=1;

// function makeCounter()
// {
//     return function()
//     {
//         return currentcount++;
//     }
// }

// let counter=makeCounter();
// let counter2=makeCounter();

// alert(counter());//1
// alert(counter());//2


// alert(counter2());//3
// alert(counter2());//4

//2
function V(x)
{
    return (y) =>{
        return(z)=>{
            return x*y*z;
        }
    }
}

let v1=V(5);
console.log(v1(5)(6));
console.log(v1(4)(5));
let v2=V(10);
console.log(v2(5)(6));
console.log(v2(4)(5));
//3


let coordinates={x:10,y:10};

function *genZ(temp)
{
 yield  genV(temp);
 return;
}


function genV(match)
{
    switch(match)
    {
        case 'up':
            coordinates.y++;
            console.log(coordinates.x,coordinates.y);
            break;
        case 'down':
            coordinates.y--;
            console.log(coordinates.x,coordinates.y);
            break;
        case 'left':
            coordinates.x--;
            console.log(coordinates.x,coordinates.y);
            break;
        case 'right':
            coordinates.x++;
            console.log(coordinates.x,coordinates.y);
            break;
    }
}

let directions=["left","left","left","left","left","left","up","left","left","up"];
// for(let i=0;i<10;i++)
// {
//   dir=prompt("Direction:",'');
//   directions.push(dir);
// }
console.log(directions);
for(let i=0;i<10;i++)
{
    console.log(genZ(directions[i]).next());
}
//4
let gg=5;
window.gg=2;
console.log(gg)
console.log(window.gg);

