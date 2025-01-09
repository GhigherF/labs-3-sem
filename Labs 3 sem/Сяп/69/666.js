//1
let numbers=[1,2,3,4,5];
let [y]=numbers;
console.log(y);
//2
user={name:"ghigher",age:18};
let admin={admin:true,...user};
console.log(admin);
//3
let store={
    state:{
        profilePage:{
            posts:[
                {id:1,message:'Hi',likesCount:12},
                {id:2,message:'By',likesCount:1},
            ],
            newPostText:'About me',
        },
        dialogsPage: {
            dialogs:[
                {id:1,name:'Valera'},
                {id:2,name:'Andrey'},
                {id:3,name:'Sasha'},
                {id:4,name:'Viktor'},
            ],
            messages:[
                {id:1,message:'hi'},
                {id:2,message:'hi hi'},
                {id:3,message:'hi hi hi'},
            ],
        },
        sidebar:[],
    },
}

let {state}=store;
let {profilePage,dialogsPage}=state;

let {posts,newPostText}=profilePage;
console.log("------------------------------------------------------------");
for(i of posts)
{
  console.log(i.likesCount);
}
console.log("-------------");
let {dialogs,messages}=dialogsPage;
for(i of dialogs)
{
    if(i.id%2==0) console.log(i)
}
console.log("-------------");
for(i of messages)
{
    
    messages=messages.map(
        (i)=>{
            let temp={id:i.id,message:"Hello user"};
            return temp;
        }
    );
}
console.log(messages);
console.log("------------------------------------------------------------");
//4
let tasks=[
    {id:1,title:"HTML&CSS",isDone:true},
    {id:2,title:"JS",isDone:true},
    {id:3,title:"ReactJs",isDone:false},
    {id:4,title:"Rest API",isDone:false},
    {id:5,title:"CraphQL",isDone:false}
];
let addition={id:7,title:"C++",isDone:true};
tasks={...tasks,addition};
console.log(tasks);
//5
let arr=[1,2,3];
function sumValues(x,y,z)
{
    return x+y+z;
}
console.log(sumValues(...arr));
