#pragma once

#include "CalculationStudentsScholarship.h"

namespace Ñalculatingastudentsscholarship {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Ñâîäêà äëÿ MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void);

	protected:
		/// <summary>
		/// Îñâîáîäèòü âñå èñïîëüçóåìûå ğåñóğñû.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::MenuStrip^ menuStrip1;
	protected:
	private: System::Windows::Forms::ToolStripMenuItem^ îÏğîãğğàììåToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^ âûõîäToolStripMenuItem;
	private: System::Windows::Forms::GroupBox^ groupBox1;









	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::TextBox^ textBoxFullname;

	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::Button^ buttonCalculate;



	private: System::Windows::Forms::ComboBox^ comboBoxCourse;
	private: System::Windows::Forms::ComboBox^ comboBoxProgress;


	private: System::Windows::Forms::ComboBox^ comboBoxAcademicPerfomance;

	private: System::Windows::Forms::DataGridView^ dataGridView;





	private: System::Windows::Forms::ToolStripMenuItem^ ñîõğàíèòüÂEXCELToolStripMenuItem;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column1;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column2;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column3;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column4;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column5;




























	private:
		/// <summary>
		/// Îáÿçàòåëüíàÿ ïåğåìåííàÿ êîíñòğóêòîğà.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Òğåáóåìûé ìåòîä äëÿ ïîääåğæêè êîíñòğóêòîğà — íå èçìåíÿéòå 
		/// ñîäåğæèìîå ıòîãî ìåòîäà ñ ïîìîùüş ğåäàêòîğà êîäà.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^ resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->ñîõğàíèòüÂEXCELToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->îÏğîãğğàììåToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->âûõîäToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->comboBoxProgress = (gcnew System::Windows::Forms::ComboBox());
			this->comboBoxAcademicPerfomance = (gcnew System::Windows::Forms::ComboBox());
			this->comboBoxCourse = (gcnew System::Windows::Forms::ComboBox());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->textBoxFullname = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->buttonCalculate = (gcnew System::Windows::Forms::Button());
			this->dataGridView = (gcnew System::Windows::Forms::DataGridView());
			this->Column1 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column2 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column3 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column4 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column5 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->menuStrip1->SuspendLayout();
			this->groupBox1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView))->BeginInit();
			this->SuspendLayout();
			// 
			// menuStrip1
			// 
			this->menuStrip1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(61)), static_cast<System::Int32>(static_cast<System::Byte>(61)),
				static_cast<System::Int32>(static_cast<System::Byte>(61)));
			this->menuStrip1->ImageScalingSize = System::Drawing::Size(20, 20);
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(3) {
				this->ñîõğàíèòüÂEXCELToolStripMenuItem,
					this->îÏğîãğğàììåToolStripMenuItem, this->âûõîäToolStripMenuItem
			});
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(1132, 28);
			this->menuStrip1->TabIndex = 0;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// ñîõğàíèòüÂEXCELToolStripMenuItem
			// 
			this->ñîõğàíèòüÂEXCELToolStripMenuItem->ForeColor = System::Drawing::SystemColors::ButtonFace;
			this->ñîõğàíèòüÂEXCELToolStripMenuItem->Name = L"ñîõğàíèòüÂEXCELToolStripMenuItem";
			this->ñîõğàíèòüÂEXCELToolStripMenuItem->Size = System::Drawing::Size(154, 24);
			this->ñîõğàíèòüÂEXCELToolStripMenuItem->Text = L"Ñîõğàíèòü â EXCEL";
			this->ñîõğàíèòüÂEXCELToolStripMenuItem->Click += gcnew System::EventHandler(this, &MyForm::ñîõğàíèòüÂEXCELToolStripMenuItem_Click);
			// 
			// îÏğîãğğàììåToolStripMenuItem
			// 
			this->îÏğîãğğàììåToolStripMenuItem->ForeColor = System::Drawing::SystemColors::ButtonFace;
			this->îÏğîãğğàììåToolStripMenuItem->Name = L"îÏğîãğğàììåToolStripMenuItem";
			this->îÏğîãğğàììåToolStripMenuItem->Size = System::Drawing::Size(118, 24);
			this->îÏğîãğğàììåToolStripMenuItem->Text = L"Î ïğîãğàììå";
			this->îÏğîãğğàììåToolStripMenuItem->Click += gcnew System::EventHandler(this, &MyForm::îÏğîãğğàììåToolStripMenuItem_Click);
			// 
			// âûõîäToolStripMenuItem
			// 
			this->âûõîäToolStripMenuItem->ForeColor = System::Drawing::SystemColors::ButtonFace;
			this->âûõîäToolStripMenuItem->Name = L"âûõîäToolStripMenuItem";
			this->âûõîäToolStripMenuItem->Size = System::Drawing::Size(67, 24);
			this->âûõîäToolStripMenuItem->Text = L"Âûõîä";
			this->âûõîäToolStripMenuItem->Click += gcnew System::EventHandler(this, &MyForm::âûõîäToolStripMenuItem_Click);
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->comboBoxProgress);
			this->groupBox1->Controls->Add(this->comboBoxAcademicPerfomance);
			this->groupBox1->Controls->Add(this->comboBoxCourse);
			this->groupBox1->Controls->Add(this->label5);
			this->groupBox1->Controls->Add(this->label4);
			this->groupBox1->Controls->Add(this->label3);
			this->groupBox1->Controls->Add(this->textBoxFullname);
			this->groupBox1->Controls->Add(this->label1);
			this->groupBox1->ForeColor = System::Drawing::SystemColors::ButtonFace;
			this->groupBox1->Location = System::Drawing::Point(16, 33);
			this->groupBox1->Margin = System::Windows::Forms::Padding(4);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Padding = System::Windows::Forms::Padding(4);
			this->groupBox1->Size = System::Drawing::Size(1097, 98);
			this->groupBox1->TabIndex = 1;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Ââîä äàííûõ";
			// 
			// comboBoxProgress
			// 
			this->comboBoxProgress->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->comboBoxProgress->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 11.25F, System::Drawing::FontStyle::Regular,
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->comboBoxProgress->FormattingEnabled = true;
			this->comboBoxProgress->Items->AddRange(gcnew cli::array< System::Object^  >(3) {
				L"íåò äîñòèæåíèé", L"äîñòèæåíèÿ â ñïîğòå",
					L"äîñòèæåíèÿ â íàóêå"
			});
			this->comboBoxProgress->Location = System::Drawing::Point(763, 46);
			this->comboBoxProgress->Margin = System::Windows::Forms::Padding(4);
			this->comboBoxProgress->Name = L"comboBoxProgress";
			this->comboBoxProgress->Size = System::Drawing::Size(313, 32);
			this->comboBoxProgress->TabIndex = 10;
			// 
			// comboBoxAcademicPerfomance
			// 
			this->comboBoxAcademicPerfomance->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->comboBoxAcademicPerfomance->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 11.25F, System::Drawing::FontStyle::Regular,
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->comboBoxAcademicPerfomance->FormattingEnabled = true;
			this->comboBoxAcademicPerfomance->Items->AddRange(gcnew cli::array< System::Object^  >(4) {
				L"îòëè÷íèê", L"õîğîøèñò", L"òğîå÷íèê",
					L"äîëæíèê"
			});
			this->comboBoxAcademicPerfomance->Location = System::Drawing::Point(515, 46);
			this->comboBoxAcademicPerfomance->Margin = System::Windows::Forms::Padding(4);
			this->comboBoxAcademicPerfomance->Name = L"comboBoxAcademicPerfomance";
			this->comboBoxAcademicPerfomance->Size = System::Drawing::Size(239, 32);
			this->comboBoxAcademicPerfomance->TabIndex = 9;
			// 
			// comboBoxCourse
			// 
			this->comboBoxCourse->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->comboBoxCourse->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 11.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->comboBoxCourse->ForeColor = System::Drawing::SystemColors::WindowText;
			this->comboBoxCourse->FormattingEnabled = true;
			this->comboBoxCourse->Items->AddRange(gcnew cli::array< System::Object^  >(4) { L"1 êóğñ", L"2 êóğñ", L"3 êóğñ", L"4 êóğñ" });
			this->comboBoxCourse->Location = System::Drawing::Point(345, 46);
			this->comboBoxCourse->Margin = System::Windows::Forms::Padding(4);
			this->comboBoxCourse->Name = L"comboBoxCourse";
			this->comboBoxCourse->Size = System::Drawing::Size(160, 32);
			this->comboBoxCourse->TabIndex = 4;
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(32)), static_cast<System::Int32>(static_cast<System::Byte>(32)),
				static_cast<System::Int32>(static_cast<System::Byte>(32)));
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label5->ForeColor = System::Drawing::SystemColors::ButtonFace;
			this->label5->Location = System::Drawing::Point(845, 17);
			this->label5->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(140, 25);
			this->label5->TabIndex = 5;
			this->label5->Text = L"Äîñòèæåíèÿ:";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(32)), static_cast<System::Int32>(static_cast<System::Byte>(32)),
				static_cast<System::Int32>(static_cast<System::Byte>(32)));
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label4->ForeColor = System::Drawing::SystemColors::ButtonFace;
			this->label4->Location = System::Drawing::Point(552, 20);
			this->label4->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(153, 25);
			this->label4->TabIndex = 4;
			this->label4->Text = L"Óñïåâàåìîñòü:";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(32)), static_cast<System::Int32>(static_cast<System::Byte>(32)),
				static_cast<System::Int32>(static_cast<System::Byte>(32)));
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label3->ForeColor = System::Drawing::SystemColors::ButtonFace;
			this->label3->Location = System::Drawing::Point(395, 20);
			this->label3->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(60, 25);
			this->label3->TabIndex = 3;
			this->label3->Text = L"Êóğñ:";
			// 
			// textBoxFullname
			// 
			this->textBoxFullname->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->textBoxFullname->Location = System::Drawing::Point(21, 46);
			this->textBoxFullname->Margin = System::Windows::Forms::Padding(4);
			this->textBoxFullname->Name = L"textBoxFullname";
			this->textBoxFullname->Size = System::Drawing::Size(315, 30);
			this->textBoxFullname->TabIndex = 1;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(32)), static_cast<System::Int32>(static_cast<System::Byte>(32)),
				static_cast<System::Int32>(static_cast<System::Byte>(32)));
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label1->ForeColor = System::Drawing::SystemColors::ButtonFace;
			this->label1->Location = System::Drawing::Point(147, 20);
			this->label1->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(66, 25);
			this->label1->TabIndex = 0;
			this->label1->Text = L"ÔÈÎ:";
			// 
			// buttonCalculate
			// 
			this->buttonCalculate->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(238)), static_cast<System::Int32>(static_cast<System::Byte>(165)),
				static_cast<System::Int32>(static_cast<System::Byte>(9)));
			this->buttonCalculate->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->buttonCalculate->ForeColor = System::Drawing::Color::Black;
			this->buttonCalculate->Location = System::Drawing::Point(441, 139);
			this->buttonCalculate->Margin = System::Windows::Forms::Padding(4);
			this->buttonCalculate->Name = L"buttonCalculate";
			this->buttonCalculate->Size = System::Drawing::Size(290, 54);
			this->buttonCalculate->TabIndex = 2;
			this->buttonCalculate->Text = L"Ğàññ÷èòàòü ñòèïåíäèş";
			this->buttonCalculate->UseVisualStyleBackColor = false;
			this->buttonCalculate->Click += gcnew System::EventHandler(this, &MyForm::buttonCalculate_Click);
			// 
			// dataGridView
			// 
			this->dataGridView->AllowUserToAddRows = false;
			this->dataGridView->BackgroundColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(157)),
				static_cast<System::Int32>(static_cast<System::Byte>(157)), static_cast<System::Int32>(static_cast<System::Byte>(157)));
			this->dataGridView->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridView->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(5) {
				this->Column1,
					this->Column2, this->Column3, this->Column4, this->Column5
			});
			this->dataGridView->Location = System::Drawing::Point(100, 223);
			this->dataGridView->Margin = System::Windows::Forms::Padding(4);
			this->dataGridView->Name = L"dataGridView";
			this->dataGridView->ReadOnly = true;
			this->dataGridView->RowHeadersWidth = 51;
			this->dataGridView->Size = System::Drawing::Size(901, 300);
			this->dataGridView->TabIndex = 3;
			this->dataGridView->RowsAdded += gcnew System::Windows::Forms::DataGridViewRowsAddedEventHandler(this, &MyForm::dataGridView_RowsAdded);
			// 
			// Column1
			// 
			this->Column1->HeaderText = L"ÔÈÎ";
			this->Column1->MinimumWidth = 6;
			this->Column1->Name = L"Column1";
			this->Column1->ReadOnly = true;
			this->Column1->Width = 125;
			// 
			// Column2
			// 
			this->Column2->HeaderText = L"Êóğñ";
			this->Column2->MinimumWidth = 6;
			this->Column2->Name = L"Column2";
			this->Column2->ReadOnly = true;
			this->Column2->Width = 125;
			// 
			// Column3
			// 
			this->Column3->HeaderText = L"Óñïåâàåìîñòü";
			this->Column3->MinimumWidth = 6;
			this->Column3->Name = L"Column3";
			this->Column3->ReadOnly = true;
			this->Column3->Width = 125;
			// 
			// Column4
			// 
			this->Column4->HeaderText = L"Äîñòèæåíèÿ";
			this->Column4->MinimumWidth = 6;
			this->Column4->Name = L"Column4";
			this->Column4->ReadOnly = true;
			this->Column4->Width = 125;
			// 
			// Column5
			// 
			this->Column5->HeaderText = L"Ğåçóëüòàò";
			this->Column5->MinimumWidth = 6;
			this->Column5->Name = L"Column5";
			this->Column5->ReadOnly = true;
			this->Column5->Width = 125;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(32)), static_cast<System::Int32>(static_cast<System::Byte>(32)),
				static_cast<System::Int32>(static_cast<System::Byte>(32)));
			this->ClientSize = System::Drawing::Size(1132, 609);
			this->Controls->Add(this->dataGridView);
			this->Controls->Add(this->buttonCalculate);
			this->Controls->Add(this->groupBox1);
			this->Controls->Add(this->menuStrip1);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::Fixed3D;
			this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
			this->MainMenuStrip = this->menuStrip1;
			this->Margin = System::Windows::Forms::Padding(4);
			this->MaximizeBox = false;
			this->Name = L"MyForm";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Ğàñ÷åò ñòèïåíäèé";
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

		// Ïîëÿ 
		CalculationStudentsScholarship^ calculationStudentsScholarship;
		String^ result = "";

		// Ñîáûòèÿ ôîğìû
		private: System::Void buttonCalculate_Click(System::Object^ sender, System::EventArgs^ e);
		private: System::Void âûõîäToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e);
		private: System::Void îÏğîãğğàììåToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e);
		//private: System::Void ñîõğàíèòüÊàêXMLToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e);
		private: System::Void dataGridView_RowsAdded(System::Object^ sender, System::Windows::Forms::DataGridViewRowsAddedEventArgs^ e);
		private: System::Void ñîõğàíèòüÂEXCELToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e);
};
}
