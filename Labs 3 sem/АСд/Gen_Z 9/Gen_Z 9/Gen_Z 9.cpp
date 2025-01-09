﻿#include <iostream>
#include <vector>
#include <random>
#include <numeric>
#include <iomanip>

using namespace std;


void addCity(int &size, vector<vector<int>>& matrix, pair<pair<int, int>, int>* &arr)
{
	cout << "\n Добавление города:\n";

	size += 1;
	vector<vector<int>> tempMatrix(size, (vector<int>(size, 0)));

	for (int i = 0; i < size - 1; i++)
	{
		for (int j = 0; j < size - 1; j++)
		{
			tempMatrix[i][j] = matrix[i][j];
		}
	}


	for (int i = 1; i < size; i++)
	{
		cout << i << "->" << size << ':';
		cin >> tempMatrix[i - 1][size - 1];

	}


	for (int i = 1; i < size; i++)
	{
		cout << size << "->" << i << ':';
		cin >> tempMatrix[size - 1][i - 1];
	}

	matrix = vector<vector<int>>(size, (vector<int>(size, 0)));
	matrix = tempMatrix;


	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << setw(3) << setfill(' ') << matrix[i][j] << " ";
		}
		cout << '\n';
	}


	arr = new pair<pair<int, int>, int>[(size * size) - size];
	int k = 0;

	for (int i = 1; i <= size; i++)
	{
		for (int j = 1; j <= size; j++)
		{
			if (i == j) continue;

			arr[k].first.first = i, arr[k].first.second = j, arr[k].second = matrix[i - 1][j - 1];

			k += 1;
		}
	}
	cout << "\n-------------------------------------------------------------------------------------\n";
	for (int i = 0; i < size * size - size; i++)
	{
		cout << arr[i].first.first << "->" << arr[i].first.second << "  :" << arr[i].second << '\n';
	}

}




void deleteCity(int& size, vector<vector<int>>& matrix, pair<pair<int, int>, int>*& arr) {
	cout << "\nУдаление города:\n";
	if (size <= 1) {
		cout << "Удаление невозможно: в графе должен остаться хотя бы один город.\n";
		return;
	}

	cout << "Введите номер города для удаления (1-" << size << "): ";
	int cityToDelete;
	cin >> cityToDelete;

	if (cityToDelete < 1 || cityToDelete > size) {
		cout << "Ошибка: введен некорректный номер города.\n";
		return;
	}

	// Уменьшаем размер
	int newSize = size - 1;
	vector<vector<int>> tempMatrix(newSize, vector<int>(newSize, 0));

	// Переносим данные, исключая удаляемый город
	int offsetRow = 0, offsetCol = 0;
	for (int i = 0; i < size; ++i) {
		if (i + 1 == cityToDelete) {
			offsetRow = 1;
			continue;
		}
		offsetCol = 0;
		for (int j = 0; j < size; ++j) {
			if (j + 1 == cityToDelete) {
				offsetCol = 1;
				continue;
			}
			tempMatrix[i - offsetRow][j - offsetCol] = matrix[i][j];
		}
	}

	matrix = tempMatrix;
	size = newSize;

	// Пересоздаем массив arr
	delete[] arr;
	arr = new pair<pair<int, int>, int>[(size * size) - size];
	int k = 0;

	for (int i = 1; i <= size; i++) {
		for (int j = 1; j <= size; j++) {
			if (i == j) continue;
			arr[k].first.first = i;
			arr[k].first.second = j;
			arr[k].second = matrix[i - 1][j - 1];
			k++;
		}
	}

	cout << "\nОбновленная матрица смежности:\n";
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < size; j++) {
			cout << setw(3) << setfill(' ') << matrix[i][j] << " ";
		}
		cout << '\n';
	}

	cout << "\nОбновленный список ребер:\n";
	for (int i = 0; i < size * size - size; i++) {
		cout << arr[i].first.first << "->" << arr[i].first.second << "  :" << arr[i].second << '\n';
	}
	cout << "Город успешно удален!\n";
}










