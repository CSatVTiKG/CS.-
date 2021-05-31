#include "MyForm.h"

using namespace System;
using namespace System::IO;
using namespace System::Windows::Forms;

//точка входа для приложения, для того, чтобы можно было запустить 
[STAThreadAttribute]
void main(array<String^>^ args) {
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);

	Сalculatingastudentsscholarship::MyForm form;
	Application::Run(% form);
}

Сalculatingastudentsscholarship::MyForm::MyForm(void)
{
	// Инициализация компонентов
	InitializeComponent();
	calculationStudentsScholarship = gcnew CalculationStudentsScholarship();
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
	MessageBox::Show(result, "Результат!");
}

System::Void Сalculatingastudentsscholarship::MyForm::выходToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e)
{
	if (MessageBox::Show("Завершить работу?", "Выход!", MessageBoxButtons::YesNo) == Windows::Forms::DialogResult::Yes)
		Application::Exit();
}

System::Void Сalculatingastudentsscholarship::MyForm::оПрогрраммеToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e)
{
	MessageBox::Show("Работу выполнил: студент группы БО921ПРИ Славников Б.В.\nДанные о прогрмамме: программа предназначена для расчета стипендии в ВУЗе","Информация о программе!");
}

System::Void Сalculatingastudentsscholarship::MyForm::сохранитьКакXMLToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e)
{
	try {
		if (result == "") {
			MessageBox::Show("Сделайте расчет, после сохранение!","Внимание!");
			return;
		}

		DataSet^ ds = gcnew DataSet();		// создаем пока что пустой кэш данных
		DataTable^ dt = gcnew DataTable();	// создаем пока что пустую таблицу данных
		dt->TableName = "SaveXML";			// название таблицы
		dt->Columns->Add("Result");			// название колонок
		ds->Tables->Add(dt);				// в ds создается таблица, с названием и колонками, созданными выше

		DataRow^ row = ds->Tables["SaveXML"]->NewRow(); // создаем новую строку в таблице, занесенной в ds
		row["Result"] = result;							// в столбец этой строки заносим данные
		ds->Tables["SaveXML"]->Rows->Add(row);			// добавление всей этой строки в таблицу ds

		ds->WriteXml("..\\Save\\Data.xml");
		MessageBox::Show("XML файл успешно сохранен!", "Выполнено!");
	}
	catch (IOException^ e) {
		// Если в блоке try возникнет ошибка типа IOException (то есть ввода, вывода)
		// сработает блок catch, который отловит данную ошибку и выведет ее,
		// при этом, не завершив работу критической ошибкой
		MessageBox::Show(e->ToString(), "Ошибка!");
	}
}
