#pragma once

using namespace System;
using namespace System::Windows::Forms;

// Базовый управляемый класс Поля
ref class Fields {
protected: 
	String^ fullname;
	int course;
	int academicPerfomance;
	int progress;

public:
	Fields(); 
	String^ GetFullName(); 
	void SetFullName(String^ newFullName);
	int GetCourse();
	void SetCourse(int newCourse);
	int GetAcademicPerfomance();
	void SetAcademicPerfomance(int newAcademicPerfomance);
	int GetProgress();
	void SetProgress(int newProgress);
};

// Управляемый производный класс для рассчетов стипендии студентов 
ref class CalculationStudentsScholarship : Fields
{
	// Поля класса
private: 
	float baseRate = 5000;

	// Методы класса
public: 
	CalculationStudentsScholarship();								// конструктор по умолчанию - создает пустой объект класса
	CalculationStudentsScholarship(String^ _fullname, int _course,	// конструктор с параметрами - задает данные объекту класса
		int _academicPerfomance, int _progress);
	~CalculationStudentsScholarship();								// деструктор - удаляет объект класса

	void SetFiellds(String^ _fullname, int _course,	// задает поля объекта
		int _academicPerfomance, int _progress);
	void SetBaseRate(float newBaseRate); //метод для изменения базовой ставки
	String^ Calculation(); // рассчет
};