pair<vector<int>, int> crossoverOX(pair<vector<int>, int>& parent1, pair<vector<int>, int>& parent2, pair<pair<int, int>, int>* arr, int N) {
	bool flag = false;
	int size = parent1.first.size();
	pair<vector<int>, int> child = make_pair(vector<int>(size, 0), 0);

	do
	{
	    child = make_pair(vector<int>(size, 0), 0);
		int start = rand() % size;
		int end = rand() % size;

		if (start > end) swap(start, end);

		for (int i = start; i <= end; ++i) {
			child.first[i] = parent1.first[i];
		}

		int idx = (end + 1) % size;
		for (int i = 0; i < size; ++i) {
			int gene = parent2.first[(end + 1 + i) % size];
			if (find(child.first.begin(), child.first.end(), gene) == child.first.end()) {
				child.first[idx] = gene;
				idx = (idx + 1) % size;
			}
		}

	

		child.second = 0;
		for (int i = 0; i < child.first.size() - 1; i++)
		{
			flag = false;
			for (int j = 0; j < N; j++)
			{
				if (arr[j].first.first == child.first[i] && arr[j].first.second == child.first[i + 1])
				{
					flag = true;
					child.second += arr[j].second;
				}
			}
			if (flag == false) break;
		}
	} while (!flag);
	/*cout << "\nChild:"<< '\n';
	for (int i = 0; i < child.first.size(); i++)
	{
		cout << "->" << child.first[i];
	}
	cout << "  " << child.second << '\n';*/
	return child;
}

void mutate(pair<vector<int>, int>& individual, pair<pair<int, int>, int>* arr, int N) {
	int size = individual.first.size();
	int idx1 = rand() % size;
	int idx2 = rand() % size;
	swap(individual.first[idx1], individual.first[idx2]);

	individual.second = 0;
	for (int i = 0; i < individual.first.size()-1; i++)
	{
		for (int j = 0; j < N; j++)
		{
			if (arr[j].first.first == individual.first[i] && arr[j].first.second == individual.first[i + 1])
			{
				individual.second += arr[j].second;
			}
		}
	}
	/*cout << "\nMut:"<<'\n';
	for (int i = 0; i < individual.first.size(); i++)
	{
		cout << "->" << individual.first[i];
	}
	cout << "  " << individual.second << '\n';*/
}


pair<vector<int>, int> selectParent(vector<pair<vector<int>, int>>& population, const vector<double>& fitness) {
	double totalFitness = accumulate(fitness.begin(), fitness.end(), 0.0);
	double randomValue = ((double)rand() / RAND_MAX) * totalFitness;

	double cumulativeFitness = 0.0;
	for (size_t i = 0; i < fitness.size(); ++i) {
		cumulativeFitness += fitness[i];
		if (cumulativeFitness >= randomValue) {
			return population[i];
		}
	}
	return population.back();
}


vector<pair<vector<int>,int>> generateInitialPopulation(int populationSize, int cityCount, pair<pair<int, int>, int>* arr,int N) {
	srand(time(NULL));

	vector<pair<vector<int>, int>> population(populationSize, make_pair(vector<int>(cityCount, 0), 0));
	
	for (auto& solo : population) {
		bool valid = false;
		do {
			iota(solo.first.begin(), solo.first.end(), 1);
			shuffle(solo.first.begin(), solo.first.end(), mt19937(random_device()()));

			solo.second = 0;
			valid = true;   

			for (int i = 0; i < cityCount - 1; i++) {
				bool matchFound = false;

				for (int j = 0; j < N; j++) {
					if (arr[j].first.first == solo.first[i] && arr[j].first.second == solo.first[i + 1]) {
						matchFound = true;          
						solo.second += arr[j].second; 
						break;                      
					}
				}

				if (!matchFound) {
					valid = false; 
					break;         
				}
			}
		} while (!valid); 
	}
	return population;
}


