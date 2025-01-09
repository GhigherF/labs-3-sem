class Sudoku {
  constructor() {
    this._gameField = Array.from({ length: 9 }, () => Array(9));
  }

  check(row, col, num) {
    for (let i = 0; i < 9; i++) {
      if (this._gameField[row][i] === num) {
        return false;
      }
    }
    for (let i = 0; i < 9; i++) {
      if (this._gameField[i][col] === num) {
        return false;
      }
    }

    for (
      let i = Math.floor(row / 3) * 3;
      i < Math.floor(row / 3) * 3 + 3;
      i++
    ) {
      for (
        let j = Math.floor(col / 3) * 3;
        j < Math.floor(col / 3) * 3 + 3;
        j++
      ) {
        if (this._gameField[i][j] === num) {
          return false;
        }
      }
    }
    return true;
  }

  generate() {
    this._gameField = Array.from({ length: 9 }, () => Array(9));
    this.generateGrid();
  }

  generateGrid(row = 0, col = 0) {
    if (row === 9) {
      return true;
    }

    if (col === 9) {
      return this.generateGrid(row + 1, 0);
    }

    const numbers = this.shuffle(Array.from({ length: 9 }, (_, i) => i + 1));

    for (let num of numbers) {
      if (this.check(row, col, num)) {
        this._gameField[row][col] = num;

        if (this.generateGrid(row, col + 1)) {
          return true;
        }

        this._gameField[row][col] = 0;
      }
    }

    return false;
  }

  globalCheck() {
    let visited = new Set();
    for (let i = 0; i < 9; i++) {
      visited = new Set();
      for (let j = 0; j < 9; j++) {
        if (visited.has(this._gameField[i][j])) {
          console.log("Error:");
          console.log("Line: " + (i));
          console.log("Column: " + (j + 1));
          console.log(
            "Square: " + (Math.floor(i / 3) * 3 + Math.floor(j / 3) + 1)
          );
          return false;
        } else {
          visited.add(this._gameField[i][j]);
        }
      }
    }

    for (let j = 0; j < 9; j++) {
      visited = new Set();
      for (let i = 0; i < 9; i++) {
        if (visited.has(this._gameField[i][j])) {
          console.log("Error:");
          console.log("Line: " + (i));
          console.log("Column: " + (j + 1));
          console.log(
            "Square: " + (Math.floor(i / 3) * 3 + Math.floor(j / 3) + 1)
          );
          return false;
        } else {
          visited.add(this._gameField[i][j]);
        }
      }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    for (let squareRow= 0; squareRow < 3; squareRow++) {
      for (let squareCol = 0; squareCol < 3; squareCol++) {
        visited = new Set();
        for (let i = squareRow * 3; i < squareRow * 3 + 3; i++) {
          for (let j = squareCol * 3; j < squareCol * 3 + 3; j++) {
            if (visited.has(this._gameField[i][j])) {
              console.log("Error:");
              console.log("Line: " + (i));

              console.log("Column: " + (j+1));
              console.log("Square: " + (squareRow * 3 + squareCol + 1));
              return false;
            } else {
              visited.add(this._gameField[i][j]);
            }
          }
        }
      }
    }

    return true;
  }

  shuffle(array) {
    for (let i = array.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]];
    }
    return array;
  }

  Out() {
    console.log(this._gameField);
  }

  Reset() {
    this._gameField = Array.from({ length: 9 }, () => Array(9));
  }
}

gg = new Sudoku();
gg.generate();
gg.Out();
gg._gameField[2][4]=9;
console.log(gg.globalCheck());
