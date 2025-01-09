//1
let person = {
  greet() {
    console.log(`Greetings,${this.name}!`);
  },
  ageAfterYears(years) {
    return this.age + years;
  },
};
person.name = "ghigher";
person.age = 18;
person.greet();
console.log(person.ageAfterYears(5));
//2
let car = {
  model: "Lada Kalina",
  year: 1514,
  getInfo() {
    console.log(`The car is a ${this.model} from ${this.year}.`);
  },
};
car.getInfo();
//3
function Book() {
  (this.getTitle = function () {
    return this.title;
  }),
    (this.getAuthor = function () {
      return this.author;
    });
}
let book = new Book();
book.title = "1984";
book.author = "George Orwell";
console.log(book.getTitle());
console.log(book.getAuthor());
//4
let team = {
  players: [
    { name: "Ghigher", elo: 52 },
    { name: "Mohhamed", elo: 10 },
  ],
  info() {
    this.players.forEach((player) =>
      console.log(player.name + "'s Elo: " + player.elo)
    );
  },
};
team.info();
//5
const counter = (function () {
  count = 0;
  return {
    increment() {
      return ++count;
    },
    decrement() {
      return --count;
    },
    getCount() {
      return count;
    },
  };
})();
console.log(counter.increment());
console.log(counter.increment());
console.log(counter.decrement());
console.log(counter.getCount());

//6
let item = { price: 5 };
item.price = 777;
Object.defineProperty(item, "price", { writable: false });
item.price = 2;
console.log(item.price);
//7
let cirlce = {
  get radius() {
    return radius;
  },
  set radius(value) {
    radius = value * value * Math.PI;
  },
};
cirlce.radius = 5;
console.log(cirlce.radius);
//8
car = {
  make: "Lada",
  model: "Kalina",
  year: 1514,
};
Object.defineProperty(car, "make", { writable: false, configurable: false });
Object.defineProperty(car, "model", { writable: false, configurable: false });
Object.defineProperty(car, "year", { writable: false, configurable: false });
car.make = "BMW";
car.model = "X5";
car.year = 2020;
delete car.make;
delete car.model;
delete car.year;
console.log(car);
//9
let arr = [5, 10, 15];
Object.defineProperty(arr, "sum", {
  get () {
    let sum = 0;
    for (let i in arr) {
      sum += arr[i];
    }
    return sum;
  },
  set(value) {}
});
arr.sum = 567;
console.log(arr.sum);
//10
let rectangle = {
      get width() {
      return width;
    },
    set width(value) {
      width = value;
    },
    get height() {
      return height;
    },
    set height(value) {
      height = value;
    },
  get S() 
  {
    return width * height;
  },
};
rectangle.height=5;
rectangle.width=10;
console.log(rectangle.S);
//11
let user = {
  firstName: "Freddy",
  lastName: "Fazber",
  get fullName()
   {
   return `${this.firstName} ${this.lastName}` 
  },
  set fullName(value)
  {
    [this.firstName, this.lastName] = value.split(" ");
  }
};
user.fullName = "ghigher gigachadovich";
console.log(user.fullName);