void main()
{
	setlocale(LC_ALL, "Russian");

	int size = 8;
	pair<pair<int, int>, int>* arr = new pair<pair<int, int>, int>[(size * size) - size];



	vector<vector<int>> matrix = {
	{ 0,8,11,12,40,22,9,5},//1
	{ 8,0,9,8,19,23,4,11},//2
	{ 11,9,0,1,31,16,9,5},//3
	{ 12,8,1,0,14,11,33,24},//4
	{ 40,19,31,14,0,30,7,20},//5
	{ 22,23,16,11,30,0,15,2},//6
	{ 9,4,9,33,7,15,0,2},//7
	{ 5,11,5,24,20,2,2,0}//8
	};

	int k = 0;
	for (int i = 1; i <= size; i++)
	{
		for (int j = 1; j <= size; j++)
		{
			if (i == j) continue;

			arr[k].first.first = i, arr[k].first.second = j, arr[k].second = matrix[i - 1][j - 1];

			k += 1;
		}
	}



	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << setw(3) << setfill(' ') << matrix[i][j] << " ";
		}
		cout << "\n\n";
	}

	cout << "\n\n";

	for (int i = 0; i < size * size - size; i++)
	{
		cout << arr[i].first.first << "->" << arr[i].first.second << "  :" << arr[i].second << '\n';
	}


	while (true)
	{
		int choice;
		cout << "\n\n\n\n\n\n\n\n\n1.Do\n2.AddCity\n3.Delete\nChoice:";
		cin >> choice;

		switch (choice)
		{
		case 1:
		{
			cout << "\nНачальная поппуляция:";
			int startPopualation;
			cin >> startPopualation;



			cout << "\nЧисло эволюций:";
			int generations;
			cin >> generations;

			cout << "\nМутация:";
			double mutation;
			cin >> mutation;

			auto population = generateInitialPopulation(startPopualation, size, arr, size * size - size);
			cout << "\n\n\n";


			for (int generation = 0; generation < generations; ++generation) {

				vector<double> fitness(population.size());
				for (size_t i = 0; i < population.size(); ++i) {
					fitness[i] = 1.0 / population[i].second;
				}
				vector<pair<vector<int>, int>>  newPopulation;
				for (size_t i = 0; i < population.size() / 2; ++i) {
					pair<vector<int>, int> parent1 = selectParent(population, fitness);
					pair<vector<int>, int> parent2 = selectParent(population, fitness);

					pair<vector<int>, int> child1 = crossoverOX(parent1, parent2, arr, size * size - size);
					pair<vector<int>, int> child2 = crossoverOX(parent2, parent1, arr, size * size - size);

					if (((double)rand() / RAND_MAX) < mutation) mutate(child1, arr, size * size - size);
					if (((double)rand() / RAND_MAX) < mutation) mutate(child2, arr, size * size - size);

					newPopulation.push_back(child1);
					newPopulation.push_back(child2);
				}
				population = move(newPopulation);

				int minDistance = INT_MAX;
				pair<vector<int>, int> bestInGeneration;
				for (const auto& individual : population) {
					if (individual.second < minDistance) {
						minDistance = individual.second;
						bestInGeneration = individual;
					}
				}
				cout << generation + 1 << ": ";
				for (const auto& city : bestInGeneration.first) {
					cout << "->" << city;
				}
				cout << ": " << bestInGeneration.second << '\n';
			}

			double bestFitness = -numeric_limits<double>::infinity();
			pair<vector<int>, int> bestIndividual;
			for (const auto& individual : population)
			{
				double currentFitness = 1.0 / individual.second;
				if (currentFitness > bestFitness) {
					bestFitness = currentFitness;
					bestIndividual = individual;
				}
			}

			cout << "\n\n\n";
			for (auto i : bestIndividual.first)
			{
				cout << "->" << i;
			}
			cout << "  " << bestIndividual.second;
			exit(69);
		}
		case 2:
		{
			addCity(size, matrix, arr);
			break;
		}
		case 3: {
			deleteCity(size, matrix, arr);
			break;
		}
		}
	}
}