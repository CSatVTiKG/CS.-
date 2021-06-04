#include "MyForm.h"

using namespace System;
using namespace System::IO;
using namespace System::Windows::Forms;

//точка входа для приложения, для того, чтобы можно было запустить 
[STAThreadAttribute]
void main(array<String^>^ args) {
	System::Windows::Forms::Application::EnableVisualStyles();
	System::Windows::Forms::Application::SetCompatibleTextRenderingDefault(false);

	Сalculatingastudentsscholarship::MyForm form;
	System::Windows::Forms::Application::Run(% form);
}

Сalculatingastudentsscholarship::MyForm::MyForm(void)
{
	// Инициализация компонентов
	InitializeComponent();
	calculationStudentsScholarship = gcnew CalculationStudentsScholarship();

	dataGridView->TopLeftHeaderCell->Value = "№";
}

System::Void Сalculatingastudentsscholarship::MyForm::buttonCalculate_Click(System::Object^ sender, System::EventArgs^ e)
{
	// Считываем данные
	String^ fullname;
	int course;
	int academicPerfomance;
	int progress;

	fullname = textBoxFullname->Text;
	if (fullname == "") {
		MessageBox::Show("Введите ФИО студента!","Внимание!");
		return;
	}

	course = comboBoxCourse->SelectedIndex;
	if (course == -1) {
		MessageBox::Show("Выберите курс студента!", "Внимание!");
		return;
	}

	academicPerfomance = comboBoxAcademicPerfomance->SelectedIndex;
	if (academicPerfomance == -1) {
		MessageBox::Show("Выберите успеваемость студента!", "Внимание!");
		return;
	}
	else {
		// Формируем необходимые данные относительно выбранного пункта
		switch (academicPerfomance)
		{
		case 0:
			academicPerfomance = 5;
			break;

		case 1:
			academicPerfomance = 4;
			break;

		case 2:
			academicPerfomance = 3;
			break;

		case 3:
			academicPerfomance = 2;
			break;

		default:
			break;
		}
	}

	progress = comboBoxProgress->SelectedIndex;
	if (progress == -1) {
		MessageBox::Show("Выберите достижения студента!", "Внимание!");
		return;
	}

	// Задаем данные для подсчета
	calculationStudentsScholarship->SetFiellds(fullname, course, academicPerfomance, progress);

	// Запомним результат
	result = calculationStudentsScholarship->Calculation();

	// Вывод результата
	//MessageBox::Show(result, "Результат!");

	// Добавляем данные в таблицу
	dataGridView->Rows->Add(fullname, comboBoxCourse->Items[comboBoxCourse->SelectedIndex]->ToString(),
		comboBoxAcademicPerfomance->Items[comboBoxAcademicPerfomance->SelectedIndex]->ToString(),
		comboBoxProgress->Items[comboBoxProgress->SelectedIndex]->ToString(), result);
}

System::Void Сalculatingastudentsscholarship::MyForm::выходToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e)
{
	if (MessageBox::Show("Завершить работу?", "Выход!", MessageBoxButtons::YesNo) == System::Windows::Forms::DialogResult::Yes)
		System::Windows::Forms::Application::Exit();
}

System::Void Сalculatingastudentsscholarship::MyForm::оПрогрраммеToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e)
{
	MessageBox::Show("Работу выполнил: студент гр.БО921ПРИ Славников Б.В. \nДанные о прогрмамме: программа предназначена для расчета стипендии студентов ВУЗа ","Информация о программе! ");
}



System::Void Сalculatingastudentsscholarship::MyForm::dataGridView_RowsAdded(System::Object^ sender, System::Windows::Forms::DataGridViewRowsAddedEventArgs^ e)
{
	for (int i = 0; i < dataGridView->Rows->Count; i++) {
		dataGridView->Rows[i]->HeaderCell->Value = Convert::ToString(i + 1);
	}
}

System::Void Сalculatingastudentsscholarship::MyForm::сохранитьВEXCELToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e)
{
	Microsoft::Office::Interop::Excel::Application^ ExcelApp = gcnew Microsoft::Office::Interop::Excel::Application();
	Microsoft::Office::Interop::Excel::Workbook^ ExcelWorkBook;
	Microsoft::Office::Interop::Excel::Worksheet^ ExcelWorkSheet;

	ExcelWorkBook = ExcelApp->Workbooks->Add(System::Reflection::Missing::Value);

	for (int i = 0; i < dataGridView->Rows->Count; i++)
	{
		for (int j = 0; j < dataGridView->ColumnCount; j++)
		{
			ExcelApp->Cells[i + 1, j + 1] = dataGridView->Rows[i]->Cells[j]->Value;
		}
	}

	ExcelApp->Visible = true;
	ExcelApp->UserControl = true;
}
