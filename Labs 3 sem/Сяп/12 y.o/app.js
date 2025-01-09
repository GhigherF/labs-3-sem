document.addEventListener('DOMContentLoaded', () => {
    const sudoku = new Sudoku();
    const inputs = document.querySelectorAll('.grid input');

    const renderField = () => {
        sudoku._gameField.forEach((row, i) => {
            row.forEach((num, j) => {
                inputs[i * 9 + j].value = num || '';
            });
        });
    };

    const renderNewField = () => {
        sudoku.generate();
        const blanks = new Set();
        while (blanks.size < 10) { 
            blanks.add(Math.floor(Math.random() * 81));
        }

        inputs.forEach((input, index) => {
            const row = Math.floor(index / 9);
            const col = index % 9;
            if (blanks.has(index)) {
                input.value = '';
                sudoku._gameField[row][col] = 0; 
            } else {
                input.value = sudoku._gameField[row][col];
            }
        });
    };



    const getFieldFromInputs = () => {
        inputs.forEach((input, index) => {
            const row = Math.floor(index / 9);
            const col = index % 9;
            sudoku._gameField[row][col] = parseInt(input.value) || 0;
        });
    };

    const highlightErrors = () => {
        inputs.forEach(input => input.style.backgroundColor = '');
        sudoku._gameField.forEach((row, i) => {
            row.forEach((num, j) => {
                if (!sudoku.check(i, j, num)) {
                    const cellIndex = i * 9 + j;
                    inputs[cellIndex].style.backgroundColor = 'red';
                }
            });
        });
    };

    const highlightSuccess = () => {
        inputs.forEach(input => input.style.backgroundColor = 'yellow');
    };

    document.getElementById('reset-field').addEventListener('click', () => {
        sudoku.Reset();
        renderNewField();
    });

    document.getElementById('check-field').addEventListener('click', () => {
        getFieldFromInputs();
        if (sudoku.globalCheck()) {
            highlightSuccess();
        } else {
            highlightErrors();
        }
    });

    document.getElementById('generate-solution').addEventListener('click', () => {
        sudoku.generate();
        renderField();
    });

    renderNewField();
});
