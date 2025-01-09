function sum(a,b)
{
    return a+b;
}

//let result=prompt("Сосал?",'');
//console.log(result);    
/////////////////////////////////////////////////////////
console.log("N1: \n");
let proof=""
let a=5;//Number
proof+=typeof(a)+'\n';
let Name="Name";//String
proof+=typeof(Name)+'\n';
let i=0;//Number
proof+=typeof(i)+'\n';
let double=0.23;//Number
proof+=typeof(double)+'\n';
let result=1/0;//Number
proof+=typeof(result)+'\n';
let answer=true;//Bool
proof+=typeof(answer)+'\n';
let no=null;//Null
proof+=typeof(no)+'\n';
console.log(proof);
/////////////////Это почти пруфанёт,но с nullом баг :(
    console.log("N2: \n");
    let proof2="";
let answerTask2=(45/5)*(20/5);

for(let i=1;i<=45;i++)
    {
        
               for(let j=1;j<=21;j++)
                {
                    proof2+="⊠";
                    if (j%5 === 0) proof2+=" ";
                 
                } 
                  proof2+='\n';
               if (i%5===0) proof2+='\n';

            }
console.log(proof2);
console.log(answerTask2);
/////////////////Вот это круто получилось
    console.log("N3: \n");
let i2=2;
let a2 = ++i2;//+1 и использовал
let b2=i2++;//использовал,потом +1
console.log("a"+":"+a2+" b:"+b2+" diff:"+(a2-b2)+" i:"+i2);
//////////////////////////////////////////////////////////
console.log("N4: \n");
let result41=("Котик">"котик")?true:false;//K меньше чем k
console.log(result41+'\n');
let result42=("Котик">"китик")?true:false;//K меньше чем k
console.log(result42+'\n');
let result43=("Кот">"Котик")?true:false;//K меньше чем k
console.log(result43+'\n');
let result44=("Привет">"Пока")?true:false;//K меньше чем k
console.log(result44+'\n');
let result45=(73>"53")?true:false;//K меньше чем k
console.log(result45+'\n');
let result46=(false>0)?true:false;//K меньше чем k
console.log(result46+'\n');
let result47=(54>true)?true:false;//K меньше чем k
console.log(result47+'\n');
let result48=(123>false)?true:false;//K меньше чем k
console.log(result48+'\n');
let result49=(true>"3")?true:false;//K меньше чем k
console.log(result49+'\n');
let result410=(3>"5мм")?true:false;//K меньше чем k
console.log(result410+'\n');
let result411=(8>"-2")?true:false;//K меньше чем k
console.log(result411+'\n');
let result412=(34>"34")?true:false;//K меньше чем k
console.log(result412+'\n');
let result413=(null>undefined)?true:false;//K меньше чем k
console.log(result413+'\n');
///////////////////////////////////////////////////////
console.log("N5: \n");
let flag=false;
let NaMe=prompt( "Say my name",'');
let match=["Марина","МАРИНА","Марина Фёдоровна","МАРИНА ФЁДОРОВНА","Кудлацкая Марина Фёдоровна","КУДЛАЦКАЯ МАРИНА ФЁДОРОВНА"];
for (let i=0;i<6;i++)
{
    if (NaMe===match[i]) flag=true;
}
if (flag===true) console.log("You god damn right");
//////////////////////////////////////////////////////////////////////////////
console.log("N6: \n");
let a3=confirm("Русский сдал?");
let b3=confirm("Матан сдал?");
let c=confirm("Ангийский сдал?");
console.log(a3,b3,c);
if (a3&&b3&&c===true)  console.log("Сигма! Переведён на новый курс") 
    else if (a3||b3||c===true && a3&&b3&&c===false )  console.log("Надеюсь пересдача не Белодеда :)");
        else if (a3||b3||c===false)  console.log(":(  пойдешь топтать боты");
        //////////////////////////////////////////////////////////////////////////////////
        console.log("N7: \n");
       console.log("true+true=",true+true);
        console.log("0+\"5\"=",0+"5");
        console.log("5+\"mm\"=",5+"mm");
        console.log("8/Infinity=",8/Infinity);
        console.log(9*  "\n9");
        console.log("null-1=",null-1);
        console.log("\"5\"-2=","5"-2);
        console.log("\"5px\"-3=","5px"-3);
        console.log("true-3=",true-3);
        console.log("7||0=",7||0);
        //////////////////////////////////////////////////////////////////////////////////////
        console.log("N8: \n");
        for (let i=1;i<=10;i++)
        {
            if (i%2==0)console.log(i+2) 
                else console.log(i+"мм");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
        console.log("N9: \n");
        let week=[{Name:"пн",day:1},{Name:"вт",day:2},{Name:"ср",day:3},{Name:"чт",day:4},{Name:"пт",day:5},{Name:"сб",day:6},{Name:"вс",day:7}];
        let choice=prompt("День недели:","");
if (choice>7||choice<0) alert("Ты што,крэйзи?") 
        else
    {
        for(let i=0;i<7;i++)
        {
            if (week[i].day==choice) console.log(week[i].Name);
        }
    }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        console.log("N10: \n");
        let tmp="LoL";
enter=prompt("Чё-то","");
        function someAction(a="Хихииххахахаха",tmp,enter)
        {
console.log(a+tmp+enter);
        }
        someAction(undefined,tmp,enter);
        ////////////////////////////////////////////////////////////////////////////////
        console.log("N11: \n");
    let a4=prompt("a",'');
    let b=prompt("b",''); 
    let result2=0;
   // Declaration:
        function params(a4,b)
        {
if (a4===b) console.log(4*a4) 
    else console.log(a4*b);
        }
        params(a4,b);
//Expression
let func=function(a4,b)
{
    if (a4===b) result2=4*a4 
   else result2=a4*b;
        return result2;
};
console.log(func(a4,b));
        //Функция-стрелка
        let answer2=(a,b)=>{
            if (a4===b) result=4*a4
             else result=a4*b;
             return result;
        };
       console.log(answer2(a,b));
         
let gg=10|"Кот"|0;
console.log(gg);

